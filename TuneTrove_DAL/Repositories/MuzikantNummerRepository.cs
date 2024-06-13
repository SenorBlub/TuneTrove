using Microsoft.Extensions.Configuration;
using MySqlConnector;
using TuneTrove_Logic.IRepositories;
using System.Collections.Generic;

namespace TuneTrove_DAL.Repositories;

public class MuzikantNummerRepository : IMuzikantNummerRepository
{
    private string _connectionString;
    private readonly MySqlConnection _connection;

    public MuzikantNummerRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("connectionString");
        _connection = new MySqlConnection(_connectionString);
    }

    public void ConnectMuzikantToNummer(int muzikantId, int nummerId)
    {
        _connection.Open();
        string query = "INSERT INTO MuzikantNummer (Nummer_Id, Muzikant_Id) VALUES (@nummerId, @muzikantId)";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@nummerId", nummerId);
        command.Parameters.AddWithValue("@muzikantId", muzikantId);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void ConnectMuzikantenToNummer(List<int> muzikantIds, int nummerId)
    {
        _connection.Open();
        using var transaction = _connection.BeginTransaction();
        string query = "INSERT INTO MuzikantNummer (Nummer_Id, Muzikant_Id) VALUES (@nummerId, @muzikantId)";
        using MySqlCommand command = new MySqlCommand(query, _connection, transaction);
        foreach (var muzikantId in muzikantIds)
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@nummerId", nummerId);
            command.Parameters.AddWithValue("@muzikantId", muzikantId);
            command.ExecuteNonQuery();
        }
        transaction.Commit();
        _connection.Close();
    }

    public void ConnectMuzikantToNummers(int muzikantId, List<int> nummerIds)
    {
        _connection.Open();
        using var transaction = _connection.BeginTransaction();
        string query = "INSERT INTO MuzikantNummer (Nummer_Id, Muzikant_Id) VALUES (@nummerId, @muzikantId)";
        using MySqlCommand command = new MySqlCommand(query, _connection, transaction);
        foreach (var nummerId in nummerIds)
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@nummerId", nummerId);
            command.Parameters.AddWithValue("@muzikantId", muzikantId);
            command.ExecuteNonQuery();
        }
        transaction.Commit();
        _connection.Close();
    }

    public void DisconnectMuzikantFromNummer(int muzikantId, int nummerId)
    {
        _connection.Open();
        string query = "DELETE FROM MuzikantNummer WHERE Nummer_Id = @nummerId AND Muzikant_Id = @muzikantId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@nummerId", nummerId);
        command.Parameters.AddWithValue("@muzikantId", muzikantId);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void DisconnectMuzikantenFromNummer(List<int> muzikantIds, int nummerId)
    {
        _connection.Open();
        using var transaction = _connection.BeginTransaction();
        string query = "DELETE FROM MuzikantNummer WHERE Nummer_Id = @nummerId AND Muzikant_Id = @muzikantId";
        using MySqlCommand command = new MySqlCommand(query, _connection, transaction);
        foreach (var muzikantId in muzikantIds)
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@nummerId", nummerId);
            command.Parameters.AddWithValue("@muzikantId", muzikantId);
            command.ExecuteNonQuery();
        }
        transaction.Commit();
        _connection.Close();
    }

    public void DisconnectMuzikantFromNummers(int muzikantId, List<int> nummerIds)
    {
        _connection.Open();
        using var transaction = _connection.BeginTransaction();
        string query = "DELETE FROM MuzikantNummer WHERE Nummer_Id = @nummerId AND Muzikant_Id = @muzikantId";
        using MySqlCommand command = new MySqlCommand(query, _connection, transaction);
        foreach (var nummerId in nummerIds)
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@nummerId", nummerId);
            command.Parameters.AddWithValue("@muzikantId", muzikantId);
            command.ExecuteNonQuery();
        }
        transaction.Commit();
        _connection.Close();
    }

    public void DisconnectAllFromMuzikant(int muzikantId)
    {
        _connection.Open();
        string query = "DELETE FROM MuzikantNummer WHERE Muzikant_Id = @muzikantId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@muzikantId", muzikantId);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void DisconnectFromAllMuzikanten(int nummerId)
    {
        _connection.Open();
        string query = "DELETE FROM MuzikantNummer WHERE Nummer_Id = @nummerId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@nummerId", nummerId);
        command.ExecuteNonQuery();
        _connection.Close();
    }
}
