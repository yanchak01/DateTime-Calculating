using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            if (weekEnds!=null)
            {
                for (int i = 0; i < weekEnds.Length; i++)
                {
                    while (weekEnds[i].StartDate < weekEnds[i].EndDate)
                    {
                        var look = weekEnds[i].StartDate.AddDays(1);
                        weekEnds[i].StartDate = look;
                        dayCount++;
                    }
                }
                return startDate.AddDays(dayCount);
            }
            else
            {
                return startDate.AddDays(dayCount - 1);
            }

        }

        
    }
}
