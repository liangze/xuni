using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.DAL.DbDal
{
    public class TUser
    {
        public int UserID { get; set; }

        public string UserCode { get; set; }

        public int RecommendID { get; set; }

        public string RecommendCode { get; set; }

        public int Location { get; set; }

        public decimal RegMoney { get; set; }

        public int Level_ID { get; set; }
    }
}