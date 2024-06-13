using Microsoft.Extensions.Configuration;
using MySqlConnector;
using TuneTrove_Logic.DTOs;
using TuneTrove_Logic.IRepositories;
using TuneTrove_Logic.Models;

namespace TuneTrove_DAL.Repositories;

public class MuzikantRepository : IMuzikantRepository
{
    private string _connectionString;
    private readonly MySqlConnection _connection;
    public MuzikantRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("connectionString");
        _connection = new MySqlConnection(_connectionString);
    }
    public List<Muzikant> GetAllMuzikants()
    {
        List<Muzikant> muzikanten = new List<Muzikant>();
        _connection.Open();
        string query = "SELECT * FROM Muzikant M";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            muzikanten.Add(
                new Muzikant((int)reader["Id"], reader["Naam"].ToString(), reader["Instrument"].ToString()));
        }
        _connection.Close();
        return muzikanten;
    }

    public List<Muzikant> GetMuzikantPage(int pageNum, int pageSize)
    {
        int offset = pageNum * pageSize;
        List<Muzikant> muzikanten = new List<Muzikant>();
        _connection.Open();
        string query = "SELECT * FROM Muzikant M LIMIT @pageSize OFFSET @offset";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@pageSize", pageSize);
        command.Parameters.AddWithValue("@offset", offset);
        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            muzikanten.Add(
                new Muzikant((int)reader["Id"], reader["Naam"].ToString(), reader["Instrument"].ToString()));
        }
        _connection.Close();
        return muzikanten;
    }

    public Muzikant GetMuzikant(int id)
    {
        Muzikant muzikant = null;
        _connection.Open();
        string query = "SELECT * FROM Muzikant M";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            muzikant = new Muzikant((int)reader["Id"], reader["Naam"].ToString(), reader["Instrument"].ToString());
        }
        _connection.Close();
        if(muzikant != null)
            return muzikant;
        throw new Exception("failed to retrieve muzikant");
    }

    public List<Muzikant> GetMuzikantsByBandId(int bandId)
    {
        List<Muzikant> muzikanten = new List<Muzikant>();
        _connection.Open();
        string query = "SELECT * FROM Muzikant M CROSS JOIN MuzikantBand MB ON MB.Muzikant_Id = M.Id WHERE MB.Band_Id = @bandId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@bandId", bandId);
        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            muzikanten.Add(
                new Muzikant((int)reader["Id"], reader["Naam"].ToString(), reader["Instrument"].ToString()));
        }
        _connection.Close();
        return muzikanten;
    }

    public List<Muzikant> GetMuzikantsBySetlistId(int setlistId)
    {
        List<Muzikant> muzikanten = new List<Muzikant>();
        _connection.Open();
        string query = "SELECT * FROM Muzikant M CROSS JOIN MuzikantSetlist MS ON MS.Muzikant_Id = M.Id WHERE MS.Setlist_Id = @setlistId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@setlistId", setlistId);
        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            muzikanten.Add(
                new Muzikant((int)reader["Id"], reader["Naam"].ToString(), reader["Instrument"].ToString()));
        }
        _connection.Close();
        return muzikanten;
    }

    public void UpdateMuzikant(Muzikant newMuzikant, int muzikantId)
    {
        _connection.Open();
        string query = "UPDATE Muzikant SET Naam = @naam, Instrument = @instrument WHERE Id = @id";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", newMuzikant.GiveId());
        command.Parameters.AddWithValue("@naam", newMuzikant.GiveName());
        command.Parameters.AddWithValue("@instrument", newMuzikant.GiveInstrument());
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void DeleteMuzikant(int muzikantId)
    {
        _connection.Open();
        string query = "DELETE FROM Muzikant WHERE Id = @id";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", muzikantId);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void AddMuzikant(Muzikant newMuzikant)
    {
        _connection.Open();
        string query = "INSERT INTO Muzikant (Id, Naam, Instrument) VALUES (@id, @naam, @instrument)";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", newMuzikant.GiveId());
        command.Parameters.AddWithValue("@naam", newMuzikant.GiveName());
        command.Parameters.AddWithValue("@instrument", newMuzikant.GiveInstrument());
        command.ExecuteNonQuery();
        _connection.Close();
    }
}