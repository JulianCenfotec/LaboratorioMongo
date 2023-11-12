using LaboratorioMongo.Modelos;
using LaboratorioMongo.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("UniversidadDatabase"));

builder.Services.AddSingleton<AlumnoService>();
builder.Services.AddSingleton<CarreraService>();
builder.Services.AddSingleton<GrupoService>();
builder.Services.AddSingleton<TeacherService>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<CursoService>();
builder.Services.AddSingleton<CicloService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
