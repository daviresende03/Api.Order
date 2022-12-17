using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Common
{
    public class TimeProvider : ITimeProvider
    {
        public DateTime utcDate() => DateTime.UtcNow.Date;
    }
}
