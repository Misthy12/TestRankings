using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestRanking.Data;

namespace TestRanking.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<TblHorarios> TblHorarios { get; set; }
        public virtual DbSet<TblPuntos> TblPuntos { get; set; }
        public virtual DbSet<TblTiendas> TblTiendas { get; set; }
    }
}
