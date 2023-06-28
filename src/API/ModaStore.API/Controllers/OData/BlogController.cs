using MediatR;

namespace ModaStore.API.Controllers.OData;

public class BlogController
{
    private readonly IMediator _mediator;
    
    public BlogController(IMediator mediator)
    {
        _mediator = mediator;
    }
}