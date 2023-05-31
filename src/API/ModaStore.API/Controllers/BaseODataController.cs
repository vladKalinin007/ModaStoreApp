using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;

// using Grand.Api.Filters;
// using Grand.Api.ModaStore.Infrastructure;




namespace ModaStore.API.Controllers;

// [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ODataRouteComponent]
[Route("odata/[controller]")]
// [ApiExplorerSettings(IgnoreApi = false, GroupName = "v1")]
// [AuthorizeApiAdmin]
// [ServiceFilter(typeof(ModelValidationAttribute))]
public class BaseODataController : ODataController
{
    public override ForbidResult Forbid()
    {
        return new ForbidResult(JwtBearerDefaults.AuthenticationScheme);
    }
}