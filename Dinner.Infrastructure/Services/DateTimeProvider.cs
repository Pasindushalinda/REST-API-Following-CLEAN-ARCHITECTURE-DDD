using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dinner.Application.Common.Interfaces.Services;

namespace Dinner.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}