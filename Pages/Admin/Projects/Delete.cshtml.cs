using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio_Project.Data;
using Portfolio_Project.Models;

namespace Portfolio_Project.Pages.Admin.Projects;

public class DeleteModel : PageModel
{
    private readonly PortfolioDbContext _context;

    public DeleteModel(PortfolioDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public PortfolioProject Project { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var project = await _context.Projects.FindAsync(id);

        if (project is null)
        {
            return NotFound();
        }

        Project = project;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var project = await _context.Projects.FindAsync(id);

        if (project is null)
        {
            return NotFound();
        }

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}