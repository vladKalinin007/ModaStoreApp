using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModaStore.Application.DTOs.Identity;
using ModaStore.Domain.Entities.Identity;
using ModaStore.Application.Features.Identity.Authentication.Commands.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace ModaStore.API.Controllers.OData;

public class AuthenticationController : BaseODataController
{
    private readonly IMediator _mediator;
    
    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [SwaggerOperation(Summary = "Login", OperationId = "Login")]
    [HttpPost("Login")]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        var result = await _mediator.Send(new LoginCommand() { Model = model });
        return Ok(result);
    }
    
    [SwaggerOperation(Summary = "Register", OperationId = "Register")]
    [HttpPost("Register")]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.OK)]   
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterDto model)
    {
        var result = await _mediator.Send(new RegisterCommand() { Model = model });
        return Ok(result);
    }
    
    // [SwaggerOperation(Summary = "Logout", OperationId = "Logout")]
    // [HttpPost("Logout")]
    // [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    // [ProducesResponseType((int)HttpStatusCode.OK)]
    // [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    // public async Task<IActionResult> Logout()
    // {
    //     await _mediator.Send(new LogoutCommand());
    //     return Ok();
    // }
    //
    // [SwaggerOperation(Summary = "Forgot password", OperationId = "ForgotPassword")]
    // [HttpPost("ForgotPassword")]
    // [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    // [ProducesResponseType((int)HttpStatusCode.OK)]
    // [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    // public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto model)
    // {
    //     await _mediator.Send(new ForgotPasswordCommand<ForgotPasswordDto, AppUser>(model));
    //     return Ok();
    // }
    //
    // [SwaggerOperation(Summary = "Reset password", OperationId = "ResetPassword")]
    // [HttpPost("ResetPassword")]
    // [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    // [ProducesResponseType((int)HttpStatusCode.OK)]
    // [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    // public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
    // {
    //     await _mediator.Send(new ResetPasswordCommand<ResetPasswordDto, AppUser>(model));
    //     return Ok();
    // }
    //
    // [SwaggerOperation(Summary = "Confirm email", OperationId = "ConfirmEmail")]
    // [HttpPost("ConfirmEmail")]
    // [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    // [ProducesResponseType((int)HttpStatusCode.OK)]
    // [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    // public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailDto model)
    // {
    //     await _mediator.Send(new ConfirmEmailCommand<ConfirmEmailDto, AppUser>(model));
    //     return Ok();
    // }
    //
    // [SwaggerOperation(Summary = "Check email exist", OperationId = "CheckEmailExist")]
    // [HttpPost("CheckEmailExist")]
    // [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    // [ProducesResponseType((int)HttpStatusCode.OK)]
    // [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    // public async Task<IActionResult> CheckEmailExist([FromBody] CheckEmailExistDto model)
    // {
    //     var result = await _mediator.Send(new CheckEmailExistQuery<CheckEmailExistDto, AppUser>(model));
    //     return Ok(result);
    // }
    //
    // [SwaggerOperation(Summary = "Check username exist", OperationId = "CheckUsernameExist")]
    // [HttpPost("CheckUsernameExist")]
    // [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    // [ProducesResponseType((int)HttpStatusCode.OK)]
    // [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    // public async Task<IActionResult> CheckUsernameExist([FromBody] CheckUsernameExistDto model)
    // {
    //     var result = await _mediator.Send(new CheckUsernameExistQuery<CheckUsernameExistDto, AppUser>(model));
    //     return Ok(result);
    // }
    
    
}