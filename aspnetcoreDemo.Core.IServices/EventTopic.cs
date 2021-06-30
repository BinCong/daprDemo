﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetcoreDemo.Core.IServices
{
    public struct EventTopic
    {
        public struct Account
        {
            public const string LoginSuccess = "AccountLoginSuccess";

            public const string LoginOut = "AccountLoginOut";

            public const string LoginExpire = "AccountLoginExpire";
        }
    }
}
