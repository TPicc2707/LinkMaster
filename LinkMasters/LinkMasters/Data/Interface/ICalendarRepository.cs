using LinkMasters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Interface
{
    public interface ICalendarRepository : ILinkBaseRepository<Calendar>
    {
        Task<Calendar> GetCalendarMonth();

        Task<Calendar> GetCalendarMonthBySpecificMonth(int calendarMonth);

        Task<Calendar> GetCalendarYear();

        Task<Calendar> GetCalendarYearById();
    }
}
