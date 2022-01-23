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
    public class AssignedProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssignedProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AssignedProjects
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.AssignedProject.Include(b => b.Employee).ToListAsync());
        }

        // GET: AssignedProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignedProject = await _context.AssignedProject.Include(b => b.Employee)
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (assignedProject == null)
            {
                return NotFound();
            }
            
            return View(assignedProject);
        }

        // GET: AssignedProjects/Create
        public IActionResult Create()
        {
            ViewData["Employee"] = new SelectList(_context.Employee,"EmployeeId","Name");
            return View();
        }

        // POST: AssignedProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,CompanyName,Companyaddress,Task,Date,EmployeeId")] AssignedProject assignedProject)
        {
            if (ModelState.IsValid)
            {
                
               //assignedProject.Employee = _context.Employee.Find(assignedProject.EmployeeId);
                _context.Add(assignedProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Employee"] = new SelectList(_context.Employee,"EmployeeId","Name",assignedProject.Employee);
            return View(assignedProject);
        }

        // GET: AssignedProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignedProject = await _context.AssignedProject.FindAsync(id);
            if (assignedProject == null)
            {
                return NotFound();
            }
            var assignedproject = (from s in _context.AssignedProject
                                   select s).Include(b => b.Employee).ToList();
            return View(assignedProject);
        }

        // POST: AssignedProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,CompanyName,Companyaddress,Task,Date,EmployeeId")] AssignedProject assignedProject)
        {
            if (id != assignedProject.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignedProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignedProjectExists(assignedProject.ProjectId))
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
            ViewData["Employee"] = new SelectList(_context.Employee,"EmployeeId","Name");
            return View(assignedProject);
        }

        // GET: AssignedProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignedProject = await _context.AssignedProject
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (assignedProject == null)
            {
                return NotFound();
            }
            ViewData["Employee"] = new SelectList(_context.Employee,"EmployeeId","Name");
            return View(assignedProject);
        }

        // POST: AssignedProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignedProject = await _context.AssignedProject.FindAsync(id);
            _context.AssignedProject.Remove(assignedProject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignedProjectExists(int id)
        {
            return _context.AssignedProject.Any(e => e.ProjectId == id);
        }
    }
}
