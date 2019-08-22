using Senai.Sstop.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Repositories
{
    public class ArtistaRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_SStop;User Id=sa;Pwd=132;";

         public List<ArtistaDomain> Listar()
        {
            List<ArtistaDomain> artistas = new List<ArtistaDomain>();

            string Query = "SELECT A.IdArtitas, A.Nome, E.IdEstilos, E.Nome AS NomeEstilo FROM Artistas AS A INNER JOIN Estilos AS E ON A.IdEstilos = E.IdEstilos;";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        ArtistaDomain Artista = new ArtistaDomain
                        {
                            IdArtistas = Convert.ToInt32(sdr["IdArtitas"]),
                            Nome = sdr["Nome"].ToString(),
                            Estilo = new EstiloDomain
                            {
                                IdEstilo = Convert.ToInt32(sdr["IdEstilos"]),
                                Nome = sdr["Nome"].ToString()
                            }
                        };
                        artistas.Add(Artista);
                    }
                }
                return artistas;
            }
        }

        public void Cadastrar (ArtistaDomain artistaDomain)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "INSERT INTO Artistas(Nome, IdEstilos) VALUES(@Nome , @IdEstilos)";

                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@Nome", artistaDomain.Nome);
                cmd.Parameters.AddWithValue("@IdEstilos", artistaDomain.EstiloId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        
    }
}
    

