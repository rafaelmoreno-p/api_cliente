using Domain;
using Domain.ClienteAggregates;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryCliente
{
    public class RepositoryCliente : RepositoryBase, IRepositoryCliente
    {
        public RepositoryCliente(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<List<EntidadCliente>> GetCliente()
        {
            var result = new List<EntidadCliente>();
            using (MySqlConnection cnx = new MySqlConnection(base.GetCadenaConexion()))
            {
                cnx.Open();
                using (MySqlCommand cmd = new MySqlCommand("usp_Cliente_List", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = await cmd.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        result.Add(new EntidadCliente
                        {
                            id = (int)reader["id"],
                            nombres = reader["nombres"].ToString(),
                            apellidos = reader["apellidos"].ToString(),
                            fecha_nacimiento = reader["fecha_nacimiento"].ToString(),
                            edad = reader["edad"].ToString()
                        }
                        ); ;
                    }
                }
            }
            return result;
        }

        public async Task<EntidadCliente> GetClienteByID(int id)
        {
            var result = new EntidadCliente();
            using (MySqlConnection cnx = new MySqlConnection(base.GetCadenaConexion()))
            {
                cnx.Open();
                using (MySqlCommand cmd = new MySqlCommand("usp_Cliente_ListByID", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_id", id);
                    var reader = await cmd.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        result = (new EntidadCliente
                        {
                            id = (int)reader["id"],
                            nombres = reader["nombres"].ToString(),
                            apellidos = reader["apellidos"].ToString(),
                            fecha_nacimiento = reader["fecha_nacimiento"].ToString(),
                            edad = reader["edad"].ToString()
                        }
                       ); ;
                    }
                }
            }
            return result;
        }

        public async Task<EntidadResponse> InsertCliente(RequestCliente requestCliente)
        {
            var result = new EntidadResponse();
            try
            {
                using (MySqlConnection cnx = new MySqlConnection(base.GetCadenaConexion()))
                {
                    cnx.Open();
                    using (MySqlCommand cmd = new MySqlCommand("usp_Cliente_Insert", cnx))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_id", 0).Direction=ParameterDirection.Output;
                        cmd.Parameters.AddWithValue("p_nombres", requestCliente.nombres);
                        cmd.Parameters.AddWithValue("p_apellidos", requestCliente.apellidos);
                        cmd.Parameters.AddWithValue("p_fecha_nacimiento", requestCliente.fecha_nacimiento);


                        result.AffectedRows = await cmd.ExecuteNonQueryAsync();
                        result.ID = (int)cmd.Parameters["p_id"].Value;
                        result.Description = result.AffectedRows > 0 ? "Registro creado" : "No se creo";
                    }
                }
            }
            catch (Exception ex)
            {
                result.AffectedRows = 0;
                result.ID = 0;
                result.ErrorCode = "ERROR";
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}
