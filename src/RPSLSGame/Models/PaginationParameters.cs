using System.ComponentModel.DataAnnotations;

namespace RPSLSGame.Models;

public class PaginationParameters
{
    private const int MaxPageSize = 100;

    /// <summary>
    /// The page number for pagination.
    /// </summary>
    [Range(1, MaxPageSize, ErrorMessage = "Page number must be greater than zero and less than 100.")]
    public int PageNumber { get; set; } = 1;

    /// <summary>
    /// The number of records per page.
    /// </summary>
    [Range(1, MaxPageSize, ErrorMessage = "Page size must be greater than zero and less than 100.")]
    public int PageSize { get; set; } = 10;
}
