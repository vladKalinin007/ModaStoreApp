using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
// using Grand.Api.Filters;
// using Grand.Api.Infrastructure;




namespace API.Controllers;

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