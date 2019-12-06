using System;
using System.Collections.Generic;
using System.Text;

namespace 重装板块成本系统.model
{	
	[Serializable()]
	public class 调整费用分配表
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
			public string 工号  
			{
				get;
				set;
			}
			public decimal 薪酬调整  
			{
				get;
				set;
			}
			public decimal 燃料调整  
			{
				get;
				set;
			}
			public decimal 制造调整  
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