using MediatR;

namespace ModaStore.Application.Features.Identity.User.Queries.Models;

public class CheckEmailExistsQuery : IRequest<bool>
{
    public CheckEmailExistsQuery(string email)
    {
        Email = email;
    }

    public string Email { get; set; }
}