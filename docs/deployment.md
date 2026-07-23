# Deployment checklist

## Before deployment

- [ ] Make sure the app builds locally
- [ ] Run all tests
- [ ] Check that GitHub Actions is green
- [ ] Make sure no secrets are committed
- [ ] Confirm that admin login uses User Secrets locally
- [ ] Confirm that production admin credentials will come from environment variables
- [ ] Check that the SQLite database strategy is decided

## Application settings

- [ ] Configure `AdminUser:Username`
- [ ] Configure `AdminUser:Password`
- [ ] Configure database connection string
- [ ] Configure ASP.NET Core environment as `Production`

## Database

- [ ] Decide where the production SQLite database file should live
- [ ] Apply EF Core migrations
- [ ] Confirm that the app can read and write project data
- [ ] Make sure the database file is not committed to Git

## Database migrations

The application applies EF Core migrations automatically on startup.

This keeps deployment simple for this small single-user portfolio CMS. For a larger
production system, migrations should normally be handled as a separate deployment step.

## Hosting

- [ ] Choose hosting option
- [ ] Create hosting resource
- [ ] Configure app settings/environment variables
- [ ] Deploy from GitHub or local publish
- [ ] Confirm the public site loads

## After deployment

- [ ] Test public pages
- [ ] Test admin login
- [ ] Test creating a project
- [ ] Test editing a project
- [ ] Test deleting a test project
- [ ] Check that screenshots/images load
- [ ] Check the site on mobile


## Configuration notes

Local development:
- SQLite uses the connection string from `appsettings.json`.
- Admin credentials are stored with User Secrets.
- No admin credentials should be committed to source control.

Production:
- `ConnectionStrings__PortfolioDb` should be configured as an environment variable/app setting.
- `AdminUser__Username` should be configured as an environment variable/app setting.
- `AdminUser__Password` should be configured as an environment variable/app setting.
- The SQLite database file must be stored in a persistent writable location provided by the hosting platform.
- Example SQLite connection string for Linux App Service:
`ConnectionStrings__PortfolioDb=Data Source=/home/site/data/portfolio.db`