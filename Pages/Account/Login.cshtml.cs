using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Portfolio_Project.Pages.Account;

public class LoginModel : PageModel
{
    private readonly IConfiguration _configuration;

    public LoginModel(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [BindProperty]
    public string Username { get; set; } = "";

    [BindProperty]
    public string Password { get; set; } = "";

    public string? ErrorMessage { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var adminUsername = _configuration["AdminUser:Username"];
        var adminPassword = _configuration["AdminUser:Password"];

        if (Username != adminUsername || Password != adminPassword)
        {
            ErrorMessage = "Invalid username or password.";
            return Page();
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, Username)
        };

        var identity = new ClaimsIdentity(claims, "PortfolioAuth");
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync("PortfolioAuth", principal);

        return RedirectToPage("/Admin/Projects/Index");
    }
}