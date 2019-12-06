using System;
using System.Collections.Generic;
using System.Text;

namespace 重装板块成本系统.model
{	
	[Serializable()]
	public class 工号表
	{	
			public string 工作令号  
			{
				get;
				set;
			}
			public string 名称  
			{
				get;
				set;
			}
			public bool Noused  
			{
				get;
				set;
			}
            public bool Nocalc
            {
                get;
                set;
            }
        public short? 行业类别
        {
            get;
            set;
        }
        public short? 产品类别
        {
            get;
            set;
        }
        public string 合同号
        {
            get;
            set;
        }
        public short? 订货单位
        {
            get;
            set;
        }
        public string 购货单位
        {
            get;
            set;
        }
        public string 工号类型
        {
            get;
            set;
        }

    }

}