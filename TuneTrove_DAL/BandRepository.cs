using MySqlConnector;
using TuneTrove_Logic.DAL_Interfaces;
using TuneTrove_Logic.DTO;
using Microsoft.Extensions.Configuration;

namespace TuneTrove_DAL;

public class BandRepository : IBandRepository
{
    private string _connectionString;
    private readonly MySqlConnection _connection;
    public BandRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("connectionString");
        _connection = new MySqlConnection(_connectionString);
    }

    public List<BandDTO> GetAllBands()
    {
        List<BandDTO> bandDTOs = new List<BandDTO>();
        _connection.Open();
        string query = "Select * FROM Band";
        using MySqlCommand command = new MySqlCommand(query, _connection);

        using MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            bandDTOs.Add(new BandDTO(
                (int)reader["Id"],
                (int)reader["BandLeider"]
            ));
        }
        _connection.Close();
        return bandDTOs;
    }

    public BandDTO GetBandById(int id)
    {
        BandDTO bandDTO = new BandDTO(0,0);
        _connection.Open();
        string query = "Select * FROM Band";
        using MySqlCommand command = new MySqlCommand(query, _connection);

        using MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            bandDTO = new BandDTO(
                (int)reader["Id"],
                (int)reader["BandLeider"]
            );
        }

        if (bandDTO.Id == 0 && bandDTO.BandLeider == 0)
        {
            throw new ArgumentException("Values not found", nameof(bandDTO));
        }
        else
        {
            return bandDTO;
        }
    }

    public void PostBand(BandDTO band)
    {
        _connection.Open();
        string query = "INSERT INTO Band (Id, BandLeider) VALUES (@id, @bandLeider)";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", band.Id);
        command.Parameters.AddWithValue("@bandLeider", band.BandLeider);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void RemoveBand(int id)
    {
        string query = "DELETE * FROM Band WHERE Id = @id";
        _connection.Open();
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void EditBand(BandDTO band)
    {
        _connection.Open();
        string query = "UPDATE Band SET BandLeider = @bandLeider WHERE Id = @id";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", band.Id);
        command.Parameters.AddWithValue("@bandLeider", band.BandLeider);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public List<int> GetSetlistIds(int bandID)
    {
        _connection.Open();
        string query = "SELECT * FROM Band INNER JOIN BandSetlist ON Band.Id = BandSetlist.Band_Id WHERE Band.Id = @id";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", bandID);
        using MySqlDataReader reader = command.ExecuteReader();

        List<int> setlistIds = new List<int>();
        while (reader.Read())
        {
            setlistIds.Add((int)reader["Setlist_Id"]);
        }

        return setlistIds;
    }
}