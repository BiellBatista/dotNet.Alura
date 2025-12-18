using _04_04_Comunicacao_entre_componentes.WebApp.Data;
using _04_04_Comunicacao_entre_componentes.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options
        .UseSqlServer(builder.Configuration.GetConnectionString("ContainRsDB"));
});

builder.Services
    .AddRefitClient<IViaCepService>()
    .ConfigureHttpClient(client =>
    {
        client.BaseAddress = new Uri("https://viacep.com.br");
        client.DefaultRequestHeaders.Add("Accept", "application/json");
    });

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