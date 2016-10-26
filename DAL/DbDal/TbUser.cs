using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Net.Mail;
using System.Configuration;
using System.IO;
using DataAccess;
//using Library;
//using lxq;
using lgk.DAL.DbClass;

namespace lgk.DAL.DbDal
{
    public class TbUser
    {
        //public int tb_UserLogin(string name, string psw)
        //{
        //    IDataParameter[] param = {
        //                               new SqlParameter ("@UserCode",name),
        //                               new SqlParameter ("@Password",PageValidate.GetMd5(psw))
        //                           };
        //    int n = SQLServerHelper.ExecuteSql("tb_UserLogin", param);
        //    return n;
        //}

        //获取用户级别表
        public List<TLevel> GetLevel()
        {
            string sql = "select * from tb_level";
            DataTable table = SQLServerHelper.GetDataTable(sql);
            List<TLevel> levelList = new List<TLevel>();
            if (table != null && table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    TLevel level = new TLevel();
                    level.LevelID = Convert.ToInt32(row["LevelID"]);
                    level.LevelName = row["LevelName"].ToString();
                    level.IsOpen = Convert.ToInt32(row["IsOpen"]);

                    levelList.Add(level);
                }
            }
            return levelList;
        }

        //--------------------------------获取左区，或右区的用户集合---------------------------------------------------------

        private DataTable UserListTable = new DataTable();//保存所有用户的表
        private List<TUser> AllUserList = new List<TUser>();//所有用户的对象集合

        //从数据库中获取所有用户，存入内存表中
        public DataTable GetUserList()
        {
            //string sql = "select UserID,UserCode,RecommendID,RecommendCode,Level_ID,RegMoney,BillCount,LeftScore,RightScore"
            //            + "from tb_user where IsOpend = 1 and IsLock = 0 and IsEmpty = 0";

            string sql = "select * from tb_usertest";
            DataTable table = SQLServerHelper.GetDataTable(sql);
            return table;
        }

        //依据用户id，从所有用户对象的集合中，找出用户的区域：左区、右区
        private int GetLocation(int userid)
        {
            foreach (TUser user in AllUserList)
            {
                if (user.UserID == userid)
                {
                    return user.Location;
                }
            }
            return -1;
        }

        //将内存中所有用户的表，转换为用户的对象集合（以后所有对用户的操作，都在此对象集合中），便于操作
        private List<TUser> FormatUserList(DataTable table)
        {
            List<TUser> userlist = new List<TUser>();
            foreach (DataRow row in table.Rows)
            {
                TUser user = new TUser();
                user.UserID = Convert.ToInt32(row["UserID"]);
                user.UserCode = row["UserCode"].ToString();
                user.RecommendID = Convert.ToInt32(row["RecommendID"]);
                user.RecommendCode = row["RecommendCode"].ToString();
                user.Location = Convert.ToInt32(row["Location"]);
                user.RegMoney = Convert.ToDecimal(row["RegMoney"]);

                userlist.Add(user);
            }
            return userlist;
        }

        //找出某个节点下面一级的子节点
        private List<TUser> GetUserNode(int upuserid,int location)
        {
            List<TUser> nodelist = new List<TUser>();
            foreach(TUser user in AllUserList )
            {
                if (upuserid == user.RecommendID && location == user.Location)
                {
                    nodelist.Add(user);
                }
            }
            return nodelist;
        }

        //找出指定id的user对象
        private TUser GetUser(int userid)
        {
            foreach (TUser user in AllUserList)
            {
                if (user.UserID == userid)
                {
                    return user;
                }
            }
            return null;
        }

        //递归方法,结束条件：没有子节点
        //树形结构递归说明：
        //1.找到开始节点的下一级的所有节点，形成集合
        //2.然后判断集合是否为空：为空，说明没有子节点了，递归结束
        //3.不为空，则循环此集合：在其中，找到每个节点的id，作为自己子节点的查找条件，调用方法自身
        //4.在此集合循环中，找到的所有节点，即为符合条件的树形结构，需要单独保存
        private void Recurse(int upUserId, int location, List<TUser> partUserList)
        {
            List<TUser> nodelist = GetUserNode(upUserId, location);//找出指定节点的子节点集合
            if (nodelist.Count < 0)
            {
                return;
            }
            foreach (TUser user in nodelist)
            {
                if (upUserId == user.RecommendID && user.Location == location)
                {
                    partUserList.Add(user);//将符合条件的子节点存入集合中
                    Recurse(user.UserID, location, partUserList);
                }
            }
        }

        //递归获取指定节点下的所有会员，即找出指定父节点下的所有子节点,并返回这些节点的集合
        public List<TUser> GetLeftOrRightUserList(int startid)
        {
            UserListTable = GetUserList();
            AllUserList = FormatUserList(UserListTable);//将表中的数据存储到对象集合
            int count = AllUserList.Count;

            List<TUser> partUserList = new List<TUser>();//保存符合条件的节点的用户id
            int location = GetLocation(startid);//找出开始节点所在的区域
            if (count > 0 && location > 0)
            {
                TUser user = GetUser(startid);//找到起始节点自身的对象
                if (user == null)
                {
                    return null;
                }
                else
                {
                    partUserList.Add(user);//将起始节点先加入到集合中
                    Recurse(startid, location, partUserList);
                }
            }

            ShowUser(partUserList);
            return partUserList;
        }

        //统计一个区的业绩
        private decimal SumLocation(List<TUser> userList)
        {
            decimal sum = 0;
            foreach (TUser user in userList)
            {
                sum += user.RegMoney;
            }
            return sum;
        }

        //依据用户的级别id，找出用户的级别名称
        private string GetUserLevel(int levelid,List<TLevel> levelList)
        {
            foreach (TLevel level in levelList)
            {
                if (level.LevelID == levelid)
                {
                    return level.LevelName;
                }
            }
            return string.Empty;
        }

        //更新数据库中用户的奖金账户，以及添加明细
        private int HandleDuipengDb(int userId, decimal bounsMoney)
        {
            DateTime beginTime = DateTime.Now.AddDays(-1).Date.AddDays(1);//今天凌晨
            DateTime nextBeginTime = beginTime.AddDays(1);//今天第24时
            IDataParameter[] param = {
                                       new SqlParameter ("@Morrning",beginTime),
                                       new SqlParameter ("@NextMorrning",nextBeginTime),
                                       new SqlParameter ("@UserID",userId),
                                       new SqlParameter ("@BounsMoney",bounsMoney)
                                   };
            int n = SQLServerHelper.ExecuteSql("tb_HandleDuipengDb", param);//如果要测试，将存储过程中的tb_user表改为tb_usertest表，并给tb_usertest添加奖金等字段
            return n;
        }

        //加权平均分配奖金给小区每个用户
        private void HandleDuipeng(decimal totalMoney, List<TUser> smallUserList)
        {
            List<TLevel> levelList = GetLevel();//获取所有用户级别
            decimal baseMoney = totalMoney * decimal.Parse("0.1");//奖金计算基数
            foreach (TUser user in smallUserList)
            {
                decimal award = user.RegMoney / totalMoney * baseMoney;//用户奖金

                HandleDuipengDb(user.UserID, award);//更新数据库
            }
        }

        public void DuiPeng()
        {
            List<TUser> leftUserList = GetLeftOrRightUserList(2);//左区用户
            List<TUser> rightUserList = GetLeftOrRightUserList(3);//右区用户

            decimal leftSum = SumLocation(leftUserList);//左区业绩
            decimal rightSum = SumLocation(rightUserList);//右区业绩
            if (leftSum > rightSum)
            {
                HandleDuipeng(rightSum,rightUserList);//依据小区业绩计算对碰奖
            }
            else
            {
                HandleDuipeng(leftSum, leftUserList);
            }
        }

        private void ShowUser(List<TUser> partUserList)
        {
            foreach (TUser user in partUserList)
            {
                int userid = user.UserID;
                string usercode = user.UserCode;
                int recommendid = user.RecommendID;
                string recommendcode = user.RecommendCode;
                int location = user.Location;
            }
        }

        //--------------------------------获取左区，或右区的用户集合---------------------------------------------------------

    }
}