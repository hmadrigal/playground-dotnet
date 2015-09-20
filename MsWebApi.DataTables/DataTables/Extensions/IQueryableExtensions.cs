using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using DataTables.Models;

namespace DataTables.Extensions
{
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Computes a DataTables response based on the request. This response is compatible with an array of arrays
        /// </summary>
        /// <remarks>
        /// This response is compatible with an array of arrays
        /// </remarks>
        /// <typeparam name="TEntity">Entity to be returned in the data</typeparam>
        /// <param name="query">Initial data source. It will be part of the response after computations</param>
        /// <param name="request">Holds information about the request</param>
        /// <param name="getEntityFieldNamesFunc">Function which provides a sequence of fields of the entity to be used</param>
        /// <param name="getEntityAsEnumerableFunc">Function which converts an entity to an array</param>
        /// <returns></returns>
        public static DataTableResponse GetDataTableResponse<TEntity>(this IEnumerable<TEntity> query, DataTableRequest request,
            Func<TEntity, IEnumerable<string>> getEntityFieldNamesFunc, Func<TEntity, System.Collections.IEnumerable> getEntityAsEnumerableFunc)
        {
            // When using Arrays set the columns data before performing operations.
            SetColumnData(request, getEntityFieldNamesFunc);

            var response = GetDataTableResponse(ref query, request);

            // Converts the result compatible with an array (required by default for DataTables)
            response.Data = query.Select(getEntityAsEnumerableFunc);
            return response;
        }

        /// <summary>
        /// Computes a DataTables response based on the request. This response is compatible with an array of objects.
        /// </summary>
        /// <remarks>
        /// This response is compatible with an array of objects.
        /// </remarks>
        /// <typeparam name="TEntity">Entity to be returned in the data</typeparam>
        /// <param name="query">Initial data source. It will be part of the response after computations</param>
        /// <param name="request">Holds information about the request</param>
        /// <returns></returns>
        public static DataTableResponse GetDataTableResponse<TEntity>(this IEnumerable<TEntity> query, DataTableRequest request)
        {
            // When using Arrays set the columns data before performing operations.
            var response = GetDataTableResponse(ref query, request);

            // Converts the result compatible with an array (required by default for DataTables)
            response.Data = query;
            return response;
        }

        private static DataTableResponse GetDataTableResponse<TEntity>(ref IEnumerable<TEntity> query, DataTableRequest request)
        {
            var response = new DataTableResponse();
            // Setting up response
            response.Draw = request.Draw;
            response.RecordsTotal = query.Count();

            // sorting
            query = query.OrderBy(string.Join(",", request.Order.Select(o => o.ToExpression(request))));

            // search
            if (request.Search != null && !string.IsNullOrEmpty(request.Search.Value))
            {
                query = query.Where(request.Search.ToExpression(request));
            }

            // filtering


            // Counting results
            response.RecordsFiltered = query.Count();

            // Returning page (subset of filtered records)
            if (request.Start.HasValue && request.Start.Value > 0)
                query = query.Skip(request.Start.Value);
            if (request.Length.HasValue && request.Length.Value >= 0)
                query = query.Take(request.Length.Value);
            return response;
        }

        private static void SetColumnData<TEntity>(DataTableRequest request, Func<TEntity, IEnumerable<string>> func)
        {
            SetColumnData(request, func(default(TEntity)).ToArray());
        }

        private static void SetColumnData(DataTableRequest request, params string[] fields)
        {
            for (int index = 0; index < fields.Length && index < request.Columns.Count; index++)
            {
                var fieldIndex = 0;
                if (int.TryParse(request.Columns[index].Data, out fieldIndex))
                    request.Columns[index].Data = fields[fieldIndex];
            }
        }
    }
}
