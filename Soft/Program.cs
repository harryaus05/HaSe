using HaSe.Domain.Repos;
using HaSe.Infra.Project;
using HaSe.Infra.Project.DbInitializers;
using HaSe.Soft.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ProjectDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IPartsRepo, PartsRepo>();
builder.Services.AddTransient<IPartSpecificationRepo, PartSpecificationsRepo>();
builder.Services.AddTransient<IPartSpecificationStatusRepo, PartSpecificationStatusRepo>();
builder.Services.AddTransient<IPartSpecificationRoleRepo, PartSpecificationRoleRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

EnsureDatabaseCreated(app);
var task = Task.Run(async () => await TryInitializeDatabase(app));

app.Run();

task.Wait();

static void EnsureDatabaseCreated(WebApplication app) {
    var db = GetContext<ApplicationDbContext>(app);
    db.Database.EnsureCreated();
}

static async Task TryInitializeDatabase(WebApplication app) {
    var db = GetContext<ProjectDbContext>(app);
    await new PartDbInitializer(db, db.Parts).Initialize(10);
    await new PartSpecificationDbInitializer(db, db.PartSpecification).Initialize(10);
    await new PartSpecificationStatusDbInitializer(db, db.PartSpecificationStatus).Initialize(10);
    await new PartSpecificationRoleDbInitializer(db, db.PartSpecificationRole).Initialize(10);
}

static TDbContext GetContext<TDbContext>(WebApplication app) where TDbContext : DbContext => app
    .Services
    .CreateScope()
    .ServiceProvider
    .GetRequiredService<TDbContext>();