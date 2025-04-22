using AspNetCoreGeneratedDocument;
using Library.WebUI.Dtos.AuthorDtos;
using Library.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers
{
    [Route("[controller]/[action]/{id?}")]
    public class AuthorController : Controller
    {

        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task <IActionResult> Index()
        {
             var values = await _client.GetFromJsonAsync<List<ResultAuthorDto>>("authors");
             return View(values);
            
        }

        public async Task<IActionResult> AdminAuthor()
        {
            var values = await _client.GetFromJsonAsync<List<ResultAuthorDto>>("authors");
            return View(values);

        }


        [HttpGet]
        public IActionResult CreateAuthor()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            var result = await _client.PostAsJsonAsync("authors", createAuthorDto);
            if (!result.IsSuccessStatusCode)
            {
                ViewBag.Author = "Error !! Try Again! (CreateAuthor)";
            }
            else
            {
                ViewBag.Author = " Successfull! (CreateAuthor) ";
            }
            return RedirectToAction(nameof(AdminAuthor));  
        }


        public async Task <IActionResult> DeleteAuthor(int id)
        {
            await _client.DeleteAsync("authors/" + id);
            return RedirectToAction(nameof(AdminAuthor));
        }

        [HttpGet]
        public async Task <IActionResult> UpdateAuthor(int id)
        {
            var result = await _client.GetFromJsonAsync<UpdateAuthorDto>("authors/" + id);
            return View(result);
        }

        public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto updateAuthorDto)
        {
            var result = await _client.PutAsJsonAsync("authors", updateAuthorDto);
            if (!result.IsSuccessStatusCode)
            {
                ViewBag.Author = "Error !! TryAgain (UpdateAuthor)";
            }
            else
            {
                ViewBag.Author = "Successfull (UpdateAuthor)";
            }
            return RedirectToAction(nameof(AdminAuthor));
        }
    }
}
