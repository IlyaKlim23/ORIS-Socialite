using Socialite.Api.Core.Exceptions;

namespace Socialite.Api.Core.Entities;

/// <summary>
/// Пост
/// </summary>
public class Post : EntityBase
{
    private User _owner;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="ownerId">Создатель</param>
    /// <param name="createDate">Дата и время создания</param>
    public Post(Guid ownerId, DateTime createDate)
    {
        OwnerId = ownerId;
        CreateDate = createDate;
        LikedUsers = new List<User>();
        Comments = new List<Comment>();
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    private Post()
    {
    }
    
    /// <summary>
    /// Описание
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Дата и время создания
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// Создатель
    /// </summary>
    public Guid OwnerId { get; set; }

    /// <summary>
    /// Создатель
    /// </summary>
    public User Owner
    {
        get => _owner;
        set
        {
            OwnerId = value?.Id 
                ?? throw new RequiredFieldIsEmpty("Создатель");
            _owner = value;
        }
    }

    /// <summary>
    /// Лайкнувшие пользователи
    /// </summary>
    public List<User>? LikedUsers { get; set; }

    /// <summary>
    /// Файлы
    /// </summary>
    public List<File>? Files { get; set; }

    /// <summary>
    /// Комментарии
    /// </summary>
    public List<Comment>? Comments { get; set; }
}