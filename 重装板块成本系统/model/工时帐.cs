using System;
using System.Collections.Generic;
using System.Text;

namespace 重装板块成本系统.model
{	
	[Serializable()]
	public class 工时帐
	{	
			public Guid ID  
			{
				get;
				set;
			}
			public DateTime 日期  
			{
				get;
				set;
			}
			public string 工号  
			{
				get;
				set;
			}
			public string 图号  
			{
				get;
				set;
			}
			public string 名称  
			{
				get;
				set;
			}
			public decimal? 工序号  
			{
				get;
				set;
			}
			public string 设备  
			{
				get;
				set;
			}
			public string 操作人  
			{
				get;
				set;
			}
			public int 件数  
			{
				get;
				set;
			}
			public decimal 准结  
			{
				get;
				set;
			}
			public decimal 单件  
			{
				get;
				set;
			}
			public byte[] Time  
			{
				get;
				set;
			}
			public string 计算工号  
			{
				get;
				set;
			}
			public string 备注  
			{
				get;
				set;
			}
			public string 工艺机床  
			{
				get;
				set;
			}
            public string cardno { get; set; }
    }
}