using Domain;
using Domain.ClienteAggregates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClienteAppService
{
    public interface IClienteAppService
    {
        Task<EntidadResponse> InsertCliente(RequestCliente requestCliente);
        Task<List<EntidadCliente>> GetCliente();
        Task<EntidadCliente> GetClienteByID(int id);
    }
}
