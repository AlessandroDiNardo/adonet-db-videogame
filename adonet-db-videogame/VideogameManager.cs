using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public class VideogameManager
    {

        //metodo per aggiungere un videogioco al db
        public void AddGame(Videogame videogame)
        {
            string connStr = "Data Source=localhost;Initial Catalog=db-videogames;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    var query = "INSERT INTO videogames(name,overview,release_date,software_house_id) VALUES (@Name,@Overview,@ReleaseDate,@SoftwareHouseId) ";

                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", videogame.Name);
                    cmd.Parameters.AddWithValue("@Overview", videogame.Overview);
                    cmd.Parameters.AddWithValue("@ReleaseDate", videogame.ReleaseDate);
                    cmd.Parameters.AddWithValue("@SoftwareHouseId", videogame.SoftwareHouseId);
                    int res = cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        //metodo per ricerca un videgioco tramite id
        public Videogame? SearchById(long id)
        {
            string connStr = "Data Source=localhost;Initial Catalog=db-videogames;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    var query = "SELECT * FROM videogames  WHERE videogames.id=@Id";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);

                    using SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        var name = reader.GetString(0ùù);
                        var overview = reader.GetString(2);
                        var releaseDate = reader.GetDateTime(3);
                        var softwareHouseId = reader.GetInt64(4);

                        Videogame videogame = new Videogame(id, name, overview, releaseDate, softwareHouseId);
                        Console.WriteLine($"ID: {reader.GetInt64(0)}\nNome: {reader.GetString(1)}\nDescrizione: {reader.GetString(3)}\nData di Rilascio: {reader.GetDateTime(4)}");
                    }
                    Console.WriteLine("Nessun risultato trovato\n");
                    return null;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString);
                    return null;
                }
            }
        }

        //metodo di ricerca tramite il nome
        public Videogame? SearchByName(string Name)
        {
            string connStr = "Data Source=localhost;Initial Catalog=db-videogames;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    var query = "SELECT id, name, overview, release_date, software_house_id FROM videogames WHERE name = @Name";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", Name);

                    using SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var name = reader.GetString(1);
                        var overview = reader.GetString(2);
                        var releaseDate = reader.GetDateTime(3);
                        var softwareHouseId = reader.GetInt64(4);

                        Videogame videogame = new Videogame(id, name, overview , releaseDate, softwareHouseId);
                        Console.WriteLine($"ID: {reader.GetInt64(0)}\nNome: {reader.GetString(1)}\nDescrizione: {reader.GetString(3)}\nData di Rilascio: {reader.GetDateTime(4)}");
                        return videogame;
                    }
                    Console.WriteLine("Nessun risultato trovato!");
                    return null;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }
        }

        //metodo per eliminare il videogioco
        public bool DeleteGame(long id)
        {
            string connStr = "Data Source=localhost;Initial Catalog=db-videogames;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.Open();
                    var query = "DELETE FROM videogames WHERE id = @Id";
                    var cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue ("@Id", id); 

                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString);
                    return false;
                }
            }
        }
    }
}
