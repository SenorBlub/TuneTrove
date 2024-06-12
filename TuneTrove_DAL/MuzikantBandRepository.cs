using Microsoft.Extensions.Configuration;
using MySqlConnector;
using TuneTrove_Logic.DAL_Interfaces;

namespace TuneTrove_DAL;

public class MuzikantBandRepository : IMuzikantBandRepository
{
    private string _connectionString;
    private readonly MySqlConnection _connection;
    public MuzikantBandRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("connectionString");
        _connection = new MySqlConnection(_connectionString);
    }

    public List<int> GetBands(int muzikantId)
    {
        _connection.Open();
        string query = "Select * FROM MuzikantBand WHERE Muzikant_Id = @muzikantId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@muzikantId", muzikantId);
        using MySqlDataReader reader = command.ExecuteReader();

        List<int> bands = new List<int>();
        while (reader.Read())
        {
            bands.Add((int)reader["Band_Id"]);
        }
        _connection.Close();
		return bands;
    }

    public List<int> GetMuzikanten(int bandId)
    {
        _connection.Open();
        string query = "Select * FROM MuzikantBand WHERE Band_Id = @bandId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@bandId", bandId);
        using MySqlDataReader reader = command.ExecuteReader();

        List<int> setlists = new List<int>();
        while (reader.Read())
        {
            setlists.Add((int)reader["Muzikant_Id"]);
        }
        _connection.Close();
        return setlists;
    }

    public void PostConnection(int muzikantId, int bandId)
    {
        _connection.Open();
        string query = "INSERT INTO MuzikantBand (Band_Id, Muzikant_Id) VALUES (@bandId, @muzikantId)";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@bandId", bandId);
        command.Parameters.AddWithValue("@muzikantId", muzikantId);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void RemoveConnection(int muzikantId, int bandId)
    {
        _connection.Open();
        string query = "DELETE FROM MuzikantBand WHERE Band_Id = @bandId AND Muzikant_Id = @muzikantId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@bandId", bandId);
        command.Parameters.AddWithValue("@muzikantId", muzikantId);
        command.ExecuteNonQuery();
        _connection.Close();
    }
}