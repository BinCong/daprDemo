﻿
using Oxygen.Client.ServerSymbol.Store;
using System.Threading.Tasks;

namespace aspnetcoreDemo.Core.IServices
{
    public class LoginSuccessToken : StateStore
    {
        public LoginSuccessToken(string key)
        {
            Key = $"UserAccountToken_{key}";
        }

        public override string Key { get ; set; }

        public override object Data { get; set; }
    }
}
