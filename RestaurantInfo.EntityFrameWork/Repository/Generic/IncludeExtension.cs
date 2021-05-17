using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace RestaurantInfo.EntityFrameWork.Repository.Generic
{
    public static class IncludeExtension

    {
        public static IQueryable<T> MultipleInclude<T>(this IQueryable<T> query,params Expression<Func<T,Object>>[] includes) where T:class
        {
            if(includes != null)
            {
                query = includes.Aggregate(query,
                    (current, include) => current.Include(include));

            } 
            return query;
        }
    }
}
