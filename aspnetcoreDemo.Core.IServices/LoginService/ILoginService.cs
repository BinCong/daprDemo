﻿using System.Threading.Tasks;
using Oxygen.Client.ServerSymbol;

namespace aspnetcoreDemo.Core.IServices
{
    [RemoteService("loginservice","login","登录服务")]
    public interface ILoginService
    {
        [RemoteFunc(funcDescription: "用户登录")]

        Task<DtoLoginSuccess> AccountLogin(DtoUserInfo dto);
    }
}
