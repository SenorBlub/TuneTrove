using Microsoft.Extensions.Configuration;
using MySqlConnector;
using TuneTrove_Logic.DAL_Interfaces;
using TuneTrove_Logic.DTO;

namespace TuneTrove_DAL;

public class SetlistRepository : ISetlistRepository
{
    private string _connectionString;
    private readonly MySqlConnection _connection;
    public SetlistRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("connectionString");
        _connection = new MySqlConnection(_connectionString);
    }
    public List<SetlistDTO> GetAllSetlists()
    {
        _connection.Open();
        string query = "SELECT * FROM Setlist";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        using MySqlDataReader reader = command.ExecuteReader();
        List<SetlistDTO> setlists = new List<SetlistDTO>();
        while (reader.Read())
        {
            setlists.Add(new SetlistDTO((int)reader["Id"], (DateTime)reader["Datum"]));
        }
        _connection.Close();
        return setlists;
    }

    public SetlistDTO GetSetlistById(int id)
    {
        _connection.Open();
        string query = "SELECT * FROM Setlist WHERE Id = @id";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", id);
        using MySqlDataReader reader = command.ExecuteReader();
        SetlistDTO setlist = null;
        while (reader.Read())
        {
            setlist = new SetlistDTO((int)reader["Id"], (DateTime)reader["Datum"]);
        }
        _connection.Close();
        return setlist;
    }

    public void PostSetlist(SetlistDTO setlist)
    {
        _connection.Open();
        string query = "INSERT INTO Setlist (Id, Datum) VALUES (@id, @datum)";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", setlist.Id);
        command.Parameters.AddWithValue("@datum", setlist.Datum);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void RemoveSetlist(int id)
    {
        _connection.Open();
        string query = "DELETE * FROM Setlist WHERE Id = @id";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void EditSetlist(SetlistDTO setlist)
    {
        _connection.Open();
        string query = "UPDATE Setlist SET Datum = @datum, WHERE Id = @id";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", setlist.Id);
        command.Parameters.AddWithValue("@datum", setlist.Datum);
        command.ExecuteNonQuery();
        _connection.Close();
    }

}