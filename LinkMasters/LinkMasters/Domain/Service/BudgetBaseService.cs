using LinkMasters.Data.Interface;
using LinkMasters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Domain.Service
{
    public class BudgetBaseService
    {
        IPersonRepository _personRepository;
        IBudgetRepository _budgetRepository;
        IAllowanceRepository _allowanceRepository;
        ICalendarRepository _calendarRepsoitory;
        IYearBudgetRepository _yearBudgetRepository;

        public BudgetBaseService()
        {

        }

        public BudgetBaseService(IPersonRepository personRepository, IBudgetRepository budgetRepository, IAllowanceRepository allowanceRepository, ICalendarRepository calendarRepository, IYearBudgetRepository yearBudgetRepository)
        {
            _personRepository = personRepository;
            _budgetRepository = budgetRepository;
            _allowanceRepository = allowanceRepository;
            _calendarRepsoitory = calendarRepository;
            _yearBudgetRepository = yearBudgetRepository;
        }

        public async Task AddExpense(Budget budget)
        {
            budget.Guid = Guid.NewGuid();
            budget.Created_DateTime = DateTime.UtcNow;
            budget.Modified_DateTime = DateTime.UtcNow;
            await _budgetRepository.Create(budget);
        }

        public async Task<Person> AddPersonGetGuid(Allowance allowance)
        {
            Person person = new Person();

            person.Guid = Guid.NewGuid();
            allowance.Guid = person.Guid;
            person.FirstName = allowance.Person.FirstName;
            person.LastName = allowance.Person.LastName;
            person.Created_DateTime = DateTime.UtcNow;
            person.Modified_DateTime = DateTime.UtcNow;

            await _personRepository.Create(person);

            return person;
        }

        public async Task AddAllowance(Allowance allowanceModel)
        {
            allowanceModel.Guid = Guid.NewGuid();
            allowanceModel.AllowanceRemaining = allowanceModel.StartingAllowance;
            allowanceModel.IsAllowanceRemainingPositive = true;
            allowanceModel.Created_DateTime = DateTime.UtcNow;
            allowanceModel.Modified_DateTime = DateTime.UtcNow;
            //var personGuid = _personRepository.Get

            await _allowanceRepository.Create(allowanceModel);

            await CreateYearBudget(allowanceModel);
        }

        public async Task UpdateAllowance(Guid personGuid, Allowance allowanceModel)
        {
            var allowance = await _allowanceRepository.GetAllowanceByPersonGuid(personGuid);
            allowance.StartingAllowance = allowanceModel.StartingAllowance;
            allowance.AllowanceRemaining = allowanceModel.StartingAllowance;
            allowance.IsAllowanceRemainingPositive = true;
            allowance.Modified_DateTime = DateTime.UtcNow;

            await _allowanceRepository.Update(allowance.Guid, allowance);

            await CreateYearBudget(allowance);
        }

        public async Task CreateYearBudget(Allowance allowanceModel)
        {
            YearBudget yearBudget = new YearBudget();

            var calendar = await _calendarRepsoitory.GetCalendarMonth();

            yearBudget.StartedAllowance = allowanceModel.StartingAllowance;
            yearBudget.AllowanceLeft = allowanceModel.StartingAllowance;
            yearBudget.PositiveAllowance = true;
            yearBudget.CalendarId = calendar.Id;
            yearBudget.PersonGuid = allowanceModel.PersonGuid;
            yearBudget.AllowanceSpent = yearBudget.StartedAllowance - yearBudget.AllowanceLeft;

            await _yearBudgetRepository.Create(yearBudget);

        }

        public async Task UpdateNextMonthAllowance(Allowance allowance)
        {
            var person = await _personRepository.GetPersonByPersonGuid((Guid)allowance.PersonGuid);

            if(DateTime.Today.Month == 12)
            {
                person.NextMonthUpdateAllowance = 1;
            }
            else
            {
                person.NextMonthUpdateAllowance = DateTime.Today.Month + 1;
            }

            await _personRepository.Update(person.Guid, person);
        }

        public async Task DeleteAllYearBudgetsForPerson(Guid personGuid)
        {
            var yearBudgets = await _yearBudgetRepository.GetAllMontlyBudgetsByYearFromPersonGuid(personGuid);

            foreach (var yearBudget in yearBudgets)
            {
                await _yearBudgetRepository.Delete(yearBudget.Id);
            }

        }

        public async Task DeleteAllMonthlyBudgetsForPerson(Guid personGuid)
        {
            var budgets = _budgetRepository.GetAllMonthsBudgetsByPersonGuid(personGuid);

            foreach (var budget in budgets)
            {
                await _budgetRepository.Delete(budget.Guid);
            }

        }

        public async Task DeleteAllowanceForPerson(Guid personGuid)
        {
            var allowance = await _allowanceRepository.GetAllowanceByPersonGuid(personGuid);

            await _allowanceRepository.Delete(allowance.Guid);

        }

        public async Task DeletePerson(Guid personGuid)
        {
            var person = await _personRepository.GetPersonByPersonGuid(personGuid);

            await _personRepository.Delete(person.Guid);
        }
    }
}
