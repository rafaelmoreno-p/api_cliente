using Application.ClienteAppService;
using Domain;
using Domain.ClienteAggregates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace api_cliente.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {

        private readonly IClienteAppService _ClienteAppService;
        private readonly IConfiguration _configuration;
        public ClienteController(IConfiguration configuration)
        {
            _configuration = configuration;
            _ClienteAppService = new ClienteAppService(configuration);
        }

        [HttpPost]
        [Route("InsertarCliente")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertarCliente([FromBody] RequestCliente requestCliente)
        {
            EntidadResponse entidadResponse = await _ClienteAppService.InsertCliente(requestCliente);
            return Ok(new
            {
                Inserccion = entidadResponse.AffectedRows,
                ID = entidadResponse.ID,
                Mensaje = entidadResponse.Description
            });
        }
        [HttpGet]
        [Route("ListarCliente")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ListarCliente()
        {
            List<EntidadCliente> listaCliente = await _ClienteAppService.GetCliente();
            return Ok(new
            {
                clientes = listaCliente,
                exito = true,
                mensajeError = ""
            });
        }
        [HttpGet]
        [Route("ObtenerCliente")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ObtenerCliente(int id)
        {
            EntidadCliente entidadCliente = await _ClienteAppService.GetClienteByID(id);
            return Ok(new
            {
                cliente = entidadCliente,
                exito = true,
                mensajeError = ""
            });
        }
    }
}
