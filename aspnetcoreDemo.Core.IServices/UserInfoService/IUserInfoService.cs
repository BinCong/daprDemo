﻿using System.Threading.Tasks;
using Oxygen.Client.ServerSymbol;
using System.Collections.Generic;
using aspnetcoreDemo.Core.Model.BizModels;
using aspnetcoreDemo.Core.Model;

namespace aspnetcoreDemo.Core.IServices
{
    [RemoteService("userinfoservice","userinfo","用户信息服务")]
    public interface IUserInfoService
    {
        [RemoteFunc(funcDescription: "保存用户信息")]

        Task<ApiResult> SaveUserInfo(DtoUserInfo dto);


        [RemoteFunc(funcDescription: "查询")]

        Task<MessageModel<PageModel<SysUserInfo>>> QueryUserInfos();
    }
}
