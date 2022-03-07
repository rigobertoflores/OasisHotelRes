using Microsoft.EntityFrameworkCore;
using OasisHotelRes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OasisHotelRes
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Calendario> OasCalendariois { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Centros_consumo> Centros_Consumo { get; set; }
        public DbSet<Centros_consumo_detalles> Centros_Consumo_Detalles { get; set; }
        public DbSet<Centros_consumo_horarios> Centros_Consumo_Horarios { get; set; }
        public DbSet<Hoteles> Hoteles { get; set; }
        public DbSet<Locaciones> Locaciones { get; set; }
        public DbSet<Propiedades> Propiedades { get; set; }
    }
}
