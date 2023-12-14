using Microsoft.AspNetCore.Mvc;
using PrimerNet.Models;
using System.Diagnostics;
using System.Data.SqlClient;
namespace PrimerNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly string cadenaSQL;

        public HomeController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("CadenaSQL");
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult ListaProductos()
        {
            List<Productos> lista = new List<Productos>();
            using (var conexion = new SqlConnection(cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_Producto", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Productos
                        {
                            idProducto = Convert.ToInt32(dr["idProducto"]),
                            Nombre = dr["nombre"].ToString(),
                            Categoria = Convert.ToInt32(dr["categoria"]),
                            SubCategorias = Convert.ToInt32(dr["subcategoria"]),
                            idVendedor = Convert.ToInt32(dr["idVendedor"]),
                            Calificacion = float.Parse(dr["calificacion"].ToString()),
                            Unidades = Convert.ToInt32(dr["unidades"]),
                            Imagen = dr["imagen"].ToString(),
                            Descripcion = dr["descripcion"].ToString(),
                        });
                    }
                }
            }
            return Json(new { data = lista });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}