using FinalApi.Pagination.Filter;

namespace FinalApi.Pagination.Services.IService
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
