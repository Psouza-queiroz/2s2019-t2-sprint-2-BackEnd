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
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=RoteiroFilmes;User Id=sa;Pwd=132;";

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
                            IdGeneros = Convert.ToInt32(sdr["IdGenero"]),
                            Nome = sdr["Nome"].ToString()
                        };
                        Generos.Add(genero);

                    }
                }
            }
            return Generos;
        }
        
        public void Cadastrar(GenerosDomain generos)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                string Query = "INSERT INTO Generos (Nome) VALUES (@Nome)";

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", generos.Nome);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public GenerosDomain BuscarPorId(int id)
        {
            string Query = "SELECT IdGenero, Nome from Generos WHERE = @Id";


            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                con.Open();
                SqlDataReader sdr;
                
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                    sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            GenerosDomain generos = new GenerosDomain()
                            {
                                IdGeneros = Convert.ToInt32(sdr["Id"]),
                                Nome = sdr["Nome"].ToString()
                            };
                return generos;
                        
                        }
                    }
                    return null;
                }
            }
            
        }
        
     }
}
