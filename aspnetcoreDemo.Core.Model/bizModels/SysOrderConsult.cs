using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcoreDemo.Core.Model.BizModels
{
    /// <summary>
    /// 报单记录
    /// </summary>
    public class SysOrderConsult:SysInfoBase<int>
    {
        /// <summary>
        /// 状态
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 20, IsNullable = false)]

        public string uStatus { get; set; }

        /// <summary>
        /// 受理时间
        /// </summary>
        public System.DateTime uModTime { get; set; } = DateTime.Now;


        public SysUserInfo sysUserInfoId;

        ///// <summary>
        ///// 用户卡号
        ///// </summary>
        //[SugarColumn(ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]        
        //public string uUserCardNum { get; set; }

        ///// <summary>
        ///// 用户姓名
        ///// </summary>
        //[SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = false)]
        //public string uUserName { get; set; }

        /// <summary>
        /// 咨询电话
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = false)]
        public string uUserConultPhoneNum { get; set; }


        /// <summary>
        /// 咨询项目
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = false)]
        public string uConultProjectName { get; set; }

        /// <summary>
        /// 当次信息来源
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string uChanelInfo { get; set; }

        /// <summary>
        /// 受理情况
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string uModStatus { get; set; }

        /// <summary>
        /// 受理人员
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string uModStuff { get; set; }

        /// <summary>
        /// 当次开发人员
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string uDevelopStuff { get; set; }

        /// <summary>
        /// 到诊机构
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string uArriveInsitute { get; set; }


        /// <summary>
        /// 到诊日期
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string uArriveDate { get; set; }

    }
}
