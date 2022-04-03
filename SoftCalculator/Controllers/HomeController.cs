using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SoftCalculator.Models;

namespace SoftCalculator.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Calculator()
    {
        return View();
    }

    public JsonResult Calculate(string firstNum = "0", string secondNum = "0", string operand = "+"){
        double num1 = double.Parse(firstNum);
        double num2 = double.Parse(secondNum);
        double result = 0;

        switch(operand){
            case "+":
                result = Math.Round(num1 + num2,8);
                break;
            case "-":
                result = Math.Round(num1 - num2,8);
                break;
            case "x":
                result = Math.Round(num1 * num2,8);
                break;
            case "/":
                result = Math.Round(num1 / num2,8);
                break;
            default:
                result = 0;
                break;
        }

        return Json(result);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


}
