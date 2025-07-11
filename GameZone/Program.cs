
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("No Connection string was found");
builder.Services.AddDbContext<ApplicationDb>(options =>
options.UseSqlServer(ConnectionString));
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICategorieServices, CategorieServices>();
builder.Services.AddScoped<IDevicesServices, DevicesServices>();
builder.Services.AddScoped<IGamesServices, GamesServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

app.Run();
