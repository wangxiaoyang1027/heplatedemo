using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 重装板块成本系统.model
{
    class 成品库房表
    {
        public string id { get; set; }
        public string 工作令号 { get; set; }
        public DateTime 日期 { get; set; }
        public decimal 金额 { get; set; }
        public decimal ty { get; set; }
        public decimal zdh { get; set; }
        public decimal sj { get; set; }
        public decimal ys { get; set; }
        public decimal az { get; set; }
        public decimal qt { get; set; }
        public decimal xsjy { get; set; }
        public decimal gjjy { get; set; }
    }
}
