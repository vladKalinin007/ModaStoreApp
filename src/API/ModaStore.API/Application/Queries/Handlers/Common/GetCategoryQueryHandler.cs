using AutoMapper;
using MediatR;
using ModaStore.API.Application.Queries.Models.Common;
using ModaStore.API.Dto.Catalog;
using ModaStore.Domain.Interfaces;
using ModaStore.Domain.Models.Catalog;

namespace ModaStore.API.Application.Queries.Handlers.Common;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, IReadOnlyList<CategoryDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<IReadOnlyList<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await _unitOfWork.Repository<Category>().ListAllAsync();
        return _mapper.Map<IReadOnlyList<Category>, IReadOnlyList<CategoryDto>>(categories);
    }
}