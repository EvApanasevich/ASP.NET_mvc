using Microsoft.AspNetCore.Mvc;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        readonly ITimeService timeService;

        public HomeController(ITimeService timeServ)
        {
            timeService = timeServ;
        }

        public IActionResult Index(int age, string name)
        {
            //return new HtmlResult("<h2>Hello METANIT.COM!</h2><div>with html results</div>");

            //if (age < 18) return Unauthorized(new Error("Access is denied"));
            //if (string.IsNullOrEmpty(name)) return BadRequest("Name undefined");
            //return Content($"Hello {(!string.IsNullOrEmpty(name) ? name : "no name")}! Your age is {age}");

            return Ok("All is OK!");

            //Person tom = new Person("Tom", 37);
            //var jsonOptions = new System.Text.Json.JsonSerializerOptions
            //{
            //    PropertyNameCaseInsensitive = true, // не учитываем регистр
            //    WriteIndented = true               // отступы для красоты
            //};
            //return Json(tom, jsonOptions);

        }
        public IActionResult About() 
        {
            return Content("About page");
            //return Content($"Name:{name}  Age: {age}");
            //return NotFound("Resource not found");
        } 
        public IActionResult Contact()
        {
            return Redirect("~/Home/About");
            //return Redirect("https://microsoft.com");
            //return RedirectToAction("About", "Home", new { name = "Tom", age = 37 });
        }
        public IActionResult GetFile()
        {
            // Путь к файлу
            string file_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files/document.docx");
            // Тип файла - content-type
            string file_type = "text/plain";
            // Имя файла - необязательно
            string file_name = "document.docx";

            return PhysicalFile(file_path, file_type, file_name);
        }
        public IActionResult GetBytes()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files/pict.png");
            byte[] mas = System.IO.File.ReadAllBytes(path);
            string file_type = "application/octet-stream.";
            string file_name = "pict.png";
            return File(mas, file_type, file_name);
        }
        public IActionResult GetTime()
        {
            return Content(timeService.Time);
        }
    }
    record class Person(string Name, int Age);
    record class Error(string Message);
}
