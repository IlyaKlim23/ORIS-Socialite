using Microsoft.AspNetCore.Identity;
using Socialite.Api.Core.Enums;
using Socialite.Api.Core.Exceptions;

namespace Socialite.Api.Core.Entities;

/// <summary>
/// Пользователь
/// </summary>
public class User: IdentityUser<Guid>
{
    private string _firstName;
    private string _lastName;
    private File? _avatar;

    /// <summary>
    /// Конструктор
    /// </summary>
    public User(
        string firstName,
        string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        Subscribers = new List<User>();
        SubscribedTo = new List<User>();
        CreatedPosts = new List<Post>();
        LikedPosts = new List<Post>();
        Comments = new List<Comment>();
    }

    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName 
    { 
        get => _firstName;
        set => _firstName = value 
            ?? throw new RequiredFieldIsEmpty("Имя");
    }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName
    {
        get => _lastName;
        set => _lastName = value
            ?? throw new RequiredFieldIsEmpty("Фамилия");
    }

    /// <summary>
    /// Место жительства
    /// </summary>
    public string? PlaceOfLiving { get; set; }
    
    /// <summary>
    /// Место работы
    /// </summary>
    public string? PlaceOfWork { get; set; }
    
    /// <summary>
    /// Место учебы
    /// </summary>
    public string? PlaceOfStudy { get; set; }

    /// <summary>
    /// Статус
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// Гендер
    /// </summary>
    public Genders? Gender { get; set; }

    /// <summary>
    /// Идентификатор аватара
    /// </summary>
    public Guid? AvatarId { get; set; }

    /// <summary>
    /// Аватар
    /// </summary>
    public File? Avatar
    {
        get => _avatar;
        set
        {
            AvatarId = value?.Id;
            _avatar = value;
        }
    }

    /// <summary>
    /// Подписчики
    /// </summary>
    public List<User> Subscribers { get; set; }

    /// <summary>
    /// Пользователи, на которых подписан текущий пользователь
    /// </summary>
    public List<User> SubscribedTo { get; set; }

    /// <summary>
    /// Созданные посты
    /// </summary>
    public List<Post> CreatedPosts { get; set; }

    /// <summary>
    /// Лайкнутые посты
    /// </summary>
    public List<Post> LikedPosts { get; set; }

    /// <summary>
    /// Комментарии
    /// </summary>
    public List<Comment> Comments { get; set; }
}