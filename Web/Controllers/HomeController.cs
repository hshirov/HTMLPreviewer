using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Common.Exceptions;
using Services.Data;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHTMLExampleService _htmlExamples;
        private readonly IMapper _mapper;
        private readonly INotyfService _toast;
        public HomeController(IHTMLExampleService htmlExamples, IMapper mapper, INotyfService toast)
        {
            _htmlExamples = htmlExamples;
            _mapper = mapper;
            _toast = toast;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Preview));
        }

        [Route("GetExample")]
        public async Task<IActionResult> GetExample(int id)
        {
            try
            {
                var example = await _htmlExamples.Get(id);
                var model = _mapper.Map<RenderHTMLViewModel>(example);

                return View(model);
            }
            catch(ExampleNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Route("GetExampleRaw")]
        public async Task<IActionResult> GetExampleRaw(int id)
        {
            try
            {
                var example = await _htmlExamples.Get(id);
                var model = _mapper.Map<RenderHTMLViewModel>(example);

                return View(model);
            }
            catch (ExampleNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Route("Preview")]
        public IActionResult Preview()
        {
            RenderHTMLViewModel model = new RenderHTMLViewModel();

            return View(model);
        }

        [Route("Preview")]
        [HttpPost]
        public IActionResult Preview(RenderHTMLViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            return NotFound(ModelState.Values.SelectMany(x => x.Errors));
        }

        [Route("SaveExample")]
        [HttpPost]
        public async Task<IActionResult> SaveExample(RenderHTMLViewModel model)
        {
            if (ModelState.IsValid)
            {
                var example = _mapper.Map<HTMLExample>(model);
                await _htmlExamples.AddOrUpdate(example);

                _toast.Success("Example saved.");

                return RedirectToAction(nameof(GetExample), new { id = example.Id });
            }

            return NotFound(ModelState.Values.SelectMany(x => x.Errors));
        }
    }
}
