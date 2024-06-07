// Controllers/DynamicFormController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class DynamicFormController : Controller
{
    public IActionResult Index()
    {
        var parser = new XsdParser();
        var elements = parser.Parse("C:\\Users\\manji\\Downloads\\xsd1.xsd");

        var model = new DynamicFormViewModel
        {
            FormModel = new DynamicFormModel { Elements = elements },
            FormData = new Dictionary<string, string>()
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult SubmitForm(DynamicFormViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Process the form data
            foreach (var item in model.FormData)
            {
                // Handle each form field
                System.Console.WriteLine($"{item.Key}: {item.Value}");
            }

            return RedirectToAction("Success");
        }

        return View("Index", model);
    }

    public IActionResult Success()
    {
        return View();
    }
}