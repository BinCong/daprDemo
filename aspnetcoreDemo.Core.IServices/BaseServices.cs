﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using aspnetcoreDemo.Core.Model;
using aspnetcoreDemo.Core.Repository;

namespace aspnetcoreDemo.Core.IServices
{
    public class BaseServices<TEntity>:IBaseServices<TEntity> where TEntity:class,new()
    {
        public IBaseRepository<TEntity> BaseDal;

        public async Task<List<TEntity>> Query()
        {
            return await BaseDal?.Query();
        }

        public async Task<PageModel<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression, 
            int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null)
        {
            return await BaseDal?.QueryPage(whereExpression, intPageIndex, intPageSize, strOrderByFileds);
        }
    }
}
