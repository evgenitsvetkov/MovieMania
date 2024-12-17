using Microsoft.EntityFrameworkCore;
using MovieMania.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMania.Tests.Mocks
{
    public static class DatabaseMock
    {
        public static MovieManiaDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<MovieManiaDbContext>()
                    .UseInMemoryDatabase("MovieManiaInMemoryDb" + DateTime.Now.Ticks.ToString())
                    .Options;

                return new MovieManiaDbContext(dbContextOptions, false);
            }
        }
    }
}
