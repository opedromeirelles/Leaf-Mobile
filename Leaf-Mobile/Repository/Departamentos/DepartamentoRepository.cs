using Leaf_Mobile.Data;
using Leaf_Mobile.Model;
using Microsoft.Data;
using Microsoft.Data.SqlClient;

namespace Leaf.Repository.Departamentos
{
    public class DepartamentoRepository
    {
        private readonly DbConnectionManager _dbConnectionManager;

        public DepartamentoRepository(DbConnectionManager dbConnectionManager)
        {
            _dbConnectionManager = dbConnectionManager;
        }

       
        public Departamento? GetDepartamento(int idUsuario)
        {
            using (SqlConnection conn = _dbConnectionManager.GetConnection())
            {
                //Pego o departamento especifico do meu usuario
                string sql = @"Select d.iddpto, d.descricao from departamento d
                               inner join usuario u on d.iddpto = u.id_dpto 
                               where u.idusuario = @idUsuario";

                try
                {
					SqlCommand command = new SqlCommand(sql, conn);
					command.Parameters.AddWithValue("@idUsuario", idUsuario);

					SqlDataReader reader = command.ExecuteReader();

					if (reader.Read())
					{
						Departamento departamento = new Departamento
						{
							IdDpto = Convert.ToInt32(reader["iddpto"]),
							Descricao = reader["descricao"].ToString()
						};

						if (departamento != null)
						{
							return departamento;
						}
					}

					return null;

				}
                catch (SqlException ex)
                {

                    throw new Exception("Não foi possivel buscar o departamento do usuario. " + ex.Message);
                }
                

            }

        }
    }
}
