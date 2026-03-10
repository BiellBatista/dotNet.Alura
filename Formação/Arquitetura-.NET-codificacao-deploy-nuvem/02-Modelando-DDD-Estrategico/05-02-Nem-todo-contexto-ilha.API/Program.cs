using _05_02_Nem_todo_contexto_ilha.API.Clientes;
using _05_02_Nem_todo_contexto_ilha.API.Conteineres;
using _05_02_Nem_todo_contexto_ilha.API.Data;
using _05_02_Nem_todo_contexto_ilha.API.Data.Repositories;
using _05_02_Nem_todo_contexto_ilha.API.Domain;
using _05_02_Nem_todo_contexto_ilha.API.Identity;
using _05_02_Nem_todo_contexto_ilha.Contracts;
using _05_02_Nem_todo_contexto_ilha.Vendas.Locacoes;
using _05_02_Nem_todo_contexto_ilha.Vendas.Propostas;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IdentityDbContext>(options =>
{
    options
        .UseSqlServer(builder.Configuration.GetConnectionString("IdentityDB"));
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options
        .UseSqlServer(builder.Configuration.GetConnectionString("ContainRsDB"));
});

builder.Services.AddScoped<IRepository<Cliente>, ClienteRepository>();
builder.Services.AddScoped<IRepository<PedidoLocacao>, SolicitacaoRepository>();
builder.Services.AddScoped<IRepository<Proposta>, PropostaRepository>();
builder.Services.AddScoped<IRepository<Locacao>, LocacaoRepository>();
builder.Services.AddScoped<IRepository<Conteiner>, ConteinerRepository>();

builder.Services
    .AddIdentityApiEndpoints<AppUser>(options => options.SignIn.RequireConfirmedEmail = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<IdentityDbContext>();

builder.Services.AddAuthorization();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.ClaimsIdentity.UserIdClaimType = "ClienteId";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app
    .MapIdentityEndpoints()
    .MapClientesEndpoints()
    .MapAprovacaoClientesEndpoints()
    .MapSolicitacoesEndpoints()
    .MapPropostasEndpoints()
    .MapLocacoesEndpoints()
    .MapConteineresEndpoints();

app.Run();