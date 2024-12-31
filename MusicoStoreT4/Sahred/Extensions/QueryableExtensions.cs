using System.Linq.Expressions;
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
