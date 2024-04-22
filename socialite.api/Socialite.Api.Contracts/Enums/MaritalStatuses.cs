using System.ComponentModel;

namespace Socialite.Api.Contracts.Enums;

/// <summary>
/// Семейные положения
/// </summary>
public enum MaritalStatuses
{
    /// <summary>
    /// В отношениях
    /// </summary>
    [Description("В отношениях")]
    InRelationship = 0,
    
    /// <summary>
    /// В поиске
    /// </summary>
    [Description("В поиске")]
    InTheSearch = 1,
    
    /// <summary>
    /// Одинок
    /// </summary>
    [Description("Одинок")]
    Alone = 2,
    
    /// <summary>
    /// В браке
    /// </summary>
    [Description("В браке")]
    InMarriage = 3
}