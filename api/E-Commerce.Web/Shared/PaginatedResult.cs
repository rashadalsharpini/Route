namespace Shared;

public class PaginatedResult<TEntity>
{
    public PaginatedResult(int pageindex, int pagesize, int count, IEnumerable<TEntity> data)
    {
        PageIndex = pageindex;
        PageSize = pagesize;
        PageCount = count;
        Data = data;
    }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int PageCount { get; set; }
    public IEnumerable<TEntity> Data { get; set; }
}