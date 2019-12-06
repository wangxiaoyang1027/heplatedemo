using System;
using System.Collections.Generic;
using System.Text;

namespace 重装板块成本系统.model
{	
	[Serializable()]
	public class 部门表
	{	
			public short Id  
			{
				get;
				set;
			}
			public string 部门名称  
			{
				get;
				set;
			}
			public bool 禁用  
			{
				get;
				set;
			}
	}
}