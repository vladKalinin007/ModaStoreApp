using MediatR;
using ModaStore.Application.DTOs.Identity;

namespace ModaStore.Application.Features.Identity.User.Commands.Models;

public class DeleteUserCommand: IRequest<bool>, IRequest<UserDto>
{
    public string Email { get; set; }
}