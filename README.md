---
created: 2026-07-03T13:49
updated: 2026-07-03T13:50
---

# Portfolio Project

A personal portfolio platform built with ASP.NET Core Razor Pages, EF Core, SQLite, and Markdown.

The goal of this project is to keep my C# skills active while building something useful: a portfolio site where I can manage and present projects through a small admin area.

## Features

- Public project listing
- Project detail pages with slug-based URLs
- Admin area for creating, editing, and deleting projects
- SQLite database with EF Core
- Markdown rendering for project descriptions
- Validation for required fields, URLs, and slug format
- Unique slugs for reliable project URLs
- Automatic slug generation from project titles

## Tech Stack

- C#
- ASP.NET Core Razor Pages
- Entity Framework Core
- SQLite
- Markdig
- Bootstrap

## Project Structure

```text
Pages/
  Projects/
    Index
    Details

  Admin/
    Projects/
      Index
      Create
      Edit
      Delete

Data/
  PortfolioDbContext

Models/
  PortfolioProject

Helpers/
  SlugHelper

```

## Getting Started

Clone the repository:

```
git clone https://github.com/ArtByMagicUnicorn/Portfolio-Project.git
cd "Portfolio-Project"
```

Restore packages:

```
dotnet restore
```

Apply database migrations:

```
dotnet ef database update
```

Run the app:

```
dotnet run
```

Then open the local URL shown in the terminal.

## Notes

The SQLite database file is not committed to source control. It is created locally from EF Core migrations.

## Roadmap

- Add authentication for the admin area
- Improve visual design
- Add Markdown preview in admin
- Add project screenshots
- Add tests
- Add GitHub Actions for build validation
- Deploy the portfolio online