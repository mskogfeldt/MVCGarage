using System.Linq.Expressions;

namespace MVCGarage
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> OrderAscOrDesc<T, Tkey>(this IEnumerable<T> query, bool desc, Expression<Func<T, Tkey>> keySelector)
        {            
            if (desc)
                return query.AsQueryable().OrderByDescending(keySelector);
            else
                return query.AsQueryable().OrderBy(keySelector);
        }
    }
}
