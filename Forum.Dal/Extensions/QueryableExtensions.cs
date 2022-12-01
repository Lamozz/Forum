using Forum.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Dynamic.Core;
using System.Text;

namespace Forum.Dal.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PaginateResult<T>> GetPaginationResultAsync<T>(this IQueryable<T> query,
            PaginateRequest paginateRequest)
        {
            query = query.ApplyFilters(paginateRequest.Filter);

            var totalItems = await query.CountAsync();

            query = query.Paginate(paginateRequest);

            query = query.Sort(paginateRequest);

            var items = await query.ToListAsync();

            return new PaginateResult<T>()
            {
                PageIndex = paginateRequest.PageIndex,
                PageSize = paginateRequest.PageSize,
                TotalItems = totalItems,
                Items = items
            };
        }

        private static IQueryable<T> Paginate<T>(this IQueryable<T> query, PaginateRequest paginateRequest)
        {
            return query.Skip(paginateRequest.PageIndex * paginateRequest.PageSize).Take(paginateRequest.PageSize);
        }

        private static IQueryable<T> Sort<T>(this IQueryable<T> query, PaginateRequest paginateRequest)
        {
            if (!string.IsNullOrWhiteSpace(paginateRequest.ColumnNameForSorting))
            {
                query = query.OrderBy(paginateRequest.ColumnNameForSorting + " "
                    + paginateRequest.SortDirection);
            }

            return query;
        }

        private static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, Filter filter)
        {
            if (!(string.IsNullOrEmpty(filter.Path) && string.IsNullOrEmpty(filter.Value)))
            {
                query = query.Where($"title.{nameof(string.Contains)}(@0)", filter.Value);
            }

            return query;
        }
    }
}
