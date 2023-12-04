namespace FindMyCar.Core;
/// <summary>
/// PagedResult reprsents a single page in a paginated result.
/// </summary>
public class PagedResult<T> where T : class
{
    /// <summary>
    /// The current page.
    /// </summary>
    public int Page { get; set; } = 1;
    /// <summary>
    /// Maximum number of results on a single page.
    /// </summary>
    public int PageSize { get; set; } = 100;
    /// <summary>
    /// Total number of records.
    /// </summary>
    public int Total { get; set; } = 0;
    /// <summary>
    /// Results found at the current page.
    /// </summary>
    public List<T> Result { get; set; } = new List<T>();
}
