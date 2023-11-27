var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();  // добавляем поддержку контроллеров
builder.Services.AddControllersWithViews(); // добавление контроллеров с представлениями
builder.Services.AddTransient<ITimeService, SimpleTimeService>(); // добавляем сервис ITimeService

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

// В данном случае определен интерфейс ITimeService и его реализация SimpleTimeService. И в приложении происходит регистрация сервиса ITimeService.

public interface ITimeService
{
    string Time { get; }
}
public class SimpleTimeService : ITimeService
{
    public string Time => DateTime.Now.ToString("hh:mm:ss");
}
