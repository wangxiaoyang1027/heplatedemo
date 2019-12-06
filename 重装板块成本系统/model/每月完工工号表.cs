using System;
using System.Collections.Generic;
using System.Text;

namespace 重装板块成本系统.model
{	
	[Serializable()]
	public class 每月完工工号表
	{	
			public string 工号  
			{
				get;
				set;
			}
			public DateTime 月份  
			{
				get;
				set;
			}
			public decimal 收入  
			{
				get;
				set;
			}
			public string 类型  
			{
				get;
				set;
			}
			public short 台数  
			{
				get;
				set;
			}
			public decimal 重量  
			{
				get;
				set;
			}
	}
}