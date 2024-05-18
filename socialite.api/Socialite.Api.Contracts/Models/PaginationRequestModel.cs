namespace Socialite.Api.Contracts.Models;

/// <summary>
/// Модель пагинации
/// </summary>
public class PaginationRequestModel
{
    /// <summary>
    /// Номер страницы
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// Размер страницы
    /// </summary>
    public int PageSize { get; set; }
}