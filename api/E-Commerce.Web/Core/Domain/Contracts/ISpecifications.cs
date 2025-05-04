using System.Linq.Expressions;
using Domain.Models;

namespace Domain.Contracts;

public interface ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    public Expression<Func<TEntity, bool>>? Criteria { get; }
    List<Expression<Func<TEntity, object>>> Includes { get; }
    Expression<Func<TEntity, object>> OrderBy { get; }
    Expression<Func<TEntity, object>> OrderByDes { get; }
    int Take { get; }
    int Skip { get; }
    public bool IsPagination { get; set; }
}