using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Socialite.Api.Contracts.Enums;
using Socialite.Api.Core.Exceptions;
using Socialite.Api.Core.Extensions;
using Socialite.Api.Core.Interfaces;
using Socialite.Api.S3.Interfaces;
using File = Socialite.Api.Core.Entities.File;

namespace Socialite.Api.Core.Requests.UserProfile.PutCurrentUserInfo;

public class PutCurrentUserInfoCommandHandler : IRequestHandler<PutCurrentUserInfoCommand>
{
    private readonly IDbContext _dbContext;
    private readonly IUserService _userService;
    private readonly IS3Service _s3Service;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext"></param>
    /// <param name="userService"></param>
    /// <param name="s3Service"></param>
    public PutCurrentUserInfoCommandHandler(IDbContext dbContext, IUserService userService, IS3Service s3Service)
    {
        _dbContext = dbContext;
        _userService = userService;
        _s3Service = s3Service;
    }

    public async Task<Unit> Handle(PutCurrentUserInfoCommand request, CancellationToken cancellationToken)
    {
        var innerRequest = request.Request;
        
        var user = await _userService.FindUserByIdAsync(request.UserId)
            ?? throw new EntityNotFoundException<Entities.User>(request.UserId);

        if (innerRequest.AvatarId != null)
        {
            var file = await _dbContext.Files
                .FirstOrDefaultAsync(x => x.Id == innerRequest.AvatarId, cancellationToken)
                ?? throw new EntityNotFoundException<File>(innerRequest.AvatarId.Value);

            user.Avatar = file;
        }

        user.Status = innerRequest.Status;
        user.PlaceOfLiving = innerRequest.PlaceOfLiving;
        user.PlaceOfWork = innerRequest.PlaceOfWork;
        user.PlaceOfStudy = innerRequest.PlaceOfStudy;
        user.MaritalStatus = GetStatus(innerRequest.MaritalStatus);

        await _userService.UpdateUserAsync(user);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return default;
    }

    private MaritalStatuses? GetStatus(string? status)
    {
        if (status == null)
            return null;
        
        var statusName = typeof(MaritalStatuses).GetByDescription(status);

        if (!Enum.TryParse(statusName, out MaritalStatuses result))
            throw new ValidationException("Невалидное семейное положение");

        return result;
    }
}