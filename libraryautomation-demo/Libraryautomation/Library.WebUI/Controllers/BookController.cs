using Library.DataAccess.Context;
using Library.DTO.Dtos.BorrowedBookDtos;
using Library.Entity.Entities;
using Library.WebUI.Dtos.AuthorDtos;
using Library.WebUI.Dtos.BookDtos;
using Library.WebUI.Helpers;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Library.WebUI.Controllers
{

    [Route("[controller]/[action]/{id?}")]

    public class BookController(LibraryContext _context, UserManager<IdentityConfig> _userManager) : Controller
    {

        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task GetBookName()
        {
            var data = await _client.GetFromJsonAsync<List<ResultBookDtos>>("books");

            ViewBag.listofbook = new SelectList(data, "BookId", "BookName");
        }
        public async Task GetTime()
        {
            var data = await _client.GetFromJsonAsync<List<ResultBorrowedBook>>("borrowedbooks");

            ViewBag.time = new SelectList(data, "BorrowedBookId", "Time");
        }
        public async Task SelectedListAuthorName()
        {
            var authorlist = await _client.GetFromJsonAsync<List<ResultAuthorDto>>("authors");

            List<SelectListItem> authornames = (from x in authorlist
                                                select new SelectListItem
                                                {
                                                    Text =x.FullName,
                                                    Value=x.AuthorId.ToString()
                                                }).ToList();
            ViewBag.selects=authornames;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _client.GetFromJsonAsync<List<ResultBookDtos>>("books");
            return View(result);



        }


        [HttpGet]
        public async Task<IActionResult> AdminBook()
        {
            if (User.Identity.IsAuthenticated)//todo bunu sürekli kullanmamak için araştır
            {
                var user = await _userManager.GetUserAsync(User);
                if(user.isAdmin == true)
                {
                    var result = await _client.GetFromJsonAsync<List<ResultBookDtos>>("books");
                    return View(result);
                }
                else
                {
                    return Forbid();
                }

            }
            return View();


        }

        [HttpGet]

        public async Task <IActionResult> CreateBook()
        {
            await GetBookName();
            await SelectedListAuthorName();
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> CreateBook(CreateBookDtos createBookDtos)
        {
            var create = await _client.PostAsJsonAsync("books", createBookDtos);
            if (!create.IsSuccessStatusCode)
            {
                ViewBag.Error = "Error!! Try Again";
                return View();
            }
            else
            {
                ViewBag.Error = "Adding Book Successfull";
            }
            return RedirectToAction(nameof(AdminBook));
        }



        public async Task<IActionResult> DeleteBook(int id)
        {
            await _client.DeleteAsync("books/" + id);
            return RedirectToAction(nameof(AdminBook));

        }

        [HttpGet]
        public async Task <IActionResult> UpdateBook(int id)
        {
            await GetBookName();
            await SelectedListAuthorName();
            var values = await _client.GetFromJsonAsync<UpdateBookDtos>("books/" + id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(UpdateBookDtos updateBookDtos)
        {
            var update = await _client.PutAsJsonAsync("books", updateBookDtos);
            if (!update.IsSuccessStatusCode)
            {
                ViewBag.Update = "Error! Try Again (Update)";
                return View();
            }
          
            return RedirectToAction(nameof(AdminBook));
        }

        
    }
}
