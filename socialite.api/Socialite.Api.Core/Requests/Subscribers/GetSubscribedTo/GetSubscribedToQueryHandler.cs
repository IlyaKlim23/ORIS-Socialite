using MediatR;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Contracts.Requests.Subscribers;
using Socialite.Api.Contracts.Requests.Subscribers.GetSubscribedTo;
using Socialite.Api.Core.Exceptions;
using Socialite.Api.Core.Interfaces;

namespace Socialite.Api.Core.Requests.Subscribers.GetSubscribedTo;

/// <summary>
/// Обработчик запроса <see cref="GetSubscribedToQuery"/>
/// </summary>
public class GetSubscribedToQueryHandler : IRequestHandler<GetSubscribedToQuery, GetSubscribedToResponse>
{
    private readonly IUserService _userService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userService">Сервис для работы с пользователем</param>
    public GetSubscribedToQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    /// <inheritdoc />
    public async Task<GetSubscribedToResponse> Handle(GetSubscribedToQuery request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUsersAsQueryable()
            .Include(x => x.SubscribedTo)
            .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken)
            ?? throw new EntityNotFoundException<Entities.User>(request.UserId);

        var result = user.SubscribedTo
            .Select(x => new UserBaseInfoModel
            {
                Id = x.Id,
                UserName = x.UserName,
                FirstName = x.FirstName,
                LastName = x.LastName,
            })
            .ToList();
        
        return new GetSubscribedToResponse(result.Count, result);
    }
}