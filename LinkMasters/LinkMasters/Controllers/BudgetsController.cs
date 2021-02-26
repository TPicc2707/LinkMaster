using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LinkMasters.Models;
using LinkMasters.Data.Interface;
using LinkMasters.Domain.Service;

namespace LinkMasters.Controllers
{
    public class BudgetsController : Controller
    {
        IBudgetRepository _budgetRepository;
        ICalendarRepository _calendarRepository;
        IPersonRepository _personRepository;
        IAllowanceRepository _allowanceRepository;
        IYearBudgetRepository _yearBudgetRepository;

        public BudgetsController(IBudgetRepository budgetRepository, ICalendarRepository calendarRepository, IPersonRepository personRepository, IAllowanceRepository allowanceRepository, IYearBudgetRepository yearBudgetRepository)
        {
            _budgetRepository = budgetRepository;
            _calendarRepository = calendarRepository;
            _personRepository = personRepository;
            _allowanceRepository = allowanceRepository;
            _yearBudgetRepository = yearBudgetRepository;
        }


        public async Task<IActionResult> MonthlyBudget(Guid personGuid)
        {
            var getBudget = _budgetRepository.FindMonthlyBudgetByPersonGuid(personGuid);

            var month = await _calendarRepository.GetCalendarMonth();
            var allowance = await _allowanceRepository.GetAllowanceByPersonGuid(personGuid);

            ViewBag.PersonGuid = personGuid;
            ViewBag.Month = month.Month;
            ViewBag.Year = month.Year;
            ViewBag.UpdateAllowance = allowance.Person.NextMonthUpdateAllowance;
            ViewBag.StartingAllowance = allowance.StartingAllowance;
            ViewBag.Allowance = allowance.AllowanceRemaining;
            ViewBag.AllowancePositive = allowance.IsAllowanceRemainingPositive;

            return View(await getBudget.ToListAsync());
        }

        public async Task<IActionResult> People(int sortBy)
        {
            if(sortBy == 0)
            {
               var allowance = _allowanceRepository.GetAllAllowanceOrderByPeople();

               return View(await allowance);

            }
            else if(sortBy == 1)
            {
                var allowance = _allowanceRepository.GetAllAllowanceOrderByStartingAllowance();

                return View(await allowance);
            }
            else
            {
                var allowance = _allowanceRepository.GetAllAllowanceOrderByAllowanceRemaining();

                return View(await allowance);
            }
        }

        public async Task<IActionResult> CreateExpense(Guid personGuid)
        {
            ViewBag.PersonGuid = personGuid;

            await BudgetComboBoxes(personGuid);
            return View();
        }

        public IActionResult CreatePerson()
        {
            return View();
        }

        public IActionResult CreateAllowance(Guid personGuid)
        {
            ViewBag.PersonGuid = personGuid;

            return View();
        }

        public IActionResult UpdateAllowance(Guid personGuid)
        {
            ViewBag.PersonGuid = personGuid;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAllowance(Guid personGuid, Allowance allowance)
        {
            if (ModelState.IsValid)
            {
                BudgetBaseService baseService = new BudgetBaseService(_personRepository, _budgetRepository, _allowanceRepository, _calendarRepository, _yearBudgetRepository);
                allowance.PersonGuid = personGuid;
                await baseService.AddAllowance(allowance);
                return RedirectToAction("People", "Budgets", new { sortBy = 0 });
            }

            return RedirectToAction("CreateAllowance", "Budgets", new { personGuid = personGuid });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAllowance(Guid personGuid, Allowance allowance)
        {
            if (ModelState.IsValid)
            {
                BudgetBaseService baseService = new BudgetBaseService(_personRepository, _budgetRepository, _allowanceRepository, _calendarRepository, _yearBudgetRepository);
                await baseService.UpdateAllowance(personGuid, allowance);
                await baseService.UpdateNextMonthAllowance(allowance);
                return RedirectToAction("MonthlyBudget", "Budgets", new { personGuid = personGuid });
            }

            return RedirectToAction("UpdateAllowance", "Budgets", new { personGuid = personGuid });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateExpense(Budget budget)
        {
            if (ModelState.IsValid)
            {
                BudgetBaseService baseService = new BudgetBaseService(_personRepository, _budgetRepository, _allowanceRepository, _calendarRepository, _yearBudgetRepository);
                var allowance = await _allowanceRepository.GetAllowanceByPersonGuid((Guid)budget.PersonGuid);
                budget.AllowanceGuid = allowance.Guid;
                await baseService.AddExpense(budget);
                await AddAllowance(budget, allowance);
                return RedirectToAction("MonthlyBudget", "Budgets", new { personGuid = budget.PersonGuid });
            }

            return RedirectToAction("CreateExpense", "Budgets", new { personGuid = budget.PersonGuid});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePerson(Allowance allowance)
        {
            if (ModelState.IsValid)
            {
                BudgetBaseService baseService = new BudgetBaseService(_personRepository, _budgetRepository, _allowanceRepository, _calendarRepository, _yearBudgetRepository);
                var person = await baseService.AddPersonGetGuid(allowance);
                return RedirectToAction("CreateAllowance", "Budgets", new { personGuid = person.Guid });
            }

            return RedirectToAction("CreatePerson", "Budgets");

        }


        public async Task<IActionResult> YearBudget(Guid personGuid)
        {
            var yearBudget = await _yearBudgetRepository.GetAllMontlyBudgetsByYearFromPersonGuid(personGuid);
            var year = await _calendarRepository.GetCalendarYear();

            ViewBag.PersonGuid = personGuid;
            ViewBag.TotalSpendingAllowance = _yearBudgetRepository.GetTotalStartingAllowanceYearBudgetFromPersonGuid(personGuid);
            ViewBag.TotalAllowanceLeft = _yearBudgetRepository.GetTotalAllowanceLeftYearBudgetFromPersonGuid(personGuid);
            ViewBag.TotalAllowanceSpent = _yearBudgetRepository.GetTotalAllowanceSpentYearBudgetFromPersonGuid(personGuid);
            ViewBag.Year = year.Year;

            return View(yearBudget);
        }

        public async Task<IActionResult> DeleteExpense(Guid budgetGuid)
        {
            var budget = await _budgetRepository.GetByGuidAsync(budgetGuid);
            BudgetBaseService baseService = new BudgetBaseService(_personRepository, _budgetRepository, _allowanceRepository, _calendarRepository, _yearBudgetRepository);
            var allowance = await _allowanceRepository.GetAllowanceByPersonGuid((Guid)budget.PersonGuid);
            await SubtractAllowance(budget, allowance);
            await _budgetRepository.Delete(budgetGuid);

            return RedirectToAction("MonthlyBudget", "Budgets", new { personGuid = budget.PersonGuid });
        }

        public async Task<IActionResult> DeletePerson(Guid personGuid)
        {
            BudgetBaseService baseService = new BudgetBaseService(_personRepository, _budgetRepository, _allowanceRepository, _calendarRepository, _yearBudgetRepository);

            await baseService.DeleteAllYearBudgetsForPerson(personGuid);
            await baseService.DeleteAllMonthlyBudgetsForPerson(personGuid);
            await baseService.DeleteAllowanceForPerson(personGuid);
            await baseService.DeletePerson(personGuid);

            return RedirectToAction("People", "Budgets");
        }

        public async Task<IActionResult> SpecificMonthBudget(Guid personGuid, int calendarMonth)
        {
            var getBudget = _budgetRepository.FindMonthBudgetBySpecificMonth(calendarMonth, personGuid);

            var month = await _calendarRepository.GetCalendarMonthBySpecificMonth(calendarMonth);
            //var allowance = await _allowanceRepository.GetAllowanceByPersonGuid(personGuid);

            ViewBag.PersonGuid = personGuid;
            ViewBag.Month = month.Month;
            ViewBag.Year = month.Year;
            //ViewBag.StartingAllowance = allowance.StartingAllowance;
            ////ViewBag.Allowance = allowance.AllowanceRemaining;
            //ViewBag.AllowancePositive = allowance.IsAllowanceRemainingPositive;

            return View(await getBudget.ToListAsync());
        }

        public IActionResult AllMonthsBudget(Guid personGuid, int year)
        {
            var getBudgets = _budgetRepository.GetAllMonthsBudgetsByPersonGuid(personGuid);

            ViewBag.PersonGuid = personGuid;
            ViewBag.Year = year;

            return View(getBudgets);
        }

        public IActionResult PeopleMonthlyBudget()
        {
            var allPeopleBudgets = _budgetRepository.GetAllMonthlyBudgets();

            return View(allPeopleBudgets);
        }

        public IActionResult PeopleYearlyBudget()
        {
            var allPeopleYearBudgets = _yearBudgetRepository.GetAllYearlyBudgets();

            return View(allPeopleYearBudgets);
        }

        public async Task AddAllowance(Budget budget, Allowance allowance)
        {
            double updatedAllowance = 0;

            if (allowance.IsAllowanceRemainingPositive == false)
            {
                updatedAllowance = allowance.AllowanceRemaining + (double)budget.Cost;

            }
            else
            {
                updatedAllowance = allowance.AllowanceRemaining - (double)budget.Cost;

            }

            if (updatedAllowance < 0)
            {
                allowance.IsAllowanceRemainingPositive = false;
                updatedAllowance = updatedAllowance * -1;
            }

            allowance.AllowanceRemaining = updatedAllowance;

            await _allowanceRepository.Update(allowance.Guid, allowance);

            await UpdateYearBudget(budget, allowance);

        }

        public async Task SubtractAllowance(Budget budget, Allowance allowance)
        {
            double updatedAllowance = 0;

            if (allowance.IsAllowanceRemainingPositive == false)
            {
                updatedAllowance = allowance.AllowanceRemaining - (double)budget.Cost;

            }
            else
            {
                updatedAllowance = allowance.AllowanceRemaining + (double)budget.Cost;

            }

            if (updatedAllowance < 0)
            {
                allowance.IsAllowanceRemainingPositive = false;
                updatedAllowance = updatedAllowance * -1;
            }

            allowance.AllowanceRemaining = updatedAllowance;
            allowance.Modified_DateTime = DateTime.UtcNow;

            await _allowanceRepository.Update(allowance.Guid, allowance);

            await UpdateYearBudget(budget, allowance);
        }

        public async Task UpdateYearBudget(Budget budget, Allowance allowance)
        {
            var yearBudget = await _yearBudgetRepository.GetOneMonthBudgetFromPersonGuid((Guid)budget.PersonGuid);

            yearBudget.AllowanceLeft = allowance.AllowanceRemaining;
            
            if(allowance.IsAllowanceRemainingPositive == false)
            {
                yearBudget.AllowanceSpent = yearBudget.StartedAllowance + yearBudget.AllowanceLeft;
                yearBudget.PositiveAllowance = false;
            }
            else
            {
                yearBudget.AllowanceSpent = yearBudget.StartedAllowance - yearBudget.AllowanceLeft;
            }

            await _yearBudgetRepository.Update(yearBudget.Id, yearBudget);
        }

        public async Task BudgetComboBoxes(Guid personGuid)
        {
            var thisMonth = await _calendarRepository.GetCalendarMonth();

            ViewData["PersonId"] = _personRepository.People(personGuid);
            ViewData["CalendarId"] = _calendarRepository.CalendarMonths(thisMonth);
            ViewData["DayId"] = _calendarRepository.DaysOfMonth();

        }



        // GET: Budgets
        //public async Task<IActionResult> Index()
        //{
        //    var linkMaster2Context = _context.Budget.Include(b => b.Calendar);
        //    return View(await linkMaster2Context.ToListAsync());
        //}

        //    // GET: Budgets/Details/5
        //    public async Task<IActionResult> Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var budget = await _context.Budget
        //            .Include(b => b.Calendar)
        //            .FirstOrDefaultAsync(m => m.Id == id);
        //        if (budget == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(budget);
        //    }

        //    // GET: Budgets/Create
        //    public IActionResult Create()
        //    {
        //        ViewData["CalendarId"] = new SelectList(_context.Calendar, "Id", "Id");
        //        return View();
        //    }

        //    // POST: Budgets/Create
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Create([Bind("Id,Expense,Place,Cost,Allowance,DayOfMonth,CalendarId,Created_DateTime,Modified_DateTime")] Budget budget)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _context.Add(budget);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        ViewData["CalendarId"] = new SelectList(_context.Calendar, "Id", "Id", budget.CalendarId);
        //        return View(budget);
        //    }

        //    // GET: Budgets/Edit/5
        //    public async Task<IActionResult> Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var budget = await _context.Budget.FindAsync(id);
        //        if (budget == null)
        //        {
        //            return NotFound();
        //        }
        //        ViewData["CalendarId"] = new SelectList(_context.Calendar, "Id", "Id", budget.CalendarId);
        //        return View(budget);
        //    }

        //    // POST: Budgets/Edit/5
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(int id, [Bind("Id,Expense,Place,Cost,Allowance,DayOfMonth,CalendarId,Created_DateTime,Modified_DateTime")] Budget budget)
        //    {
        //        if (id != budget.Id)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(budget);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!BudgetExists(budget.Id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        ViewData["CalendarId"] = new SelectList(_context.Calendar, "Id", "Id", budget.CalendarId);
        //        return View(budget);
        //    }

        //    // GET: Budgets/Delete/5
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var budget = await _context.Budget
        //            .Include(b => b.Calendar)
        //            .FirstOrDefaultAsync(m => m.Id == id);
        //        if (budget == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(budget);
        //    }

        //    // POST: Budgets/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        var budget = await _context.Budget.FindAsync(id);
        //        _context.Budget.Remove(budget);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool BudgetExists(int id)
        //    {
        //        return _context.Budget.Any(e => e.Id == id);
        //    }
        //}
    }
}
