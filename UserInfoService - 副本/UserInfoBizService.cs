using aspnetcoreDemo.Core.IServices;
using System.Threading.Tasks;
using Oxygen.Client.ServerSymbol.Events;
using Oxygen.Client.ServerProxyFactory.Interface;
using System;
using aspnetcoreDemo.Core.Model.BizModels;
using aspnetcoreDemo.Core.Repository;
using System.Collections.Generic;
using aspnetcoreDemo.Core.Common;

namespace UserInfoService
{
    public class UserInfoBizService : BaseServices<SysUserInfo>,IUserInfoService,IEventHandler
    {

        private readonly IStateManager _stateManager;

        private readonly IBaseRepository<SysUserInfo> _dal;

        private IEventBus _eventBus;


        public UserInfoBizService(IBaseRepository<SysUserInfo> dal,IStateManager stateManager)
        {
            _stateManager = stateManager;
            _dal = dal;
        }

        [EventHandlerFunc(EventTopic.Account.LoginSuccess)]
        public async Task<DefaultEventHandlerResponse> SubLoginSuccess(EventHandleRequest<DtoLoginSuccess> dto)
        {
            return await new DefaultEventHandlerResponse().RunAsync(nameof(SubLoginSuccess), dto.GetDataJson(), async () =>
              {
                  await _stateManager.SetState(new LoginSuccessToken(dto.GetData().Token));
              });
        }

        public async Task<List<SysUserInfo>> QueryUserInfos()
        {
            var data =await _dal.Query();

            return await Task.FromResult(data);
        }

        public async Task<ApiResult> SaveUserInfo(DtoUserInfo dto)
        {
            return ApiResult.OK();
        }
    }
}
