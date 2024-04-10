using MediatR;
using Socialite.Api.Core.Exceptions;
using Socialite.Api.Core.Interfaces;

namespace Socialite.Api.Core.Requests.Subscribers.Subscribe;

/// <summary>
/// Обработчик запроса на подписку
/// </summary>
public class SubscribeCommandHandler: IRequestHandler<SubscribeCommand>
{
    private readonly IUserService _userService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userService">Сервис для работы с пользователем</param>
    public SubscribeCommandHandler(
        IUserService userService)
    {
        _userService = userService;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(SubscribeCommand request, CancellationToken cancellationToken)
    {
        var currentUser = await _userService.FindUserByIdAsync(request.CurrentUserId)
            ?? throw new EntityNotFoundException<Entities.User>(request.CurrentUserId);

        var subscribedTo = await _userService.FindUserByIdAsync(request.SubscribedToId)
            ?? throw new EntityNotFoundException<Entities.User>(request.SubscribedToId);
        
        currentUser.SubscribedTo.Add(subscribedTo);

        await _userService.UpdateUserAsync(currentUser);

        return default;
    }
}