﻿

using aspnetcoreDemo.Core.IServices;
using System.Threading.Tasks;
using Oxygen.Client.ServerSymbol.Events;
using Oxygen.Client.ServerProxyFactory.Interface;
using System;

namespace LoginService
{
    public class LoginBizService : ILoginService
    {

        private readonly IStateManager _stateManager;

        private IEventBus _eventBus;


        public LoginBizService(IStateManager stateManager,IEventBus eventBus)
        {
            _stateManager = stateManager;
            _eventBus = eventBus;
        }

        public async Task<DtoLoginSuccess> AccountLogin(DtoUserInfo dto)
        {
            var loginToken = Guid.NewGuid().ToString();

            await _eventBus.SendEvent(EventTopic.Account.LoginSuccess, new DtoLoginSuccess() { Token = loginToken });

            return await Task.FromResult(new DtoLoginSuccess() { Token = loginToken });
        }
    }
}
