using Reddit.Models;

namespace Reddit.Repositories
{
    public class CommunityRepository : ICommunityRepository
    {
        private readonly ApplicationDbContext _context;

        public CommunityRepository(ApplicationDbContext applicationDBContext)
        {
            this._context = applicationDBContext;
        }

        public PagedList<Community> GetAll(GetCommunitiesRequestModel request)
        {
            IQueryable<Community> communitiesQueryable = _context.Communities;

            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                communitiesQueryable = communitiesQueryable.Where(p => p.Name.Contains(request.SearchKey) || p.Description.Contains(request.SearchKey));
            }

            bool _isAscending = request.IsAscending ?? false;

            switch (request.SortKey)
            {
                case "createdAt":
                    communitiesQueryable = !_isAscending ? communitiesQueryable.OrderByDescending(p => p.CreateAt) : communitiesQueryable.OrderBy(p => p.CreateAt);
                    break;
                case "postsCount":
                    communitiesQueryable = !_isAscending ? communitiesQueryable.OrderByDescending(p => p.Posts.Count()) : communitiesQueryable.OrderBy(p => p.Posts.Count());
                    break;
                case "subscribersCount":
                    communitiesQueryable = !_isAscending ? communitiesQueryable.OrderByDescending(p => p.Subscribers.Count()) : communitiesQueryable.OrderBy(p => p.Subscribers.Count());
                    break;
                case null:
                    communitiesQueryable = communitiesQueryable.OrderBy(p => p.Id);
                    break;
                case "id":
                    communitiesQueryable = !_isAscending ? communitiesQueryable.OrderByDescending(p => p.Id) : communitiesQueryable.OrderBy(p => p.Id);
                    break;
            }

            return PagedList<Community>.CreateAsync(communitiesQueryable, request.Page, request.PageSize);
        }
    }
}
