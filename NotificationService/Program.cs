using Microsoft.OpenApi.Models;
using NotificationService.Data;
using NotificationService.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<TelegramNotificationStrategy>(provider =>
    new TelegramNotificationStrategy("Telegram bot API token", 1));
builder.Services.AddScoped<WhatsAppNotificationStrategy>(provider =>
    new WhatsAppNotificationStrategy("Twilio account", "Twilio account token", "Petros"));
builder.Services.AddScoped<NotificationContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NotificationService", Version = "v1" });
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "NotificationServiceAPi v1"); });
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty;
});
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();