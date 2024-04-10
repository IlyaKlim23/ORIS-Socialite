using MediatR;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Core.Exceptions;
using Socialite.Api.Core.Interfaces;

namespace Socialite.Api.Core.Requests.Subscribers.Unsubscribe;

/// <summary>
/// Обработчик запроса <see cref="UnsubscribeCommand"/>
/// </summary>
public class UnsubscribeCommandHandler : IRequestHandler<UnsubscribeCommand>
{
    private readonly IUserService _userService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userService">Сервис для работы с пользователем</param>
    public UnsubscribeCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(UnsubscribeCommand request, CancellationToken cancellationToken)
    {
        var currentUser = await _userService.GetUsersAsQueryable()
            .Include(x => x.SubscribedTo)
            .FirstOrDefaultAsync(x => x.Id == request.CurrentUserId, cancellationToken)
            ?? throw new EntityNotFoundException<Entities.User>(request.CurrentUserId);

        var userToRemove = currentUser.SubscribedTo
            .FirstOrDefault(x => x.Id == request.UserToUnsubscribeId)
            ?? throw new EntityNotFoundException<Entities.User>($"Не найден пользователь в подписках и идентификатором: {request.UserToUnsubscribeId}");

        currentUser.SubscribedTo.Remove(userToRemove);

        await _userService.UpdateUserAsync(currentUser);
        
        return default;
    }
}