using Microsoft.Extensions.Configuration;
using MySqlConnector;
using TuneTrove_Logic.IRepositories;
using TuneTrove_Logic.Models;

namespace TuneTrove_DAL.Repositories;

public class BandRepository : IBandRepository
{
    private string _connectionString;
    private readonly MySqlConnection _connection;
    public BandRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("connectionString");
        _connection = new MySqlConnection(_connectionString);
    }
    public List<Band> GetAllBands()
    {
        List<Band> bands = new List<Band>();
        _connection.Open();
        string query = "SELECT * FROM Band B " +
                       "CROSS JOIN MuzikantBand MB ON MB.Band_Id = B.Id";
        
        using MySqlCommand command = new MySqlCommand(query, _connection);
        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Band tempBand = new Band(
                (int)reader["Id"],
                reader["Naam"].ToString(),
                (int)reader["BandLeider"]
            );
            bands.Add(tempBand);
        }
        _connection.Close();
        return bands;
    }

    public List<Band> GetBandPage(int pageNum, int pageSize)
    {
        int offset = pageNum * pageSize;
        List<Band> bands = new List<Band>();
        _connection.Open();
        string query = "SELECT * FROM Band B LIMIT @pageSize OFFSET @offset";

        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@pageSize", pageSize);
        command.Parameters.AddWithValue("@offset", offset);
        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Band tempBand = new Band(
                (int)reader["Id"],
                reader["Naam"].ToString(),
                (int)reader["BandLeider"]
            );
            bands.Add(tempBand);
        }
        _connection.Close();
        return bands;
    }

    public Band GetBand(int bandId)
    {
        Band band = null;
        _connection.Open();
        string query = "SELECT * FROM Band B WHERE B.Id = @id";

        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", bandId);
        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            band = new Band(
                (int)reader["Id"],
                reader["Naam"].ToString(),
                (int)reader["BandLeider"]
            );
        }
        _connection.Close();
        if (band != null)
            return band;
        throw new Exception("failed to retrieve band");
    }

    public List<Band> GetBandsByMuzikantId(int muzikantId)
    {
        List<Band> bands = new List<Band>();
        _connection.Open();
        string query = "SELECT * FROM Band B " +
                       "CROSS JOIN MuzikantBand MB ON MB.Band_Id = B.Id WHERE MB.Muzikant_Id = @muzikantId";

        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@muzikantId", muzikantId);
        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Band tempBand = new Band(
                (int)reader["Id"],
                reader["Naam"].ToString(),
                (int)reader["BandLeider"]
            );
            bands.Add(tempBand);
        }
        _connection.Close();
        return bands;
    }

    public List<Band> GetBandsBySetlistId(int setlistId)
    {
        List<Band> bands = new List<Band>();
        _connection.Open();
        string query = "SELECT * FROM Band B " +
                       "CROSS JOIN BandSetlist BS ON BS.Band_Id = B.Id WHERE BS.Setlist_Id = @setlistId";

        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@setlistId", setlistId);
        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Band tempBand = new Band(
                (int)reader["Id"],
                reader["Naam"].ToString(),
                (int)reader["BandLeider"]
            );
            bands.Add(tempBand);
        }
        _connection.Close();
        return bands;
    }

    public void UpdateBand(Band newBand, int bandId)
    {
        _connection.Open();
        string query = "UPDATE Band SET BandLeider = @bandLeider, Naam = @Naam WHERE Id = @id";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", bandId);
        command.Parameters.AddWithValue("@Naam", newBand.GiveName());
        command.Parameters.AddWithValue("@bandLeider", newBand.GiveBandleiderId());
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void DeleteBand(int bandId)
    {
        string query = "DELETE FROM Band WHERE Id = @id";
        _connection.Open();
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", bandId);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void AddBand(Band newBand)
    {
        _connection.Open();
        string query = "INSERT INTO Band (Id, Naam, BandLeider) VALUES (@id, @Naam, @bandLeider)";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", newBand.GiveId());
        command.Parameters.AddWithValue("@Naam", newBand.GiveName());
        command.Parameters.AddWithValue("@bandLeider", newBand.GiveBandleiderId());
        command.ExecuteNonQuery();
        _connection.Close();
    }
}