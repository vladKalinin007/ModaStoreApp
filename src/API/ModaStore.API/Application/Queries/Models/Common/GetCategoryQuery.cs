using MediatR;
using ModaStore.API.Dto.Catalog;

namespace ModaStore.API.Application.Queries.Models.Common;

public class GetCategoryQuery : IRequest<IReadOnlyList<CategoryDto>> { }