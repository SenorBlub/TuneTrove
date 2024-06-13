using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using TuneTrove_Logic.DTOs;
using TuneTrove_Logic.IRepositories;
using TuneTrove_Logic.Models;

namespace TuneTrove_DAL.Repositories;

public class SetlistRepository : ISetlistRepository
{
    private string _connectionString;
    private readonly MySqlConnection _connection;
    public SetlistRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("connectionString");
        _connection = new MySqlConnection(_connectionString);
    }
    public List<Setlist> GetAllSetlists()
    {
        _connection.Open();
        string query = "SELECT * FROM Setlist S";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        using MySqlDataReader reader = command.ExecuteReader();
        List<Setlist> setlists = new List<Setlist>();
        while (reader.Read())
        {
            setlists.Add(new Setlist((int)reader["Id"], (DateTime)reader["Datum"]));
        }
        _connection.Close();
        return setlists;
    }

    public List<Setlist> GetSetlistPage(int pageNum, int pageSize)
    {
        int offset = pageSize * pageNum;
        _connection.Open();
        string query = "SELECT * FROM Setlist S LIMIT @pageSize OFFSET @offset";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@pageSize", pageSize);
        command.Parameters.AddWithValue("@offset", offset);
        using MySqlDataReader reader = command.ExecuteReader();
        List<Setlist> setlists = new List<Setlist>();
        while (reader.Read())
        {
            setlists.Add(new Setlist((int)reader["Id"], (DateTime)reader["Datum"]));
        }
        _connection.Close();
        return setlists;
    }

    public Setlist GetSetlist(int id)
    {
        _connection.Open();
        string query = "SELECT * FROM Setlist S WHERE S.Id = @id";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", id);
        using MySqlDataReader reader = command.ExecuteReader();
        Setlist setlist = null;
        while (reader.Read())
        {
            setlist = new Setlist((int)reader["Id"], (DateTime)reader["Datum"]);
        }
        _connection.Close();
        if(setlist != null)
            return setlist;
        throw new Exception("Failed to retrieve setlist");
    }

    public List<Setlist> GetSetlistsByBandId(int bandId)
    {
        _connection.Open();
        string query = "SELECT * FROM Setlist S CROSS JOIN BandSetlist BS ON BS.Setlist_Id = S.Id WHERE BS.Band_Id = @bandId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@bandId", bandId);
        using MySqlDataReader reader = command.ExecuteReader();
        List<Setlist> setlists = new List<Setlist>();
        while (reader.Read())
        {
            setlists.Add(new Setlist((int)reader["Id"], (DateTime)reader["Datum"]));
        }
        _connection.Close();
        return setlists;
    }

    public List<Setlist> GetSetlistsByMuzikantId(int muzikantId)
    {
        _connection.Open();
        string query = "SELECT * FROM Setlist S CROSS JOIN MuzikantSetlist MS ON MS.Setlist_Id = S.Id WHERE MS.Muzikant_Id = @muzikantId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@muzikantId", muzikantId);
        using MySqlDataReader reader = command.ExecuteReader();
        List<Setlist> setlists = new List<Setlist>();
        while (reader.Read())
        {
            setlists.Add(new Setlist((int)reader["Id"], (DateTime)reader["Datum"]));
        }
        _connection.Close();
        return setlists;
    }

    public List<Setlist> GetSetlistsByNummerId(int nummerId)
    {
        _connection.Open();
        string query = "SELECT * FROM Setlist S CROSS JOIN NummerSetlist NS ON NS.Setlist_Id = S.Id WHERE NS.Nummer_Id = @nummerId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@nummerId", nummerId);
        using MySqlDataReader reader = command.ExecuteReader();
        List<Setlist> setlists = new List<Setlist>();
        while (reader.Read())
        {
            setlists.Add(new Setlist((int)reader["Id"], (DateTime)reader["Datum"]));
        }
        _connection.Close();
        return setlists;
    }

    public void UpdateSetlist(Setlist newSetlist, int setlistId)
    {
        _connection.Open();
        string query = "UPDATE Setlist SET Datum = @datum, WHERE Id = @id";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", newSetlist.GiveId());
        command.Parameters.AddWithValue("@datum", newSetlist.GiveDate());
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void DeleteSetlist(int id)
    {
        _connection.Open();
        string query = "DELETE FROM Setlist WHERE Id = @id";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void AddSetlist(Setlist newSetlist)
    {
        _connection.Open();
        string query = "INSERT INTO Setlist (Id, Datum) VALUES (@id, @datum)";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", newSetlist.GiveId());
        command.Parameters.AddWithValue("@datum", newSetlist.GiveDate());
        command.ExecuteNonQuery();
        _connection.Close();
    }
}