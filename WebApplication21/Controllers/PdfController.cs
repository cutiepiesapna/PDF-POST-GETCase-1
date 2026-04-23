using Microsoft.AspNetCore.Mvc;
using WebApplication21.Models;
using WebApplication21.Models;

namespace WebApplication20.Controllers
{
    public class PdfController : Controller
    {
        private readonly TestDbContext _context;

        public PdfController(TestDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var files = _context.PdfDocuments.ToList();

            return View(files);
        }
        // Upload Page
        public IActionResult Upload()
        {
            return View();
        }

        // Upload PDF
    

        // Download PDF
        public IActionResult Download(int id)
        {
            var file = _context.PdfDocuments.FirstOrDefault(x => x.Id == id);

            if (file == null)
                return NotFound();

            return File(file.FileData, "application/pdf", file.FileName);
        }
    }
}