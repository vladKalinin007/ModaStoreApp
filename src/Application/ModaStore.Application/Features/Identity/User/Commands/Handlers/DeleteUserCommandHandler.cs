using MediatR;
using ModaStore.Application.DTOs.Identity;
using ModaStore.Application.Features.Identity.User.Commands.Models;

namespace ModaStore.Application.Features.Identity.User.Commands.Handlers;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, UserDto>
{
    public Task<UserDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}