﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using aspnetcoreDemo.Core.Common;

namespace aspnetcoreDemo.Core.Model
{
    public class DBSeed
    {

        public static async Task SeedAsync(DBContext myContext, string WebRootPath)
        {
            try
            {
                // 创建数据库
                Console.WriteLine($"Create Database(The Db Id:{DBContext.ConnId})...");
                myContext.Db.DbMaintenance.CreateDatabase();
                Console.WriteLine($"Database created successfully!");


                // 创建数据库表，遍历指定命名空间下的class，
                // 注意不要把其他命名空间下的也添加进来。
                Console.WriteLine("Create Tables...");
                var modelTypes = from t in Assembly.GetExecutingAssembly().GetTypes()
                                 where t.IsClass && t.Namespace == "aspnetcoreDemo.Core.Model.BizModels"
                                 select t;
                modelTypes.ToList().ForEach(t =>
                {
                    // 这里只支持添加表，不支持删除
                    if (!myContext.Db.DbMaintenance.IsAnyTable(t.Name))
                    {
                        Console.WriteLine(t.Name);
                        myContext.Db.CodeFirst.InitTables(t);
                    }
                });
                Console.WriteLine($"Tables created successfully!");
                Console.WriteLine();

            }
            catch (Exception ex)
            {
                throw new Exception("错误：" + ex.Message);
            }
        }
    }
}