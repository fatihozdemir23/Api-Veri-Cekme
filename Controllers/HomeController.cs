using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mime;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Models.Usom;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {

        private HttpHelper helpers;
        private IConfiguration configuration;

        public HomeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async  Task<IActionResult> Index()
        {
            string apiUrl = configuration["Apiler:TestApi"];
            helpers = new HttpHelper(apiUrl);
            var data = await helpers.GetDataFromApi<List<UserApi>>();
            return View(data); 
        }
        public IActionResult test()
        {
            return View();
        }
      
        public async Task<IActionResult> UsomDocument()
        {



            string apiUrl = configuration["Apiler:usomDocuments"];
            helpers = new HttpHelper(apiUrl);
            var code =await helpers.StatusCode();

            if ( code==HttpStatusCode.NotFound )
            {
                TempData["mesaj"]= "Api Url Hatası";
                return RedirectToAction("Index");
            }
            else if ( code == HttpStatusCode.OK )
            {
                var data = await helpers.GetDataFromApi<Document>();
                return View(data);
            }
            else
            {
                TempData["mesaj"] = "Api bağlantı hatası";
                return RedirectToAction("Index");
            }
            
        }
    }
}