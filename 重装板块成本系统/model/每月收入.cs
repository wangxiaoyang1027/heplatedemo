using System;
using System.Collections.Generic;
using System.Text;

namespace 重装板块成本系统.model
{	
	[Serializable()]
	public class 每月收入
	{	
			public Guid Id  
			{
				get;
				set;
			}
			public string 工号  
			{
				get;
				set;
			}
			public string 台份  
			{
				get;
				set;
			}
			public DateTime 日期  
			{
				get;
				set;
			}
			public string 类型  
			{
				get;
				set;
			}
			public double 重量  
			{
				get;
				set;
			}
			public double? 收入  
			{
				get;
				set;
			}
			public string 主机厂  
			{
				get;
				set;
			}
        public double 欧元
        {
            get;
            set;
        }
        public double 美元 { get; set; }
	}
}