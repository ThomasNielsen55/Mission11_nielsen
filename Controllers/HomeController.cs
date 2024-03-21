using Microsoft.AspNetCore.Mvc;
using Mission11_nielsen.Models;
using Mission11_nielsen.Models.ViewModels;
using System.Diagnostics;

namespace Mission11_nielsen.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _bookRepository;
        public HomeController(IBookRepository book)
        {
            _bookRepository = book;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 5;

            var bookPageInfo = new BookListViewModel
            {

                Books = _bookRepository.Books
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _bookRepository.Books.Count()

                }
            };
           
            
            return View(bookPageInfo);
        }

        
    }
}
