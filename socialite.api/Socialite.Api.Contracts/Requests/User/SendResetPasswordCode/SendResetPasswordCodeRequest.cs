using System.ComponentModel.DataAnnotations;

namespace Socialite.Api.Contracts.Requests.User.SendResetPasswordCode;

/// <summary>
/// Запрос на отправку кода для сброса пароля
/// </summary>
public class SendResetPasswordCodeRequest
{
    /// <summary>
    /// Email
    /// </summary>
    [Required]
    [DataType(DataType.EmailAddress)] 
    public string Email { get; set; }
}