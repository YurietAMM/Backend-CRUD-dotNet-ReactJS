using ApiCrudGestores.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace ApiCrudGestores.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
        {

        }
        public DbSet<GestoresBD> gestores_bd { get; set; }
    }
}
