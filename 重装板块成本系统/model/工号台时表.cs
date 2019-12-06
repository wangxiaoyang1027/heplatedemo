using System;
using System.Collections.Generic;
using System.Text;

namespace 重装板块成本系统.model
{	
	[Serializable()]
	public class 工号台时表
	{	
			public Guid Id  
			{
				get;
				set;
			}
			public DateTime 日期  
			{
				get;
				set;
			}
			public decimal 工时  
			{
				get;
				set;
			}
			public decimal 折合工时  
			{
				get;
				set;
			}
			public string 工号  
			{
				get;
				set;
			}
			public short 部门  
			{
				get;
				set;
			}
	}
}