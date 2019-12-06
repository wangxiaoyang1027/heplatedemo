using System;
using System.Collections.Generic;
using System.Text;

namespace 重装板块成本系统.model
{	
	[Serializable()]
	public class 用户表
	{	
			public Guid Id  
			{
				get;
				set;
			}
			public string Cardno  
			{
				get;
				set;
			}
			public string Pwd  
			{
				get;
				set;
			}
			public string Name  
			{
				get;
				set;
			}
			public short Departid  
			{
				get;
				set;
			}
			public bool Noused  
			{
				get;
				set;
			}
	}
}