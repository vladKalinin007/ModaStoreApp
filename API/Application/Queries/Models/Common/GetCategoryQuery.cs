using API.Dto.Catalog;
using MediatR;

namespace API.Application.Queries.Models.Common;

public class GetCategoryQuery : IRequest<IReadOnlyList<CategoryDto>> { }