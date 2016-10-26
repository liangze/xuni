using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.DAL.DbClass
{
    public class TBonus
    {
        public int UserId { get; set; }

        public int TypeId { get; set; }

        public decimal Amount { get; set; }

        public DateTime AddTime { get; set; }

        public int IsSettled { get; set; }

        public DateTime SttleTime { get; set; }

    }
}