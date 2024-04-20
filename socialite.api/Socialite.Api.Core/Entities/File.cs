using Socialite.Api.Core.Exceptions;

namespace Socialite.Api.Core.Entities;

/// <summary>
/// Файл
/// </summary>
public class File : EntityBase
{
    private string _name;
    private long _weight;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name">Название файла</param>
    /// <param name="weight">Вес файла в байтах</param>
    /// <param name="contentType">Тип контента</param>
    public File(
        string name,
        long weight,
        string contentType)
    {
        Name = name;
        Weight = weight;
        ContentType = contentType;
        NameWithoutExtension = name.Split('.').FirstOrDefault();
        Extension = name.Split('.').LastOrDefault();
        Users = new List<User>();
        Posts = new List<Post>();
    }
    
    /// <summary>
    /// Название файла
    /// </summary>
    public string Name 
    { 
        get => _name;
        set => _name = value
            ?? throw new RequiredFieldIsEmpty("Название файла");
    }

    /// <summary>
    /// Вес
    /// </summary>
    public long Weight 
    {
        get => _weight;
        set => _weight = value;
    }
    
    /// <summary>
    /// Тип контента
    /// </summary>
    public string ContentType { get; set; }

    /// <summary>
    /// Наименование файла без расширения
    /// </summary>
    public string? NameWithoutExtension { get; private set; }

    /// <summary>
    /// Расширение файла
    /// </summary>
    public string? Extension { get; private set; }

    /// <summary>
    /// Пользователи
    /// </summary>
    public List<User>? Users { get; set; }

    /// <summary>
    /// Посты
    /// </summary>
    public List<Post> Posts { get; set; }
}