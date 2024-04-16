using Microsoft.Extensions.Configuration;
using MySqlConnector;
using TuneTrove_Logic.DAL_Interfaces;

namespace TuneTrove_DAL;

public class MuzikantSetlistRepository : IMuzikantSetlistRepository
{
    private string _connectionString;
    private readonly MySqlConnection _connection;
    public MuzikantSetlistRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("connectionString");
        _connection = new MySqlConnection(_connectionString);
    }

    public List<int> GetSetlists(int muzikantId)
    {
        _connection.Open();
        string query = "Select * FROM MuzikantSetlist WHERE Muzikant_Id = @muzikantId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@muzikantId", muzikantId);
        using MySqlDataReader reader = command.ExecuteReader();

        List<int> Setlists = new List<int>();
        while (reader.Read())
        {
            Setlists.Add((int)reader["Setlist_Id"]);
        }
        _connection.Close();
		return Setlists;
    }

    public List<int> GetMuzikanten(int SetlistId)
    {
        _connection.Open();
        string query = "Select * FROM MuzikantSetlist WHERE Setlist_Id = @SetlistId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@SetlistId", SetlistId);
        using MySqlDataReader reader = command.ExecuteReader();

        List<int> setlists = new List<int>();
        while (reader.Read())
        {
            setlists.Add((int)reader["Muzikant_Id"]);
        }
        _connection.Close();
		return setlists;
    }

    public void PostConnection(int muzikantId, int SetlistId)
    {
        _connection.Open();
        string query = "INSERT INTO MuzikantSetlist (Setlist_Id, Muzikant_Id) VALUES (@SetlistId, @muzikantId)";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@SetlistId", SetlistId);
        command.Parameters.AddWithValue("@muzikantId", muzikantId);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void RemoveConnection(int muzikantId, int SetlistId)
    {
        _connection.Open();
        string query = "DELETE * FROM MuzikantSetlist WHERE Setlist_Id = @SetlistId AND Muzikant_Id = @muzikantId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@SetlistId", SetlistId);
        command.Parameters.AddWithValue("@muzikantId", muzikantId);
        command.ExecuteNonQuery();
        _connection.Close();
    }
}