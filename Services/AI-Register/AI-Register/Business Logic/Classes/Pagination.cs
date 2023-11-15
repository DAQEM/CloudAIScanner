namespace BusinessLogic.Classes;

public class Pagination<T>
{
    public T Data { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
}