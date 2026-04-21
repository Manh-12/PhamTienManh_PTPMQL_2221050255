using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PTPMQL_MVC.Data;
using PTPMQL_MVC.Models.Entities;
using OfficeOpenXml; // Thư viện để làm việc với Excel

namespace PTPMQL_MVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context.Person.ToListAsync();
            return View(model);
        }

        // --- HÀM UPLOAD FILE EXCEL ---
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return RedirectToAction(nameof(Index));
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);

                using (var package = new ExcelPackage(stream))
                {
                    // Đọc Sheet đầu tiên
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++) // Bắt đầu từ dòng 2 để bỏ tiêu đề
                    {
                        var personId = worksheet.Cells[row, 1].Value?.ToString();

                        // Chỉ thêm nếu PersonId chưa tồn tại trong Database
                        if (!string.IsNullOrEmpty(personId) && !PersonExists(personId))
                        {
                            var person = new Person
                            {
                                PersonId = personId,
                                FullName = worksheet.Cells[row, 2].Value?.ToString(),
                                Address = worksheet.Cells[row, 3].Value?.ToString(),
                                Age = int.TryParse(worksheet.Cells[row, 4].Value?.ToString(), out int age) ? age : 0,
                                Email = worksheet.Cells[row, 5].Value?.ToString()
                            };

                            _context.Person.Add(person);
                        }
                    }
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        // --- CÁC HÀM CRUD CÓ SẴN CỦA BẠN ---
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,FullName,Address,Age,Email")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Person == null) return View("NotFound");
            var person = await _context.Person.FindAsync(id);
            if (person == null) return View("NotFound");
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PersonId,FullName,Address,Age,Email")] Person person)
        {
            if (id != person.PersonId) return View("NotFound");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PersonId)) return View("NotFound");
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Person == null) return View("NotFound");
            var person = await _context.Person.FirstOrDefaultAsync(m => m.PersonId == id);
            if (person == null) return View("NotFound");
            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var person = await _context.Person.FindAsync(id);
            if (person != null) _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(string id)
        {
            return (_context.Person?.Any(e => e.PersonId == id)).GetValueOrDefault();
        }
    }
}
