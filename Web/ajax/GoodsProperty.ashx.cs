using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ajax
{
    /// <summary>
    /// GoodsProperty 的摘要说明
    /// </summary>
    public class GoodsProperty : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string msg;

            context.Response.ContentType = "text/plain";
            save(out msg);
            context.Response.Write(msg);
 
        }

        private bool save(out string msg)
        {
            msg = string.Empty;

            string str_gid = HttpContext.Current.Request["gid"].ToString();
            string str_color = HttpContext.Current.Request["color"].ToString();
            string str_size = HttpContext.Current.Request["size"].ToString();

            if (str_color.Trim() == "")
            {
                msg = "请输入颜色";
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入颜色!');", true);
                return false;
            }
            string val = str_size.Trim();
            if (val == "")
            {
                msg = "请输入数量";
             //   ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入数量!');", true);
                return false;
            }

            var gcolor = new lgk.BLL.tb_goods_property_color().GetModelList(string.Format(" ColorName ='{0}' AND goodsID = {1} ", str_color, str_gid));
            if (gcolor.Count > 0)
            {
                msg = "该产品颜色已经存在";
                return false;
            }

            string[] sizelist, sizeqy;
            int sizeID;
            string qy;
            sizelist = val.Split('|');

            var sizeBLL = new lgk.BLL.tb_goods_size().GetModelList("");
            var psizeBLL = new lgk.BLL.tb_goods_property_size();
            var colorBLL = new lgk.BLL.tb_goods_property_color();

            lgk.Model.tb_goods_property_color colorModel = new lgk.Model.tb_goods_property_color();
            colorModel.goodsID = Convert.ToInt32(str_gid);
            colorModel.ColorName = str_color;
           // colorModel.Pic = ViewState["urlcolor1"].ToString();
            int colorid = colorBLL.Add(colorModel);

            foreach (var size in sizelist)
            {
                sizeqy = size.Split(',');
                int.TryParse(sizeqy[0],out sizeID);
                if (sizeID > 0)
                {
                    qy = sizeqy[1];

                    lgk.Model.tb_goods_property_size sizeModel = new lgk.Model.tb_goods_property_size();
                    sizeModel.goodsID = colorModel.goodsID;
                    sizeModel.ColorID = colorid;
                    sizeModel.SizeName = sizeBLL.Where(s => s.SizeID == sizeID).Single().Name;
                    sizeModel.Qry = int.Parse(qy);
                    psizeBLL.Add(sizeModel);
                }
            }
            msg = "添加属性成功";
            return true;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}