using HaSe.Domain.Repos;
using HaSe.Infra.Contoso;
using HaSe.Infra.Contoso.DbInitializers;
using HaSe.Soft.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ContosoDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IPartsRepo, PartsRepo>();
builder.Services.AddTransient<IStudentsRepo, StudentsRepo>();
builder.Services.AddTransient<IDepartmentsRepo, DepartmentsRepo>();
builder.Services.AddTransient<IInstructorsRepo, InstructorsRepo>();

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
    var db = GetContext<ContosoDbContext>(app);
    await new CourseDbInitializer(db, db.Parts).Initialize(10000);
    await new DepartmentDbInitializer(db, db.Department).Initialize(10);
    await new InstructorDbInitializer(db, db.Instructor).Initialize(50);
    await new StudentDbInitializer(db, db.Student).Initialize(5000);
}

static TDbContext GetContext<TDbContext>(WebApplication app) where TDbContext : DbContext => app
    .Services
    .CreateScope()
    .ServiceProvider
    .GetRequiredService<TDbContext>();