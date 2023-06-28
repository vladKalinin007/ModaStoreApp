//
//
// using System.Net;
// using MediatR;
// using Microsoft.AspNetCore.Mvc;
// using ModaStore.API.Dto.Customers;
// using Swashbuckle.AspNetCore.Annotations;
//
// namespace ModaStore.API.Controllers.OData;
//
// public class AccountController : BaseODataController
// {
//     private readonly IMediator _mediator;
//     
//     public AccountController(IMediator mediator)
//     {
//         _mediator = mediator;
//     }
//     
//     [HttpGet]
//     public async Task<IActionResult> Get()
//     {
//         return Ok(await _mediator.Send(new GetCurrentUserQuery<UserDto, AppUser>()));
//     }
//     
//     [SwaggerOperation(Summary = "Create user", OperationId = "CreateUser")]
//     [HttpPost]
//     [ProducesResponseType((int)HttpStatusCode.Forbidden)]
//     [ProducesResponseType((int)HttpStatusCode.OK)]
//     [ProducesResponseType((int)HttpStatusCode.BadRequest)]
//     public async Task<IActionResult> Post([FromBody] UserDto model)
//     {
//         model = await _mediator.Send(new CreateUserCommand<UserDto, AppUser>(model));
//         return Ok(model);
//     }
//     
//     [SwaggerOperation(Summary = "Update user", OperationId = "UpdateUser")]
//     [HttpPut]
//     [ProducesResponseType((int)HttpStatusCode.Forbidden)]
//     [ProducesResponseType((int)HttpStatusCode.OK)]
//     [ProducesResponseType((int)HttpStatusCode.BadRequest)]
//     public async Task<IActionResult> Put([FromBody] UserDto model)
//     {
//         model = await _mediator.Send(new UpdateUserCommand<UserDto, AppUser>(model));
//         return Ok(model);
//     }
//     
//     [SwaggerOperation(Summary = "Delete user", OperationId = "DeleteUser")]
//     [HttpDelete]
//     [ProducesResponseType((int)HttpStatusCode.Forbidden)]
//     [ProducesResponseType((int)HttpStatusCode.OK)]
//     [ProducesResponseType((int)HttpStatusCode.BadRequest)]
//     public async Task<IActionResult> Delete([FromBody] UserDto model)
//     {
//         await _mediator.Send(new DeleteUserCommand<UserDto, AppUser>(model));
//         return Ok();
//     }
//     
//     [SwaggerOperation(Summary = "Change password", OperationId = "ChangePassword")]
//     [HttpPost("ChangePassword")]
//     [ProducesResponseType((int)HttpStatusCode.Forbidden)]
//     [ProducesResponseType((int)HttpStatusCode.OK)]
//     [ProducesResponseType((int)HttpStatusCode.BadRequest)]
//     public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto model)
//     {
//         await _mediator.Send(new ChangePasswordCommand<ChangePasswordDto, AppUser>(model));
//         return Ok();
//     }
//     
//     [SwaggerOperation(Summary = "Reset password", OperationId = "ResetPassword")]
//     [HttpPost("ResetPassword")]
//     [ProducesResponseType((int)HttpStatusCode.Forbidden)]
//     [ProducesResponseType((int)HttpStatusCode.OK)]
//     [ProducesResponseType((int)HttpStatusCode.BadRequest)]
//     public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
//     {
//         await _mediator.Send(new ResetPasswordCommand<ResetPasswordDto, AppUser>(model));
//         return Ok();
//     }
//     
//     [SwaggerOperation(Summary = "Confirm email", OperationId = "ConfirmEmail")]
//     [HttpPost("ConfirmEmail")]
//     [ProducesResponseType((int)HttpStatusCode.Forbidden)]
//     [ProducesResponseType((int)HttpStatusCode.OK)]
//     [ProducesResponseType((int)HttpStatusCode.BadRequest)]
//     public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailDto model)
//     {
//         await _mediator.Send(new ConfirmEmailCommand<ConfirmEmailDto, AppUser>(model));
//         return Ok();
//     }
//     
//     [SwaggerOperation(Summary = "Check email exist", OperationId = "CheckEmailExist")]
//     [HttpPost("CheckEmailExist")]
//     [ProducesResponseType((int)HttpStatusCode.Forbidden)]
//     [ProducesResponseType((int)HttpStatusCode.OK)]
//     public async Task<IActionResult> CheckEmailExist([FromBody] CheckEmailExistDto model)
//     {
//         return Ok(await _mediator.Send(new CheckEmailExistQuery<CheckEmailExistDto, AppUser>(model)));
//     }
//     
//     [SwaggerOperation(Summary = "Forgot password", OperationId = "ForgotPassword")]
//     [HttpPost("ForgotPassword")]
//     [ProducesResponseType((int)HttpStatusCode.Forbidden)]
//     [ProducesResponseType((int)HttpStatusCode.OK)]
//     [ProducesResponseType((int)HttpStatusCode.BadRequest)]
//     public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto model)
//     {
//         await _mediator.Send(new ForgotPasswordCommand<ForgotPasswordDto, AppUser>(model));
//         return Ok();
//     }
//     
//     [SwaggerOperation(Summary = "Login", OperationId = "Login")]
//     [HttpPost("Login")]
//     [ProducesResponseType((int)HttpStatusCode.Forbidden)]
//     [ProducesResponseType((int)HttpStatusCode.OK)]
//     [ProducesResponseType((int)HttpStatusCode.BadRequest)]
//     public async Task<IActionResult> Login([FromBody] LoginDto model)
//     {
//         return Ok(await _mediator.Send(new LoginQuery<LoginDto, AppUser>(model)));
//     }
//     
//     [SwaggerOperation(Summary = "Logout", OperationId = "Logout")]
//     [HttpPost("Logout")]
//     [ProducesResponseType((int)HttpStatusCode.Forbidden)]
//     [ProducesResponseType((int)HttpStatusCode.OK)]
//     public async Task<IActionResult> Logout()
//     {
//         await _mediator.Send(new LogoutCommand());
//         return Ok();
//     }
//     
//     
//     
//     
// }