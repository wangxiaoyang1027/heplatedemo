using System;
using System.Collections.Generic;
using System.Text;

namespace 重装板块成本系统.model
{	
	[Serializable()]
	public class 其他费用表
	{	
			public Guid Id  
			{
				get;
				set;
			}
			public DateTime 年月  
			{
				get;
				set;
			}
			public decimal 薪酬  
			{
				get;
				set;
			}
			public decimal 燃料动力  
			{
				get;
				set;
			}
			public decimal 制造费用  
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