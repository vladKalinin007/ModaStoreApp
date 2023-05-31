using MediatR;
using ModaStore.Domain.Models.Catalog;

namespace ModaStore.API.Application.Commands.Models;

public class GetAllCategoriesCommand : IRequest<List<Category>>
{
    
}