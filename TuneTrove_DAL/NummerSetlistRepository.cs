using MySqlConnector;
using TuneTrove_Logic.DAL_Interfaces;

namespace TuneTrove_DAL;

public class NummerSetlistRepository : INummerSetlistRepository
{
    private string _connectionString;
    private readonly MySqlConnection _connection;
    public NummerSetlistRepository(string connectionString)
    {
        _connectionString = connectionString;
        _connection = new MySqlConnection(_connectionString);
    }

    public List<int> GetSetlists(int NummerId)
    {
        _connection.Open();
        string query = "Select * FROM NummerSetlist WHERE Nummer_Id = @NummerId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@NummerId", NummerId);
        using MySqlDataReader reader = command.ExecuteReader();

        List<int> Setlists = new List<int>();
        while (reader.Read())
        {
            Setlists.Add((int)reader["Setlist_Id"]);
        }

        return Setlists;
    }

    public List<int> GetNummers(int SetlistId)
    {
        _connection.Open();
        string query = "Select * FROM NummerSetlist WHERE Setlist_Id = @SetlistId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@SetlistId", SetlistId);
        using MySqlDataReader reader = command.ExecuteReader();

        List<int> setlists = new List<int>();
        while (reader.Read())
        {
            setlists.Add((int)reader["Nummer_Id"]);
        }

        return setlists;
    }

    public void PostConnection(int NummerId, int SetlistId)
    {
        _connection.Open();
        string query = "INSERT INTO NummerSetlist (Setlist_Id, Nummer_Id) VALUES (@SetlistId, @NummerId)";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@SetlistId", SetlistId);
        command.Parameters.AddWithValue("@NummerId", NummerId);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void RemoveConnection(int NummerId, int SetlistId)
    {
        _connection.Open();
        string query = "DELETE * FROM NummerSetlist WHERE Setlist_Id = @SetlistId AND Nummer_Id = @NummerId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@SetlistId", SetlistId);
        command.Parameters.AddWithValue("@NummerId", NummerId);
        command.ExecuteNonQuery();
        _connection.Close();
    }
}