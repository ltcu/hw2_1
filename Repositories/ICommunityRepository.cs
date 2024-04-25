using Reddit.Models;

namespace Reddit.Repositories
{
    public interface ICommunityRepository
    {
        PagedList<Community> GetAll(GetCommunitiesRequestModel request);
    }
}
