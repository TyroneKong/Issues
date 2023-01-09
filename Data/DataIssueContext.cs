using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using issues.Models;
using Microsoft.EntityFrameworkCore;

namespace issues.Data
{

    public class DataIssueContext : DbContext
    {
        public DataIssueContext() : base()
        {

        }
        public DataIssueContext(DbContextOptions<DataIssueContext> options) : base(options)
        {

        }
        public DbSet<Issue> Issues => Set<Issue>();
    }
}