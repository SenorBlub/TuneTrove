using Microsoft.Extensions.Configuration;
using MySqlConnector;
using TuneTrove_Logic.IRepositories;
using System.Collections.Generic;

namespace TuneTrove_DAL.Repositories;

public class MuzikantBandRepository : IMuzikantBandRepository
{
    private string _connectionString;
    private readonly MySqlConnection _connection;

    public MuzikantBandRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("connectionString");
        _connection = new MySqlConnection(_connectionString);
    }

    public void ConnectMuzikantToBand(int muzikantId, int bandId)
    {
        _connection.Open();
        string query = "INSERT INTO MuzikantBand (Band_Id, Muzikant_Id) VALUES (@bandId, @muzikantId)";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@bandId", bandId);
        command.Parameters.AddWithValue("@muzikantId", muzikantId);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void ConnectMuzikantenToBand(List<int> muzikantIds, int bandId)
    {
        _connection.Open();
        using var transaction = _connection.BeginTransaction();
        string query = "INSERT INTO MuzikantBand (Band_Id, Muzikant_Id) VALUES (@bandId, @muzikantId)";
        using MySqlCommand command = new MySqlCommand(query, _connection, transaction);
        foreach (var muzikantId in muzikantIds)
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@bandId", bandId);
            command.Parameters.AddWithValue("@muzikantId", muzikantId);
            command.ExecuteNonQuery();
        }
        transaction.Commit();
        _connection.Close();
    }

    public void ConnectMuzikantToBands(int muzikantId, List<int> bandIds)
    {
        _connection.Open();
        using var transaction = _connection.BeginTransaction();
        string query = "INSERT INTO MuzikantBand (Band_Id, Muzikant_Id) VALUES (@bandId, @muzikantId)";
        using MySqlCommand command = new MySqlCommand(query, _connection, transaction);
        foreach (var bandId in bandIds)
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@bandId", bandId);
            command.Parameters.AddWithValue("@muzikantId", muzikantId);
            command.ExecuteNonQuery();
        }
        transaction.Commit();
        _connection.Close();
    }

    public void DisconnectMuzikantFromBand(int muzikantId, int bandId)
    {
        _connection.Open();
        string query = "DELETE FROM MuzikantBand WHERE Band_Id = @bandId AND Muzikant_Id = @muzikantId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@bandId", bandId);
        command.Parameters.AddWithValue("@muzikantId", muzikantId);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void DisconnectMuzikantenFromBand(List<int> muzikantIds, int bandId)
    {
        _connection.Open();
        using var transaction = _connection.BeginTransaction();
        string query = "DELETE FROM MuzikantBand WHERE Band_Id = @bandId AND Muzikant_Id = @muzikantId";
        using MySqlCommand command = new MySqlCommand(query, _connection, transaction);
        foreach (var muzikantId in muzikantIds)
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@bandId", bandId);
            command.Parameters.AddWithValue("@muzikantId", muzikantId);
            command.ExecuteNonQuery();
        }
        transaction.Commit();
        _connection.Close();
    }

    public void DisconnectMuzikantFromBands(int muzikantId, List<int> bandIds)
    {
        _connection.Open();
        using var transaction = _connection.BeginTransaction();
        string query = "DELETE FROM MuzikantBand WHERE Band_Id = @bandId AND Muzikant_Id = @muzikantId";
        using MySqlCommand command = new MySqlCommand(query, _connection, transaction);
        foreach (var bandId in bandIds)
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@bandId", bandId);
            command.Parameters.AddWithValue("@muzikantId", muzikantId);
            command.ExecuteNonQuery();
        }
        transaction.Commit();
        _connection.Close();
    }

    public void DisconnectAllFromMuzikant(int muzikantId)
    {
        _connection.Open();
        string query = "DELETE FROM MuzikantBand WHERE Muzikant_Id = @muzikantId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@muzikantId", muzikantId);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void DisconnectFromAllMuzikanten(int bandId)
    {
        _connection.Open();
        string query = "DELETE FROM MuzikantBand WHERE Band_Id = @bandId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@bandId", bandId);
        command.ExecuteNonQuery();
        _connection.Close();
    }
}
