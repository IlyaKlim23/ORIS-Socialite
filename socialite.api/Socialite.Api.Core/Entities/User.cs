﻿using Microsoft.AspNetCore.Identity;
using Socialite.Api.Core.Exceptions;

namespace Socialite.Api.Core.Entities;

/// <summary>
/// Пользователь
/// </summary>
public class User: IdentityUser<Guid>
{
    private string _firstName;
    private string _lastName;
    
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
}