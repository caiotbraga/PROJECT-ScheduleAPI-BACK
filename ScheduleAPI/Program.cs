using Microsoft.EntityFrameworkCore;
using ScheduleAPI.Data;
using ScheduleAPI.Interface;
using ScheduleAPI.Service;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("UserConnection");

builder.Services.AddDbContext<UserContext>(opts => opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
builder.Services.AddScoped<UserService>();
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//services cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:5176")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
            builder.WithOrigins("http://localhost:5174")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
            builder.WithOrigins("http://localhost:5173")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});



var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

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
