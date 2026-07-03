using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio_Project.Data;
using Portfolio_Project.Models;

namespace Portfolio_Project.Pages.Admin.Projects;

public class EditModel : PageModel
{
    private readonly PortfolioDbContext _context;

    public EditModel(PortfolioDbContext context)
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

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var slugExists = await _context.Projects
    .AnyAsync(project => project.Slug == Project.Slug && project.Id != Project.Id);

        if (slugExists)
        {
            ModelState.AddModelError("Project.Slug", "This slug is already used by another project.");
            return Page();
        }

        _context.Attach(Project).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            var exists = await _context.Projects.AnyAsync(project => project.Id == Project.Id);

            if (!exists)
            {
                return NotFound();
            }

            throw;
        }

        return RedirectToPage("./Index");
    }
}
