﻿using SqlSugar;
using System;
using System.Collections.Generic;

namespace aspnetcoreDemo.Core.Model.BizModels
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    public class SysUserInfo : SysInfoBase<int>
    {
        public SysUserInfo() { }

        /// <summary>
        /// 用户卡号
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
        public string uCardNum { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string uUserName { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>

        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string uBirthDate { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string uCellPhoneNum { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string uIDCardNum { get; set; }

        /// <summary>
        /// 职业
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string uJob { get; set; }

        /// <summary>
        /// 开发渠道
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string uDevelopChannel { get; set; }

        /// <summary>
        /// 开发人员
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string uDevelopStuff { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int uStatus { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 2000, IsNullable = true)]
        public string uRemark { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string UAddr { get; set; }

        [SugarColumn(IsNullable = true)]
        public bool UtdIsDelete { get; set; }

    }
}
