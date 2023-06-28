using MediatR;
using ModaStore.Application.DTOs.Identity;

namespace ModaStore.Application.Features.Identity.Authentication.Commands.Models;

public class RegisterCommand : IRequest<UserDto>
{
    public RegisterDto Model { get; set; }
}