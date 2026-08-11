using Microsoft.EntityFrameworkCore;
using EventService.Infrastructure.Data;
using EventService.Infrastructure.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthorization();
builder.Services.AddControllers();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();  

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseSwagger()
        .UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "EventService");
            options.RoutePrefix = string.Empty;
        });
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<EventDbContext>();
    await context.Database.MigrateAsync();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();


app.UseCors("AllowFrontend");
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Temp}/{action=Index}/{id?}");

app.Run();
