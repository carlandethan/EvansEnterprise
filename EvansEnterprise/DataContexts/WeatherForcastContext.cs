using EvansEnterprise.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvansEnterprise.Data
{
    public class WeatherForcastContext : DbContext
    {
        public WeatherForcastContext(DbContextOptions<WeatherForcastContext> options)
            : base(options)
        {
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
