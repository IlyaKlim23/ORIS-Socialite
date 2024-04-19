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
    [Description("Relationship")]
    InRelationship = 0,
    
    /// <summary>
    /// В поиске
    /// </summary>
    [Description("The Search")]
    InTheSearch = 1,
    
    /// <summary>
    /// Одинок
    /// </summary>
    [Description("Alone")]
    Alone = 2,
    
    /// <summary>
    /// В браке
    /// </summary>
    [Description("Marriage")]
    InMarriage = 3
}