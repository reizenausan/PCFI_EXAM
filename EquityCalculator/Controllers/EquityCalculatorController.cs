using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class EquityCalculatorController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Calculate([FromBody] EquityCalculation calculation)
    {
        if (calculation != null)
        {
            var payments = calculation.CalculatePayments();
            return Json(payments);
        }
        return BadRequest();
    }
}
