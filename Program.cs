using FilmRental.Data;
using FilmRental.Data.Repos;
using FilmRental.Data.Repos.IRepos;
using FilmRental.Services;
using FilmRental.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add Cors to frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("LocalReact", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddDbContext<FilmRentalContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();

builder.Services.AddScoped<IRentalRepository, RentalRepository>();
builder.Services.AddScoped<IRentalService, RentalService>();

var app = builder.Build();
app.UseCors("LocalReact");

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
