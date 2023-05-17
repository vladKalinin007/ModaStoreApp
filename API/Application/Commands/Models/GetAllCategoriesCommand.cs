using Core.Models.Catalog;
using MediatR;

namespace API.Application.Commands.Models;

public class GetAllCategoriesCommand : IRequest<List<Category>>
{
    
}