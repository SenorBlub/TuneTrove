using Microsoft.Extensions.Configuration;
using MySqlConnector;
using TuneTrove_Logic.IRepositories;
using System.Collections.Generic;

namespace TuneTrove_DAL.Repositories;

public class BandSetlistRepository : IBandSetlistRepository
{
    private string _connectionString;
    private readonly MySqlConnection _connection;

    public BandSetlistRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("connectionString");
        _connection = new MySqlConnection(_connectionString);
    }

    public void ConnectBandToSetlist(int bandId, int setlistId)
    {
        _connection.Open();
        string query = "INSERT INTO BandSetlist (Band_Id, Setlist_Id) VALUES (@bandId, @setlistId)";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@bandId", bandId);
        command.Parameters.AddWithValue("@setlistId", setlistId);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void ConnectBandsToSetlist(List<int> bandIds, int setlistId)
    {
        _connection.Open();
        using var transaction = _connection.BeginTransaction();
        string query = "INSERT INTO BandSetlist (Band_Id, Setlist_Id) VALUES (@bandId, @setlistId)";
        using MySqlCommand command = new MySqlCommand(query, _connection, transaction);
        foreach (var bandId in bandIds)
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@bandId", bandId);
            command.Parameters.AddWithValue("@setlistId", setlistId);
            command.ExecuteNonQuery();
        }
        transaction.Commit();
        _connection.Close();
    }

    public void ConnectBandToSetlists(int bandId, List<int> setlistIds)
    {
        _connection.Open();
        using var transaction = _connection.BeginTransaction();
        string query = "INSERT INTO BandSetlist (Band_Id, Setlist_Id) VALUES (@bandId, @setlistId)";
        using MySqlCommand command = new MySqlCommand(query, _connection, transaction);
        foreach (var setlistId in setlistIds)
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@bandId", bandId);
            command.Parameters.AddWithValue("@setlistId", setlistId);
            command.ExecuteNonQuery();
        }
        transaction.Commit();
        _connection.Close();
    }

    public void DisconnectBandFromSetlist(int bandId, int setlistId)
    {
        _connection.Open();
        string query = "DELETE FROM BandSetlist WHERE Band_Id = @bandId AND Setlist_Id = @setlistId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@bandId", bandId);
        command.Parameters.AddWithValue("@setlistId", setlistId);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void DisconnectBandsFromSetlist(List<int> bandIds, int setlistId)
    {
        _connection.Open();
        using var transaction = _connection.BeginTransaction();
        string query = "DELETE FROM BandSetlist WHERE Band_Id = @bandId AND Setlist_Id = @setlistId";
        using MySqlCommand command = new MySqlCommand(query, _connection, transaction);
        foreach (var bandId in bandIds)
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@bandId", bandId);
            command.Parameters.AddWithValue("@setlistId", setlistId);
            command.ExecuteNonQuery();
        }
        transaction.Commit();
        _connection.Close();
    }

    public void DisconnectBandFromSetlists(int bandId, List<int> setlistIds)
    {
        _connection.Open();
        using var transaction = _connection.BeginTransaction();
        string query = "DELETE FROM BandSetlist WHERE Band_Id = @bandId AND Setlist_Id = @setlistId";
        using MySqlCommand command = new MySqlCommand(query, _connection, transaction);
        foreach (var setlistId in setlistIds)
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@bandId", bandId);
            command.Parameters.AddWithValue("@setlistId", setlistId);
            command.ExecuteNonQuery();
        }
        transaction.Commit();
        _connection.Close();
    }

    public void DisconnectAllFromBand(int bandId)
    {
        _connection.Open();
        string query = "DELETE FROM BandSetlist WHERE Band_Id = @bandId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@bandId", bandId);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void DisconnectFromAllBands(int setlistId)
    {
        _connection.Open();
        string query = "DELETE FROM BandSetlist WHERE Setlist_Id = @setlistId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@setlistId", setlistId);
        command.ExecuteNonQuery();
        _connection.Close();
    }
}
