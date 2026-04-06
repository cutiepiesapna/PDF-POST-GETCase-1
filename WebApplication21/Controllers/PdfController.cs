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
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);

                    PdfDocument pdf = new PdfDocument
                    {
                        FileName = file.FileName,
                        FileData = memoryStream.ToArray()
                    };

                    _context.PdfDocuments.Add(pdf);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

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