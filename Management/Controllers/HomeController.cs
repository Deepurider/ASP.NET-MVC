using Application.Commands.Persons;
using Domain.Models;
using Domain.Models.Custom;
using Management.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Management.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        // View Controllers
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Person(CancellationToken cancellationToken)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreatePerson(Person person,CancellationToken cancellationToken) 
        {
            CreatePersonCommand command = new CreatePersonCommand() { Person = person };
            var res = await _mediator.Send(command, cancellationToken);
            return RedirectToAction("Person");
        }


        // Api Controller
        [HttpGet("Home/api/[action]")]
        public async Task<IActionResult> Users([FromQuery]JqueryDatatableParam param, CancellationToken cancellationToken)
        {
            var command = new GetPersonCommand() { };
            var res = await _mediator.Send(command, cancellationToken);
            var totalCount = res.Count();
            return Json(new
            {
                param.sEcho,
                iTotalRecords = totalCount,
                iTotalDisplayRecords = totalCount,
                aaData = res.Skip(param.iDisplayStart).Take(param.iDisplayLength),    
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
