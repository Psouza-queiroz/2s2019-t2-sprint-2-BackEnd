using Senai.Sstop.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Repositories
{
    public class EstiloRepository
    {
        // aonde que sera feita essa comunicacao
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_SStop;User Id=sa;Pwd=132";
        public List<EstiloDomain> Listar()
        {
            //Buscar os dados no banco de dados
            List<EstiloDomain> estilos = new List<EstiloDomain>();

            //Chamar o banco
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdEstilos, Nome From Estilos";

                // abrir conexao
                con.Open();

                // Declaro para percorrer a lista
                SqlDataReader sdr;


                // Comando a ser executado em qual conexao
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    // pegar os valores da tabela do banco de dados e armazenar dentro da aplicacao do backend
                    sdr = cmd.ExecuteReader();

                    while(sdr.Read())
                    {
                        EstiloDomain estilo = new EstiloDomain
                        {
                            IdEstilo = Convert.ToInt32(sdr["IdEstilos"]),
                            Nome = sdr["Nome"].ToString()
                        };
                    }
                }

                    //Executar o Select
                    //Retornar as informacoes

                    return estilos;
            }
        }

    }
}
