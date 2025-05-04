using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

static class SpecificationEvaluator
{
    public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(IQueryable<TEntity> inputQuery,
        ISpecifications<TEntity, TKey> specifications) where TEntity : BaseEntity<TKey>
    {
        var query = inputQuery;
        if (specifications.Criteria is not null)
            query = query.Where(specifications.Criteria);
        if (specifications.OrderBy is not null)
            query = query.OrderBy(specifications.OrderBy);
        if (specifications.OrderByDes is not null)
            query = query.OrderByDescending(specifications.OrderByDes);
        if (specifications.Includes is not null && specifications.Includes.Count > 0)
            // foreach (var exp in specifications.Includes)
            //      query.Include(exp);
            query = specifications.Includes.Aggregate(query, (current, include)
                => current.Include(include));
        if (specifications.IsPagination)
            query = query.Skip(specifications.Skip).Take(specifications.Take);


        return query;
    }
}