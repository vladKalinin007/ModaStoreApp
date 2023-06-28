using MediatR;
using ModaStore.Application.DTOs.Identity;

namespace ModaStore.Application.Features.Identity.Authentication.Commands.Models;

public class LoginCommand : IRequest<UserDto>
{
    public LoginDto Model { get; set; }
}