namespace Socialite.Api.Contracts.Requests.Comments.GetComments;

/// <summary>
/// Запрос на получение комментариев
/// </summary>
public class GetCommentsRequest
{
    /// <summary>
    /// Номер пакета с комментариями
    /// </summary>
    public int BucketNumber { get; set; }
    
    /// <summary>
    /// Кол-во записей
    /// </summary>
    public int Count { get; set; }
}