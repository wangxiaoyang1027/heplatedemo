using System;
using System.Collections.Generic;
using System.Text;

namespace 重装板块成本系统.model
{	
	[Serializable()]
	public class 原始凭证
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
			public string 凭证号  
			{
				get;
				set;
			}
			public string 材质  
			{
				get;
				set;
			}
			public string 工作令号  
			{
				get;
				set;
			}
			public decimal? 重量  
			{
				get;
				set;
			}
			public decimal 金额  
			{
				get;
				set;
			}
			public short 单位  
			{
				get;
				set;
			}
	}
}