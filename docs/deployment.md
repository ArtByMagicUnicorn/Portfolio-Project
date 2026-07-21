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


local: Data Source=portfolio.db
production: connection string via environment/app setting
admin credentials via environment/app setting