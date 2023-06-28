using MediatR;
using ModaStore.Application.DTOs.Customers;
using ModaStore.Application.DTOs.Identity;

namespace ModaStore.Application.Features.Identity.User.Commands.Models;

public class AddUserCommand : IRequest<UserDto>
{
    public UserDto Model { get; set; }
}