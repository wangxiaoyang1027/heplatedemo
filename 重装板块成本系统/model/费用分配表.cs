using System;
using System.Collections.Generic;
using System.Text;

namespace 重装板块成本系统.model
{	
	[Serializable()]
	public class 费用分配表
	{	
			public Guid ID  
			{
				get;
				set;
			}
			public string 工号  
			{
				get;
				set;
			}
			public DateTime 时间  
			{
				get;
				set;
			}
			public decimal 燃料动力  
			{
				get;
				set;
			}
			public decimal 薪酬  
			{
				get;
				set;
			}
			public decimal 制造费用  
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
			public short 部门  
			{
				get;
				set;
			}
	}
}