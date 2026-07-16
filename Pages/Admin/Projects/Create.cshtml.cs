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

    private const string DefaultDescriptionMarkdown = """
## Overview

Short summary of what the project does and why it was built.

## My role

What I worked on, what decisions I contributed to, and what parts I implemented.

## Tech stack

- C#
- ASP.NET Core
- EF Core
- Azure

## What I learned

Describe the practical skills I developed while building this project.

## Challenges

Explain one or two problems I solved.

## What I would improve next

Show reflection and growth.
""";

    public void OnGet()
    {
        Project.DescriptionMarkdown = DefaultDescriptionMarkdown;
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
