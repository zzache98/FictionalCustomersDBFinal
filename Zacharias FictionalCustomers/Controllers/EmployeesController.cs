using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zacharias_FictionalCustomers.Data;
using Zacharias_FictionalCustomers.Models;

namespace Zacharias_FictionalCustomers.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Employee.ToListAsync());
        //}

        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            //var bookDBContext = _context.Books.Include(b => b.BookAuthor).Include(b => b.BookPublisher);

            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewData["PubSortParm"] = sortOrder == "Publisher" ? "publisher_desc" : "Publisher";
            //ViewData["CategorySortParm"] = sortOrder == "Category" ? "category_desc" : "Category";
            ViewData["CurrentFilter"] = searchString;
            var employees = (from s in _context.Employee
                         select s)/*.Include(b => b.AssignedProject)*/.ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.Name.ToLower().Contains(searchString.ToLower())).ToList();
                                       
            }
            switch (sortOrder)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(s => s.Name).ToList();
                    break;
                case "Name":
                    employees = employees.OrderBy(s => s.Name).ToList();
                    break;
                case "Programming Language":
                    employees = employees.OrderBy(s => s.ProgrammingLanguage).ToList();
                    break;
                case "programming Language_desc":
                    employees = employees.OrderByDescending(s => s.ProgrammingLanguage).ToList();
                    break;
                //case "author_desc":
                //    employees = employees.OrderByDescending(s => s.Author.Name).ToList();
                //    break;
                //case "Publisher":
                //    employees = employees.OrderBy(s => s.Publisher.Name).ToList();
                //    break;
                default:
                    employees = employees.OrderBy(s => s.Name).ToList();
                    break;
            }
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                //.Include(b => b.AssignedProject)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            //ViewData["ProjectId"] = new SelectList(_context.AssignedProject, "ProjectId", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Name,Email,Adress,ProgrammingLanguage,Password,ConfirmPassword")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["ProjectId"] = new SelectList(_context.AssignedProject, "ProjectId", "Name",);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            //ViewData["ProjectId"] = new SelectList(_context.AssignedProject, "ProjectId", "Name", employee.ProjectId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,Name,Email,Adress,ProgrammingLanguage,Password,ConfirmPassword")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["ProjectId"] = new SelectList(_context.AssignedProject, "ProjectId", "Name", employee.ProjectId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeId == id);
        }
    }
}
