using Microsoft.Extensions.Configuration;
using MySqlConnector;
using TuneTrove_Logic.DTOs;
using TuneTrove_Logic.IRepositories;
using TuneTrove_Logic.Models;

namespace TuneTrove_DAL.Repositories;

public class NummerRepository : INummerRepository
{
    private string _connectionString;
    private readonly MySqlConnection _connection;
    public NummerRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("connectionString");
        _connection = new MySqlConnection(_connectionString);
    }
    public List<Nummer> GetAllNummers()
    {
        _connection.Open();
        string query = "SELECT * FROM Nummer N";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        using MySqlDataReader reader = command.ExecuteReader();
        List<Nummer> nummers = new List<Nummer>();
        while (reader.Read())
        {
            nummers.Add(new Nummer((int)reader["Id"], reader["Naam"].ToString(), (int)reader["Lengte"], reader["Artiest"].ToString()));
        }
        _connection.Close();
        return nummers;
    }

    public List<Nummer> GetNummerPage(int pageNum, int pageSize)
    {
        int offset = pageSize * pageNum;
        _connection.Open();
        string query = "SELECT * FROM Nummer N LIMIT @pageSize OFFSET @offset";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@pageSize", pageSize);
        command.Parameters.AddWithValue("@offset", offset);
        using MySqlDataReader reader = command.ExecuteReader();
        List<Nummer> nummers = new List<Nummer>();
        while (reader.Read())
        {
            nummers.Add(new Nummer((int)reader["Id"], reader["Naam"].ToString(), (int)reader["Lengte"], reader["Artiest"].ToString()));
        }
        _connection.Close();
        return nummers;
    }

    public Nummer GetNummer(int id)
    {
        _connection.Open();
        string query = "SELECT * FROM Nummer N WHERE N.Id = @id";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", id);
        using MySqlDataReader reader = command.ExecuteReader();
        Nummer nummer = null;
        while (reader.Read())
        {
            nummer = new Nummer((int)reader["Id"], reader["Naam"].ToString(), (int)reader["Lengte"], reader["Artiest"].ToString());
        }
        _connection.Close();
        if(nummer != null)
            return nummer;
        throw new Exception("Failed to retrieve nummer");
    }

    public List<Nummer> GetNummersByMuzikantId(int muzikantId)
    {
        _connection.Open();
        string query = "SELECT * FROM Nummer N CROSS JOIN MuzikantNummer MN ON MN.Nummer_Id = M.Id WHERE MN.Muzikant_Id = @muzikantId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@muzikantId", muzikantId);
        using MySqlDataReader reader = command.ExecuteReader();
        List<Nummer> nummers = new List<Nummer>();
        while (reader.Read())
        {
            nummers.Add(new Nummer((int)reader["Id"], reader["Naam"].ToString(), (int)reader["Lengte"], reader["Artiest"].ToString()));
        }
        _connection.Close();
        return nummers;
    }

    public List<Nummer> GetNummersBySetlistId(int setlistId)
    {
        _connection.Open();
        string query = "SELECT * FROM Nummer N CROSS JOIN NummerSetlist NS ON NS.Nummer_Id = M.Id WHERE NS.Setlist_Id = @setlistId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@setlistId", setlistId);
        using MySqlDataReader reader = command.ExecuteReader();
        List<Nummer> nummers = new List<Nummer>();
        while (reader.Read())
        {
            nummers.Add(new Nummer((int)reader["Id"], reader["Naam"].ToString(), (int)reader["Lengte"], reader["Artiest"].ToString()));
        }
        _connection.Close();
        return nummers;
    }

    public void UpdateNummer(Nummer newNummer, int nummerId)
    {
        _connection.Open();
        string query = "UPDATE Nummer SET Naam = @name, Lengte = @length, Artiest = @artist WHERE Id = @id";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", newNummer.GiveId());
        command.Parameters.AddWithValue("@name", newNummer.GiveName());
        command.Parameters.AddWithValue("@length", newNummer.GiveLength());
        command.Parameters.AddWithValue("@artist", newNummer.GiveArtiest());
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void DeleteNummer(int id)
    {
        _connection.Open();
        string query = "DELETE FROM Nummer WHERE Id = @id";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void AddNummer(Nummer newNummer)
    {
        _connection.Open();
        string query = "INSERT INTO Nummer (Id, Naam, Lengte, Artiest) VALUES (@id, @name, @length, @artist)";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", newNummer.GiveId());
        command.Parameters.AddWithValue("@name", newNummer.GiveName());
        command.Parameters.AddWithValue("@length", newNummer.GiveLength());
        command.Parameters.AddWithValue("@artist", newNummer.GiveArtiest());
        command.ExecuteNonQuery();
        _connection.Close();
    }
}