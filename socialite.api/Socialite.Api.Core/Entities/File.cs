using Socialite.Api.Core.Exceptions;

namespace Socialite.Api.Core.Entities;

/// <summary>
/// Файл
/// </summary>
public class File : EntityBase
{
    private string _name;
    private string _address;
    private string _weight;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name">Название файла</param>
    /// <param name="address">Адрес файла</param>
    /// <param name="weight">Вес</param>
    public File(
        string name,
        string address,
        string weight)
    {
        Name = name;
        Address = address;
        Weight = weight;
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
    /// Адрес файла
    /// </summary>
    public string Address 
    { 
        get => _address;
        set => _address = value
            ?? throw new RequiredFieldIsEmpty("Адрес файла");
    }

    /// <summary>
    /// Вес
    /// </summary>
    public string Weight 
    {
        get => _weight;
        set => _weight = value
            ?? throw new RequiredFieldIsEmpty("Вес файла");
    }

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