using Forum.Api.Infrastructure.Attributes;
using Forum.Api.Infrastructure.Extensions;
using Forum.Bll;
using Forum.Bll.Interfaces;
using Forum.Bll.Services;
using Forum.Dal;
using Forum.Dal.Interfaces;
using Forum.Dal.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(c => c.Filters.Add(typeof(ApiExceptionFilterAttribute)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ForumDbContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("ForumConnectionString")); });

builder.Services.AddAutoMapper(typeof(BllAssemblyMarker));
builder.Services.AddScoped(typeof(IRepository<>), typeof(EFCoreRepository<>));
builder.Services.AddScoped<DbContext, ForumDbContext>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddScoped<IThemeService, ThemeService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

app.UseCustomExceptionHandler();
app.UseExceptionLogger();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseTransaction();

app.MapControllers();

app.Run();
