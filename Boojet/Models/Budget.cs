using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boojet.Models
{
    public class Budget
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public Guid UserId { get; set; }
        public List<MoneyItem> MoneyItems { get; set; }

    }
}
