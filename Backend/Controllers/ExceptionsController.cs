using Backend.Data;
using Backend.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

public class ExceptionsController(DataContext context) : BaseApiController
{
    [Authorize]
    [HttpGet("auth")]
    public ActionResult<string> GetAuth()
    {
        return "Secret string";
    }

    [HttpGet("not-found")]
    public ActionResult<User> GetNotFound()
    {
        var response = context.Users.Find(-1);

        if (response == null) return NotFound();

        return response;
    }

    [HttpGet("server-error")]
    public ActionResult<User> GetServerError()
    {
        var response = context.Users.Find(-1) ?? throw new Exception("Server error");


        return response;
    }

    [HttpGet("bad-request")]
    public ActionResult<string> GetBadRequest()
    {
        return BadRequest("Bad request");
    }
}
