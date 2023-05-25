using API.Application.Queries.Models.Common;
using API.Models;
using AutoMapper;
using Core.Interfaces;
using Core.Models;
using MediatR;

namespace API.Application.Queries.Handlers.Common;

public class GetQueryByIdHandler<D, M> : IRequestHandler<GetQueryById<D, M>, D>
    where D : BaseApiEntityModel
    where M : BaseEntity
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetQueryByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<D> Handle(GetQueryById<D, M> request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Repository<M>().getByIdAsync(request.Id);
        return _mapper.Map<M, D>(entity);
    }
}