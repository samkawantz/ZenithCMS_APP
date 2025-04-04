
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // If you are using Session
using ZenithCMS.Service;
public class AccountController : Controller
{
    private readonly UserService _userService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AccountController(UserService userService, IHttpContextAccessor httpContextAccessor)
    {
        _userService = userService;
        _httpContextAccessor = httpContextAccessor;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = _userService.Authenticate(username, password);
        if (user != null)
        {
            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("UserRole", user.Role);

            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Invalid username or password";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(string username, string email, string password, string role = "User")
    {
        _userService.Register(username, email, password, role);
        return RedirectToAction("Login");
    }
}