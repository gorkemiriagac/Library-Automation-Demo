using Azure;
using Library.DataAccess.Context;
using Library.Entity.Entities;
using Library.WebUI.Dtos.BookDtos;
using Library.WebUI.Dtos.BorrowedBookDtos;
using Library.WebUI.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;
using System.Security.Claims;

namespace Library.WebUI.Controllers
{
    [Route("[controller]/[action]/{id?}")]
    public class BorrowedController(UserManager<IdentityConfig> _userManager, LibraryContext libraryContext) : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task GetBookName()
        {
            var data = await _client.GetFromJsonAsync<List<ResultBookDtos>>("books");

            ViewBag.listofbook = new SelectList(data, "BookId", "BookName");
        }

        public async Task GetPiece()
        {
            var data = await _client.GetFromJsonAsync<List<ResultBookDtos>>("books");

            ViewBag.piece = new SelectList(data, "BookId", "Piece");
        }




        public async Task GetFullName()
        {
            var users= _userManager.Users.ToList();

            var fullnames = users.OrderBy(x=>x.FullName).Select(x => new SelectListItem
            {
                Text = x.FullName,
                Value = x.Id.ToString(),

            }).ToList();
            ViewBag.names=fullnames;
           

        }

        /*   var memberlist = await _client.GetFromJsonAsync<List<ResultBorrowedBook>>("borrowedbooks");

              List<SelectListItem> fullnames = (from x in memberlist
                                                select new SelectListItem
                                                {
                                                    Text = x.Member.FullName,
                                                    Value = x.Member.Id.ToString(),
                                                }).ToList();
              ViewBag.names = fullnames;*/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AdminBorrowed()
        {
            await GetFullName();
            await GetBookName();
            var result = await _client.GetFromJsonAsync<List<ResultBorrowedBook>>("borrowedbooks");
            return View(result);
        }




        [HttpGet]
        public async Task<IActionResult> CreateBorrowed()
        {
        
            await GetFullName();
            await GetBookName();

            return View(new CreateBorrowedBookDtos());
        }

        [HttpPost]
        public async Task<IActionResult> CreateBorrowed(CreateBorrowedBookDtos createBorrowedBookDtos,UpdateBorrowedBookDtos updateBorrowedBookDtos)
        {
            var bookId = updateBorrowedBookDtos.BookId;

            var changepiece = await libraryContext.Books.FirstOrDefaultAsync(x => x.BookId == bookId);

            if(changepiece.Piece >= 1)
            {
                changepiece.Piece -= 1;
                await libraryContext.SaveChangesAsync();
                var create = await _client.PostAsJsonAsync("borrowedbooks", createBorrowedBookDtos);
                if (!create.IsSuccessStatusCode)
                {
                    ViewBag.Error = "Error!! Try Again (CreateBorrowed)";
                    return View();
                }

                return RedirectToAction(nameof(AdminBorrowed));
            }
            else
            {
                ViewBag.Error = "No Stock";
                return View();
            }
           

           
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBorrowed(int id)
        {
            await GetPiece();
            await GetFullName();
            await GetBookName();
            var values = await _client.GetFromJsonAsync<UpdateBorrowedBookDtos>("borrowedbooks/" + id);
            return View(values);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateBorrowed(UpdateBorrowedBookDtos updateBorrowedBookDtos)
        {
            var bookId = updateBorrowedBookDtos.BookId;

            var changepiece = await libraryContext.Books.FirstOrDefaultAsync(x => x.BookId == bookId);

            changepiece.Piece += 1;
            await libraryContext.SaveChangesAsync();

             var result = await _client.PutAsJsonAsync("borrowedbooks", updateBorrowedBookDtos);
            
             if (!result.IsSuccessStatusCode)
             {
                 ViewBag.Error = "Error!! Try Again (UpdateBorrowed)";
                 return View();
             }
             else
             {
                 ViewBag.Error = "Update Borrowed Successfull";
             }
             return RedirectToAction(nameof(AdminBorrowed));
        }


        public async Task<IActionResult> DeleteBorrowed(int id)
        {
            await _client.DeleteAsync("borrowedbooks/" + id);
            return RedirectToAction(nameof(AdminBorrowed));
        }


        [HttpGet]
        public async Task<IActionResult> MyBook()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userIdString, out int userId))
            {
                return View(new List<ResultBorrowedBook>()); // Kullanıcı yoksa boş liste dön
            }

            var allBooks = await _client.GetFromJsonAsync<List<ResultBorrowedBook>>("borrowedbooks");

            var userBooks = allBooks
                .Where(x => x.MemberId == userId && x.IsActive)
                .ToList();

            return View(userBooks);
        }
    }
}
