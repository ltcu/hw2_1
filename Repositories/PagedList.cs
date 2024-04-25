
namespace Reddit.Repositories
{
    public class PagedList<T>
    {
        private PagedList(List<T> items, int page, int pageSize, int totalCount)
        {
            Items = items;
            Page = page;
            PageSize = pageSize;
        }

        public List<T> Items { get; }

        public int Page { get; }

        public int PageSize { get; }

        public static PagedList<T> CreateAsync(IQueryable<T> query, int page, int pageSize)
        {
            var totalCount = query.Count();
            var items = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return new PagedList<T>(items, page, pageSize, totalCount);
        }
    }
}