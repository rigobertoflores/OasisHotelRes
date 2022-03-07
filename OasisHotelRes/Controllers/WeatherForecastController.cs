using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OasisHotelRes.Interfaces;
using OasisHotelRes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OasisHotelRes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly AplicationDbContext dbContext;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
     
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, AplicationDbContext context)
        {
            _logger = logger;
            dbContext = context;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
           var u= dbContext.Hoteles;
            //string query = " Select * from  calendario";
            //MySqlConnection mySql = new MySqlConnection("server=127.0.0.1;port=3306;username=root;password=;database=oasis;");
            //MySqlCommand my = new MySqlCommand(query, mySql);
            //my.CommandTimeout = 60;
            //MySqlDataReader reader;
            //try
            //{
            //    mySql.Open();
            //    reader = my.ExecuteReader();
            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            string[] row = { reader.GetString(0) };
            //        }
            //    }
            //}
            //catch (Exception exc)
            //{

            //}

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("getHotel")]
        public  List<Hoteles> GetHotelAll()
        {
            var hotels =  dbContext.Hoteles.ToList();
            return hotels;
        }

        [HttpGet("getCentrosConsumo")]
        public List<Centros_consumo> GetCentrosConsumo()
        {
            var centros_consumos = dbContext.Centros_Consumo.ToList();
            return centros_consumos;
        }
        [HttpGet("getCentroConsumoDetalles")]
        public List<Centros_consumo_detalles> GetCentroConsumoDetalles()
        {
            var centros_consumos_detalles = dbContext.Centros_Consumo_Detalles.ToList();
            return centros_consumos_detalles;
        }
        [HttpGet("getCentroConsumoHorarios")]
        public List<Centros_consumo_horarios> GetCentroConsumoHorarios()
        {
            var centros_consumos_horarios = dbContext.Centros_Consumo_Horarios.ToList();
            return centros_consumos_horarios;
        }
        [HttpGet("getCategorias")]
        public List<Categorias> GetCategorias()
        {
            var categorias = dbContext.Categorias.ToList();
             return categorias;
        }

        [HttpGet("getOsais")]
        public List<RestaurantOasis> ListRestaurant(int categoria) {
           var oa  = (from h in dbContext.Hoteles
                      join ccd in dbContext.Centros_Consumo_Detalles on h.id equals ccd.hotel_id
                      join cc in dbContext.Centros_Consumo on ccd.centro_consumo_id equals cc.id
                      join c in dbContext.Categorias on cc.categoria_id  equals c.id
                      join ch in dbContext.Centros_Consumo_Horarios on cc.id equals ch.centro_consumo_id
                      where h.id==1 && cc.categoria_id==categoria
                        select new RestaurantOasis()
                      {  Name = cc.nombre,
                            Categoria = c.categoria,
                            Horario = string.Join(" ", ch.hora_inicio.ToString(), ch.hora_final.ToString()),
                            Concepto = cc.concepto_es,
                            Attachment=cc.img_portada,
                            Logo = cc.logo
                        }).Distinct().ToList();
            return oa;
        }
    }
}
