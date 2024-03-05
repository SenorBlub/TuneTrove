using MySqlConnector;
using TuneTrove_Logic.DAL_Interfaces;
using TuneTrove_Logic.DTO;

namespace TuneTrove_DAL;

public class NummerRepository : INummerRepository
{
    private string _connectionString;
    private readonly MySqlConnection _connection;
    public NummerRepository(string connectionString)
    {
        _connectionString = connectionString;
        _connection = new MySqlConnection(_connectionString);
    }

    public List<NummerDTO> GetAllNummers()
    {
        _connection.Open();
        string query = "SELECT * FROM Nummer";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        using MySqlDataReader reader = command.ExecuteReader();
        List<NummerDTO> nummers = new List<NummerDTO>();
        while (reader.Read())
        {
            nummers.Add(new NummerDTO((int)reader["Id"], reader["Naam"].ToString(), (int)reader["Lengte"], reader["Artiest"].ToString()));
        }
        return nummers;
    }

    public NummerDTO GetNummerById(int id)
    {
        _connection.Open();
        string query = "SELECT * FROM Nummer WHERE Id = @id";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", id);
        using MySqlDataReader reader = command.ExecuteReader();
        NummerDTO nummer = null;
        while (reader.Read())
        {
            nummer = new NummerDTO((int)reader["Id"], reader["Naam"].ToString(), (int)reader["Lengte"], reader["Artiest"].ToString());
        }
        _connection.Close();
        return nummer;
    }

    public void PostNummer(NummerDTO nummer)
    {
        _connection.Open();
        string query = "INSERT INTO Nummer (Id, Naam, Lengte, Artiest) VALUES (@id, @name, @length, @artist)";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", nummer.Id);
        command.Parameters.AddWithValue("@name", nummer.Name);
        command.Parameters.AddWithValue("@length", nummer.Length);
        command.Parameters.AddWithValue("@artist", nummer.Artiest);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void RemoveNummer(int id)
    {
        _connection.Open();
        string query = "DELETE * FROM Nummer WHERE Id = @id";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void EditNummer(NummerDTO nummer)
    {
        _connection.Open();
        string query = "UPDATE Nummer SET Naam = @name, Lengte = @length, Artiest = @artist WHERE Id = @id";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@id", nummer.Id);
        command.Parameters.AddWithValue("@name", nummer.Name);
        command.Parameters.AddWithValue("@length", nummer.Length);
        command.Parameters.AddWithValue("@artist", nummer.Artiest);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public List<NummerDTO> SearchNummer(string searchQuery)
    {
        _connection.Open();
        string query = "SELECT * FROM Nummer WHERE Naam LIKE @searchQuery";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@searchQuery", $"%{searchQuery}%");
        using MySqlDataReader reader = command.ExecuteReader();
        List<NummerDTO> nummers = new List<NummerDTO>();
        while (reader.Read())
        {
            nummers.Add(new NummerDTO((int)reader["Id"], reader["Naam"].ToString(), (int)reader["Lengte"], reader["Artiest"].ToString()));
        }
        return nummers;
    }
}