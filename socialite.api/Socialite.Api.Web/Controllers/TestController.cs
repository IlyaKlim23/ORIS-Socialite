using Microsoft.AspNetCore.Mvc;

namespace Socialite.Api.Web.Controllers;

public class TestController: BaseController
{
    [HttpGet]
    public int ppp()
    {
        return 1;
    }
}