using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio_Project.Data;
using Portfolio_Project.Models;

namespace Portfolio_Project.Pages.Admin.Projects;

public class CreateModel : PageModel
{
    private readonly PortfolioDbContext _context;

    public CreateModel(PortfolioDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public PortfolioProject Project { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Project.CreatedAt = DateTime.UtcNow;

        _context.Projects.Add(Project);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Projects/Index");
    }
}
