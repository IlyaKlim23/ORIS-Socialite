using Socialite.Api.Core.Exceptions;

namespace Socialite.Api.Core.Entities;

/// <summary>
/// Комментарий
/// </summary>
public class Comment : EntityBase
{
    private User _owner;
    private Post _post;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="text">Текст комментария</param>
    /// <param name="createDate">Дата и время создания</param>
    /// <param name="owner">Владелец</param>
    /// <param name="post">Пост</param>
    public Comment(
        string text,
        DateTime createDate,
        User owner,
        Post post)
    {
        Text = text;
        CreateDate = createDate;
        Owner = owner;
        Post = post;
    }
    
    /// <summary>
    /// Конструктор
    /// </summary>
    private Comment()
    {
    }

    /// <summary>
    /// Дата и время создания
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// Текст комментария
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Владелец
    /// </summary>
    public Guid OwnerId { get; set; }

    /// <summary>
    /// Пост
    /// </summary>
    public Guid PostId { get; set; }

    /// <summary>
    /// Владелец
    /// </summary>
    public User Owner
    {
        get => _owner;
        set
        {
            OwnerId = value?.Id
                ?? throw new RequiredFieldIsEmpty("Владелец");
            _owner = value;
        }
    }

    /// <summary>
    /// Пост
    /// </summary>
    public Post Post
    {
        get => _post;
        set
        {
            PostId = value?.Id
                ?? throw new RequiredFieldIsEmpty("Пост");
            _post = value;
        }
    }
}