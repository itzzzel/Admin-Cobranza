using App_Cobranza.Models;
using App_Cobranza.Models.ViewModels.Cliente;
using App_Cobranza.Models.ViewModels.Pago;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace App_Cobranza.Controllers
{
    [Authorize]
    public class CobranzaController : Controller
    {
       
        public IActionResult BuscarCliente()
        {
            return View("Buscar", new BuscarVM
            {
                busqueda = "",
                id = "",
                Resultados = new List<ClienteResultadoVM>() 
            });
        }

        [HttpPost]
        public IActionResult BuscarCliente(BuscarVM model)
        {
            ViewBag.Searched = true; // Para controlar el mensaje "No hay resultados"

            if (ModelState.IsValid)
            {
                /* 
                 * Cuando estés listo para conectar a BD:
                 * 1. Inyecta tu DbContext o repositorio
                 * 2. Implementa la consulta real aquí
                 * Ejemplo:
                 * model.Resultados = _dbContext.Clientes
                 *     .Where(c => c.Nombre.Contains(model.Busqueda) || 
                 *                c.IdCliente == model.IdCliente)
                 *     .Select(c => new ClienteResultadoVM { ... })
                 *     .ToList();
                 */

                // Por ahora devuelve lista vacía
                model.Resultados = new List<ClienteResultadoVM>();
                return View("Buscar", model);
            }

            return View("Buscar", model);
        }

        public IActionResult PerfilCliente(string id)
        {
            /* 
             * Lógica real para implementar después:
             * var cliente = _dbContext.Clientes.Find(id);
             * var productos = _dbContext.Productos.Where(p => p.IdCliente == id).ToList();
             */

            return View("Perfil", new PerfilVM
            {
                idcliente = id,
                nombrecliente = "", // Se llenará desde BD después
                productos = new List<ProductoVM>() // Lista vacía
            });
        }

        // Sección Pagos
        public IActionResult AbonarPago(string idCliente, string idFactura)
        {
            return View("Abonar", new AbonarVM
            {
                idcliente = idCliente,
                idfactura = idFactura,
                nombre = "" // Se obtendrá de BD después
            });
        }

        [HttpPost]
        public IActionResult AbonarPago(AbonarVM model)
        {
            if (ModelState.IsValid)
            {
                /* 
                 * Lógica real para implementar:
                 * 1. Registrar el pago en BD
                 * 2. Actualizar saldos
                 */
                return RedirectToAction("HistorialPagos", new { idCliente = model.idcliente });
            }
            return View("Abonar", model);
        }

        public IActionResult HistorialPagos(string idCliente)
        {
            /* 
             * Consulta real para implementar:
             * var historial = _dbContext.Pagos
             *     .Where(p => p.IdCliente == idCliente)
             *     .OrderByDescending(p => p.Fecha)
             *     .ToList();
             */

            ViewBag.NombreCliente = ""; // Se obtendrá de BD después
            return View("Historial", new List<HistorialVM>()); // Lista vacía
        }
    }
}