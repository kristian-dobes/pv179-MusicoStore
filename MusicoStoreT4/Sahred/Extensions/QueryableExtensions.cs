using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shared.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<List<T>> WhereAsync<T>(
        this IQueryable<T> query,
        Expression<Func<T, bool>> predicate)
        {
            return await query.Where(predicate).ToListAsync();
        }
    }
}
