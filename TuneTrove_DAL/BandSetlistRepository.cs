using Microsoft.Extensions.Configuration;
using MySqlConnector;
using TuneTrove_Logic.DAL_Interfaces;
using TuneTrove_Logic.Models;

namespace TuneTrove_DAL;

public class BandSetlistRepository : IBandSetlistRepository
{

    private string _connectionString;
    private readonly MySqlConnection _connection;
    public BandSetlistRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("connectionString");
        _connection = new MySqlConnection(_connectionString);
    }

    public List<int> GetBands(int setlistId)
    {
        _connection.Open();
        string query = "Select * FROM BandSetlist WHERE Setlist_Id = @setlistId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@setlistId", setlistId);
        using MySqlDataReader reader = command.ExecuteReader();

        List<int> bands = new List<int>();
        while (reader.Read())
        {
            bands.Add((int)reader["Band_Id"]);
        }
        _connection.Close();
		return bands;
    }

    public List<int> GetSetlists(int bandId)
    {
        _connection.Open();
        string query = "Select * FROM BandSetlist WHERE Band_Id = @bandId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@bandId", bandId);
        using MySqlDataReader reader = command.ExecuteReader();

        List<int> setlists = new List<int>();
        while (reader.Read())
        {
            setlists.Add((int)reader["Setlist_Id"]);
        }
        _connection.Close();
		return setlists;
    }

    public void PostConnection(int setlistId, int bandId)
    {
        _connection.Open();
        string query = "INSERT INTO BandSetlist (Band_Id, Setlist_Id) VALUES (@bandId, @setlistId)";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@bandId", bandId);
        command.Parameters.AddWithValue("@setlistId", setlistId);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void RemoveConnection(int setlistId, int bandId)
    {
        _connection.Open();
        string query = "DELETE * FROM BandSetlist WHERE Band_Id = @bandId AND Setlist_Id = @setlistId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@bandId", bandId);
        command.Parameters.AddWithValue("@setlistId", setlistId);
        command.ExecuteNonQuery();
        _connection.Close();
    }
}