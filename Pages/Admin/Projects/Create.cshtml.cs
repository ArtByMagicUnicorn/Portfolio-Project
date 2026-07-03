using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio_Project.Data;
using Portfolio_Project.Models;
using Microsoft.EntityFrameworkCore;
using Portfolio_Project.Helpers;

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
        if (string.IsNullOrWhiteSpace(Project.Slug))
        {
            Project.Slug = SlugHelper.GenerateSlug(Project.Title);
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        var slugExists = await _context.Projects
            .AnyAsync(project => project.Slug == Project.Slug);

        if (slugExists)
        {
            ModelState.AddModelError("Project.Slug", "This slug is already used by another project.");
            return Page();
        }

        Project.CreatedAt = DateTime.UtcNow;

        _context.Projects.Add(Project);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Projects/Index");
    }
}
