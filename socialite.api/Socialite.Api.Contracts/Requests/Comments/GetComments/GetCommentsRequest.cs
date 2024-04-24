namespace Socialite.Api.Contracts.Requests.Comments.GetComments;

/// <summary>
/// Запрос на получение комментариев
/// </summary>
public class GetCommentsRequest
{
    /// <summary>
    /// Кол-во записей
    /// </summary>
    public int Count { get; set; }
}