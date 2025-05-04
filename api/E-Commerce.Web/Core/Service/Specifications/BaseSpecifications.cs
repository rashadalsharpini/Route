using System.Linq.Expressions;
using Domain.Contracts;
using Domain.Models;

namespace Service.Specifications;

abstract class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    protected BaseSpecifications(Expression<Func<TEntity, bool>>? criteriaExpression)
    {
        Criteria = criteriaExpression;
    }

    public Expression<Func<TEntity, bool>>? Criteria { get; private set; }
    public List<Expression<Func<TEntity, object>>> Includes { get; } = [];
    public Expression<Func<TEntity, object>> OrderBy { get; private set; }
    public Expression<Func<TEntity, object>> OrderByDes { get; private set; }

    protected void AddOrderBy(Expression<Func<TEntity, object>> orderByEx) => OrderBy = orderByEx;
    protected void AddOrderByDes(Expression<Func<TEntity, object>> orderByDesEx) => OrderByDes = orderByDesEx;

    protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    public int Take { get; private set; }
    public int Skip { get; private set; }
    public bool IsPagination { get; set; }

    protected void ApplyPagination(int pageSize, int pageIndex)
    {
        IsPagination = true;
        Take = pageSize;
        Skip = pageSize * (pageIndex - 1);
    }
}