using System.ComponentModel;
using System.Reflection;
using Socialite.Api.Contracts.Enums;

namespace Socialite.Api.Core.Extensions;

/// <summary>
/// Расширения для <see cref="Enum"/>
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Получить описание из <see cref="DescriptionAttribute"/>
    /// </summary>
    /// <param name="source">Enum</param>
    /// <returns>Описание</returns>
    public static string? GetDescription(this Enum source)
    {
        var member = source.GetType().GetMember(source.ToString()).FirstOrDefault();
        var attribute = member?.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();

        return (attribute as DescriptionAttribute)?.Description;
    }

    /// <summary>
    /// Получить имя свойства по <see cref="DescriptionAttribute"/>
    /// </summary>
    /// <param name="type"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    public static string? GetByDescription(this Type type, string description)
    {
        string? GetDesc(MemberInfo member)
        {
            var attr = member.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();
            
            return (attr as DescriptionAttribute)?.Description;
        }

        var member = type.GetMembers().FirstOrDefault(
            x => (GetDesc(x) ?? string.Empty).ToLower() == description.ToLower());

        return member?.Name;
    }
}