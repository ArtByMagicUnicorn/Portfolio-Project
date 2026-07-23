using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio_Project.Data;
using Portfolio_Project.Models;

namespace Portfolio_Project.Pages.Projects;

public class IndexModel : PageModel
{
    private readonly PortfolioDbContext _context;

    public IndexModel(PortfolioDbContext context)
    {
        _context = context;
    }

    public IList<PortfolioProject> Projects { get; set; } = [];

    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    public async Task OnGetAsync()
    {
        var projectsQuery = _context.Projects.AsQueryable();

        if (!string.IsNullOrWhiteSpace(Search))
        {
            var searchTerm = Search.Trim();

            var searchPattern = $"%{searchTerm}%";

            projectsQuery = projectsQuery.Where(project =>
                EF.Functions.Like(project.Title, searchPattern) ||
                EF.Functions.Like(project.Summary, searchPattern) ||
                EF.Functions.Like(project.TechStack, searchPattern));
        }

        Projects = await projectsQuery
            .OrderByDescending(project => project.IsFeatured)
            .ThenByDescending(project => project.CreatedAt)
            .ToListAsync();
    }
}