using API.Application.Commands.Models;
using Core.Models.Catalog;
using MediatR;

namespace API.Application.Commands.Handlers;

// public class GetAllCategoriesCommandHandler : IRequestHandler<GetAllCategoriesCommand, List<Category>>
// {
//     public Task<List<Category>> Handle(GetAllCategoriesCommand request, CancellationToken cancellationToken)
//     {
//         throw new NotImplementedException();
//     }
// }