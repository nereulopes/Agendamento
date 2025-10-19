using Agendamento.Aplicacao.Servicos;
using Agendamento.Repositorio.Interfaces;
using Agendamento.Repositorio.Implementacao;
using Microsoft.OpenApi.Models;
using Agendamento.Infra.Contextos;
using Microsoft.EntityFrameworkCore;
using Agendamento.Repositorio.ImplementacaoEF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Agendamento de aulas",
        Version = "v1",
        Description = "API desenvolvida para gerenciar os agendamentos de aulas coletivas para uma academia.",
        Contact = new OpenApiContact
        {
            Name = "Nereu Lopes Neto",
            Email = "nereuln@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/nereu-lopes-neto/")
        }
    });

    options.TagActionsBy(api =>
    {
        return new[] { api.GroupName ?? api.ActionDescriptor.RouteValues["controller"] };
    });

    options.DocInclusionPredicate((name, api) => true);

    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
        options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data source=agendamento.db";
builder.Services.AddDbContext<AgendamentoContext>(options => options.UseSqlite(connectionString));

builder.Services.AddScoped<IRepAluno, RepAlunoEF>();
builder.Services.AddScoped<IRepAula, RepAulaEF>();
builder.Services.AddSingleton<IRepAgendamento, RepAgendamento>();

builder.Services.AddScoped<AplicAgendamento>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
