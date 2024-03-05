using Microsoft.Extensions.Configuration;
using MySqlConnector;
using TuneTrove_Logic.DAL_Interfaces;
using TuneTrove_Logic.DTO;

namespace TuneTrove_DAL;

public class MuzikantRepository : IMuzikantRepository
{
    private string _connectionString;
    private readonly MySqlConnection _connection;
    public MuzikantRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("connectionString");
        _connection = new MySqlConnection(_connectionString);
    }
    public List<MuzikantDTO> GetAllMuzikanten()
    {
        _connection.Open();
        string query = "SELECT * FROM Muzikant";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        using MySqlDataReader reader = command.ExecuteReader();
        List<MuzikantDTO> muzikanten = new List<MuzikantDTO>();
        while (reader.Read())
        {
            muzikanten.Add(
                new MuzikantDTO((int)reader["Id"], reader["Naam"].ToString(), reader["Instrument"].ToString()));
        }
        return muzikanten;
    }

    public MuzikantDTO GetMuzikantById(int id)
    {
        _connection.Open();
        MuzikantDTO muzikant = null;
        string query = "SELECT * FROM Muzikant WHERE Id = @id";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", id);
        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            muzikant = new MuzikantDTO((int)reader["Id"], reader["Naam"].ToString(), reader["Instrument"].ToString());
        }
        _connection.Close();
        return muzikant;
    }

    public void PostMuzikant(MuzikantDTO muzikant)
    {
        _connection.Open();
        string query = "INSERT INTO Muzikant (Id, Naam, Instrument) VALUES (@id, @naam, @instrument)";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", muzikant.Id);
        command.Parameters.AddWithValue("@naam", muzikant.Name);
        command.Parameters.AddWithValue("@instrument", muzikant.Instrument);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void RemoveMuzikant(int id)
    {
        _connection.Open();
        string query = "DELETE * FROM Muzikant WHERE Id = @id";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void EditMuzikant(MuzikantDTO muzikant)
    {
        _connection.Open();
        string query = "UPDATE Muzikant SET Naam = @naam, Instrument = @instrument WHERE Id = @id";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", muzikant.Id);
        command.Parameters.AddWithValue("@naam", muzikant.Name);
        command.Parameters.AddWithValue("@instrument", muzikant.Instrument);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public List<MuzikantDTO> SearchMuzikant(string searchQuery)
    {
        _connection.Open();
        string query = "SELECT * FROM Muzikant WHERE Naam LIKE @searchQuery";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@searchQuery", $"%{searchQuery}%");
        using MySqlDataReader reader = command.ExecuteReader();
        List<MuzikantDTO> muzikanten = new List<MuzikantDTO>();
        while (reader.Read())
        {
            muzikanten.Add(
                new MuzikantDTO((int)reader["Id"], reader["Naam"].ToString(), reader["Instrument"].ToString()));
        }
        return muzikanten;
    }
}