using MediatR;
using ModaStore.Application.DTOs.Identity;

namespace ModaStore.Application.Features.Identity.User.Commands.Models;

public class UpdateUserCommand : IRequest<UserDto>
{
    public UserDto Model { get; set; }
}