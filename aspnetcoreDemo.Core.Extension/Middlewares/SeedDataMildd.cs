using Microsoft.AspNetCore.Builder;
using System;
using aspnetcoreDemo.Core.Model;
using aspnetcoreDemo.Core.Common;

namespace aspnetcoreDemo.Core.Extension
{
    /// <summary>
    /// 生成种子数据中间件服务
    /// </summary>
    public static class SeedDataMildd
    {
        //private static readonly ILog log = LogManager.GetLogger(typeof(SeedDataMildd));
        public static void UseSeedDataMildd(this IApplicationBuilder app, DBContext myContext, string webRootPath)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            try
            {
                if (Appsettings.app("AppSettings", "SeedDBEnabled").ObjToBool() || Appsettings.app("AppSettings", "SeedDBDataEnabled").ObjToBool())
                {
                    DBSeed.SeedAsync(myContext, webRootPath).Wait();
                }
            }
            catch (Exception e)
            {
                //log.Error($"Error occured seeding the Database.\n{e.Message}");
                throw;
            }
        }
    }
}
