using Senai.Filmes.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repository
{
    public class GeneroRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_SStop;User Id=sa;Pwd=132;";

        List<GenerosDomain> Generos = new List<GenerosDomain>();

        public List<GenerosDomain> Listar()
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT * FROM Generos";
                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        GenerosDomain genero = new GenerosDomain
                        {
                            IdGeneros = Convert.ToInt32(sdr["IdGeneros"]),
                            Nome = sdr["Nome"].ToString()
                        };
                        Generos.Add(genero);

                    }
                }
            }
            return Generos;
        }
        


     }
}


















