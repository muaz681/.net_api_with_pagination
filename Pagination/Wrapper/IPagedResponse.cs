namespace FinalApi.Pagination.Wrapper
{
    public interface IPagedResponse
    {
        Uri FirstPage { get; set; }
        Uri LastPage { get; set; }
        Uri NextPage { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
        Uri PreviousPage { get; set; }
        int TotalPages { get; set; }
        int TotalRecords { get; set; }
    }
}