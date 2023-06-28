using MediatR;
using ModaStore.Application.DTOs.Identity;
using ModaStore.Application.Features.Identity.User.Commands.Models;

namespace ModaStore.Application.Features.Identity.User.Commands.Handlers;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
{
    public Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}