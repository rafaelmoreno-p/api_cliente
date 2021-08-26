using Domain;
using Domain.ClienteAggregates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryCliente
{
    public interface IRepositoryCliente
    {
        Task<EntidadResponse> InsertCliente(RequestCliente requestCliente);
        Task<List<EntidadCliente>> GetCliente();
        Task<EntidadCliente> GetClienteByID(int id);
    }
}
