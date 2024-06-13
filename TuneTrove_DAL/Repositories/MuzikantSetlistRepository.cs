using Microsoft.Extensions.Configuration;
using MySqlConnector;
using TuneTrove_Logic.IRepositories;
using System.Collections.Generic;

namespace TuneTrove_DAL.Repositories;

public class MuzikantSetlistRepository : IMuzikantSetlistRepository
{
    private string _connectionString;
    private readonly MySqlConnection _connection;

    public MuzikantSetlistRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("connectionString");
        _connection = new MySqlConnection(_connectionString);
    }

    public void ConnectMuzikantToSetlist(int muzikantId, int setlistId)
    {
        _connection.Open();
        string query = "INSERT INTO MuzikantSetlist (Setlist_Id, Muzikant_Id) VALUES (@setlistId, @muzikantId)";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@setlistId", setlistId);
        command.Parameters.AddWithValue("@muzikantId", muzikantId);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void ConnectMuzikantenToSetlist(List<int> muzikantIds, int setlistId)
    {
        _connection.Open();
        using var transaction = _connection.BeginTransaction();
        string query = "INSERT INTO MuzikantSetlist (Setlist_Id, Muzikant_Id) VALUES (@setlistId, @muzikantId)";
        using MySqlCommand command = new MySqlCommand(query, _connection, transaction);
        foreach (var muzikantId in muzikantIds)
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@setlistId", setlistId);
            command.Parameters.AddWithValue("@muzikantId", muzikantId);
            command.ExecuteNonQuery();
        }
        transaction.Commit();
        _connection.Close();
    }

    public void ConnectMuzikantToSetlists(int muzikantId, List<int> setlistIds)
    {
        _connection.Open();
        using var transaction = _connection.BeginTransaction();
        string query = "INSERT INTO MuzikantSetlist (Setlist_Id, Muzikant_Id) VALUES (@setlistId, @muzikantId)";
        using MySqlCommand command = new MySqlCommand(query, _connection, transaction);
        foreach (var setlistId in setlistIds)
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@setlistId", setlistId);
            command.Parameters.AddWithValue("@muzikantId", muzikantId);
            command.ExecuteNonQuery();
        }
        transaction.Commit();
        _connection.Close();
    }

    public void DisconnectMuzikantFromSetlist(int muzikantId, int setlistId)
    {
        _connection.Open();
        string query = "DELETE FROM MuzikantSetlist WHERE Setlist_Id = @setlistId AND Muzikant_Id = @muzikantId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@setlistId", setlistId);
        command.Parameters.AddWithValue("@muzikantId", muzikantId);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void DisconnectMuzikantenFromSetlist(List<int> muzikantIds, int setlistId)
    {
        _connection.Open();
        using var transaction = _connection.BeginTransaction();
        string query = "DELETE FROM MuzikantSetlist WHERE Setlist_Id = @setlistId AND Muzikant_Id = @muzikantId";
        using MySqlCommand command = new MySqlCommand(query, _connection, transaction);
        foreach (var muzikantId in muzikantIds)
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@setlistId", setlistId);
            command.Parameters.AddWithValue("@muzikantId", muzikantId);
            command.ExecuteNonQuery();
        }
        transaction.Commit();
        _connection.Close();
    }

    public void DisconnectMuzikantFromSetlists(int muzikantId, List<int> setlistIds)
    {
        _connection.Open();
        using var transaction = _connection.BeginTransaction();
        string query = "DELETE FROM MuzikantSetlist WHERE Setlist_Id = @setlistId AND Muzikant_Id = @muzikantId";
        using MySqlCommand command = new MySqlCommand(query, _connection, transaction);
        foreach (var setlistId in setlistIds)
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@setlistId", setlistId);
            command.Parameters.AddWithValue("@muzikantId", muzikantId);
            command.ExecuteNonQuery();
        }
        transaction.Commit();
        _connection.Close();
    }

    public void DisconnectAllFromMuzikant(int muzikantId)
    {
        _connection.Open();
        string query = "DELETE FROM MuzikantSetlist WHERE Muzikant_Id = @muzikantId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@muzikantId", muzikantId);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void DisconnectFromAllMuzikanten(int setlistId)
    {
        _connection.Open();
        string query = "DELETE FROM MuzikantSetlist WHERE Setlist_Id = @setlistId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@setlistId", setlistId);
        command.ExecuteNonQuery();
        _connection.Close();
    }
}
