using Domain;
using Domain.ClienteAggregates;
using Microsoft.Extensions.Configuration;
using Repository.RepositoryCliente;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClienteAppService
{
    public class ClienteAppService : ApplicationBase, IClienteAppService
    {
        private readonly IRepositoryCliente _RepositoryCliente;
        public ClienteAppService(IConfiguration configuration) : base(configuration)
        {
            _RepositoryCliente = new RepositoryCliente(configuration);
        }

        public async Task<List<EntidadCliente>> GetCliente()
        {
            return await _RepositoryCliente.GetCliente();
        }

        public async Task<EntidadCliente> GetClienteByID(int id)
        {
            return await _RepositoryCliente.GetClienteByID(id);
        }

        public async Task<EntidadResponse> InsertCliente(RequestCliente requestCliente)
        {
            return await _RepositoryCliente.InsertCliente(requestCliente);
        }
    }
}
