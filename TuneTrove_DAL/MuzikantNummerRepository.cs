using Microsoft.Extensions.Configuration;
using MySqlConnector;
using TuneTrove_Logic.DAL_Interfaces;

namespace TuneTrove_DAL;

public class MuzikantNummerRepository : IMuzikantNummerRepository
{
    private string _connectionString;
    private readonly MySqlConnection _connection;
    public MuzikantNummerRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("connectionString");
        _connection = new MySqlConnection(_connectionString);
    }

    public List<int> GetNummers(int muzikantId)
    {
        _connection.Open();
        string query = "Select * FROM MuzikantNummer WHERE Muzikant_Id = @muzikantId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@muzikantId", muzikantId);
        using MySqlDataReader reader = command.ExecuteReader();

        List<int> Nummers = new List<int>();
        while (reader.Read())
        {
            Nummers.Add((int)reader["Nummer_Id"]);
        }
        _connection.Close();
		return Nummers;
    }

    public List<int> GetMuzikanten(int NummerId)
    {
        _connection.Open();
        string query = "Select * FROM MuzikantNummer WHERE Nummer_Id = @NummerId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@NummerId", NummerId);
        using MySqlDataReader reader = command.ExecuteReader();

        List<int> setlists = new List<int>();
        while (reader.Read())
        {
            setlists.Add((int)reader["Muzikant_Id"]);
        }
        _connection.Close();
		return setlists;
    }

    public void PostConnection(int muzikantId, int NummerId)
    {
        _connection.Open();
        string query = "INSERT INTO MuzikantNummer (Nummer_Id, Muzikant_Id) VALUES (@NummerId, @muzikantId)";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@NummerId", NummerId);
        command.Parameters.AddWithValue("@muzikantId", muzikantId);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void RemoveConnection(int muzikantId, int NummerId)
    {
        _connection.Open();
        string query = "DELETE FROM MuzikantNummer WHERE Nummer_Id = @NummerId AND Muzikant_Id = @muzikantId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@NummerId", NummerId);
        command.Parameters.AddWithValue("@muzikantId", muzikantId);
        command.ExecuteNonQuery();
        _connection.Close();
    }
}