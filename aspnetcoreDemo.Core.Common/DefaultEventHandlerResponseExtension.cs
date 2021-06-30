
using System.Threading.Tasks;
using Autofac;
using Oxygen.Client.ServerSymbol.Events;
using aspnetcoreDemo.Core.Common;
using System;
using System.Collections.Generic;


namespace aspnetcoreDemo.Core.Common
{
    public static class DefaultEventHandlerResponseExtension
    {
        public static async Task<DefaultEventHandlerResponse> RunAsync(this DefaultEventHandlerResponse handlerResult, string handleName,
            string eventJson, Func<Task> invokeAsync)
        {
            try
            {
                await invokeAsync();
            }
            catch (Exception)
            {
            }

            return DefaultEventHandlerResponse.Default();
        }
    }
}
