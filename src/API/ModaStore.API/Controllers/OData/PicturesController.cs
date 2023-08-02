using MediatR;

namespace ModaStore.API.Controllers.OData;

public class PicturesController : BaseODataController
{
    private readonly IMediator _mediator;
    
    public PicturesController(IMediator mediator)
    {
        _mediator = mediator;
    }
}