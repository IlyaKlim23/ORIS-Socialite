using MediatR;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Contracts.Models;
using Socialite.Api.Contracts.Requests.User.GetUsers;
using Socialite.Api.Core.Interfaces;

namespace Socialite.Api.Core.Requests.User.GetUsers;

/// <summary>
/// Обработчик <see cref="GetUsersQuery"/>
/// </summary>
public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, GetUsersResponse>
{
    private readonly IUserService _userService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userService">Сервис для работы с пользователями</param>
    public GetUsersQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    /// <inheritdoc />
    public async Task<GetUsersResponse> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var innerRequest = request.Request;
        var users = await _userService.Users()
            .Where(x => !string.IsNullOrEmpty(innerRequest.UserName) &&
                        x.UserName!.ToLower().Contains(innerRequest.UserName.ToLower()))
            .Select(x => new UserBaseInfoModel()
            {
                UserId = x.Id,
                AvatarId = x.AvatarId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName
            })
            .Take(innerRequest.CountItems)
            .ToListAsync(cancellationToken);

        return new GetUsersResponse(users);
    }
}