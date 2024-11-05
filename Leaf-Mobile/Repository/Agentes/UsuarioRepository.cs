using Leaf_Mobile.Data;
using Leaf_Mobile.Model;
using Microsoft.Data;
using Microsoft.Data.SqlClient;

namespace Leaf.Repository.Agentes
{
    public class UsuarioRepository
    {
        private readonly DbConnectionManager _dbConnectionManager;

        public UsuarioRepository(DbConnectionManager dbConnectionManager)
        {
            _dbConnectionManager = dbConnectionManager;
        }

        // Método auxiliar para mapear o resultado do SqlDataReader para um objeto usuário
        private Usuario MapearUsuario(SqlDataReader reader)
        {
			return new Usuario
			{
				IdUsuario = reader["idusuario"] != DBNull.Value ? Convert.ToInt32(reader["idusuario"]) : 0,
				Nome = reader["nome"] != DBNull.Value ? reader["nome"].ToString() : string.Empty,
				Login = reader["login"] != DBNull.Value ? reader["login"].ToString() : string.Empty,
				Senha = reader["senha"] != DBNull.Value ? reader["senha"].ToString() : string.Empty,
				Status = reader["status"] != DBNull.Value ? Convert.ToInt32(reader["status"]) : 0,
				IdDpto = reader["id_dpto"] != DBNull.Value ? Convert.ToInt32(reader["id_dpto"]) : 0,
				Departamento = new Departamento
				{
					IdDpto = reader["id_dpto"] != DBNull.Value ? Convert.ToInt32(reader["id_dpto"]) : 0,
					Descricao = reader["descricao"] != DBNull.Value ? reader["descricao"].ToString() : string.Empty
				}
			};

		}

		// VALIDAR USUÁRIO
		public Usuario ValidarUsuario(string username, string senha)
        {

            string sql = @"SELECT u.idusuario, u.nome, u.login, u.senha, u.status, u.id_dpto, d.descricao
                               FROM Usuario u
                               INNER JOIN Departamento d ON u.id_dpto = d.idDpto
                               WHERE login = @username and senha = @senha";

            using (SqlConnection conn = _dbConnectionManager.GetConnection())
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@senha", senha);

                try
                {
                    Usuario usuario = new Usuario();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
						usuario = MapearUsuario(reader);
                        return usuario;
                    }

                    return usuario ?? new Usuario();
                }
                catch (SqlException ex)
                {

                    throw new Exception("Erro ao consultar usuario, erro: " + ex.Message);
                }

            }
        }

        // GET USUÁRIO
        public async Task<Usuario> GetUsuarioById(int id)
        {
            using (SqlConnection conn = _dbConnectionManager.GetConnection())
            {
                // Fazer o join com a tabela Departamento
                string sql = @"SELECT u.idusuario, u.nome, u.login, u.senha, u.status, u.id_dpto, d.descricao
                               FROM Usuario u
                               INNER JOIN Departamento d ON u.id_dpto = d.idDpto
                               WHERE u.idusuario = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return MapearUsuario(reader);
                }
                else
                {
                    return new Usuario();
                }

            }
        }

    }
}
