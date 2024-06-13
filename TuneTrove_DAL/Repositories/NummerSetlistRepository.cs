using Microsoft.Extensions.Configuration;
using MySqlConnector;
using TuneTrove_Logic.IRepositories;
using System.Collections.Generic;

namespace TuneTrove_DAL.Repositories;

public class NummerSetlistRepository : INummerSetlistRepository
{
    private string _connectionString;
    private readonly MySqlConnection _connection;

    public NummerSetlistRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("connectionString");
        _connection = new MySqlConnection(_connectionString);
    }

    public void ConnectNummerToSetlist(int nummerId, int setlistId)
    {
        _connection.Open();
        string query = "INSERT INTO NummerSetlist (Setlist_Id, Nummer_Id) VALUES (@setlistId, @nummerId)";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@setlistId", setlistId);
        command.Parameters.AddWithValue("@nummerId", nummerId);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void ConnectNummersToSetlist(List<int> nummerIds, int setlistId)
    {
        _connection.Open();
        using var transaction = _connection.BeginTransaction();
        string query = "INSERT INTO NummerSetlist (Setlist_Id, Nummer_Id) VALUES (@setlistId, @nummerId)";
        using MySqlCommand command = new MySqlCommand(query, _connection, transaction);
        foreach (var nummerId in nummerIds)
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@setlistId", setlistId);
            command.Parameters.AddWithValue("@nummerId", nummerId);
            command.ExecuteNonQuery();
        }
        transaction.Commit();
        _connection.Close();
    }

    public void ConnectNummerToSetlists(int nummerId, List<int> setlistIds)
    {
        _connection.Open();
        using var transaction = _connection.BeginTransaction();
        string query = "INSERT INTO NummerSetlist (Setlist_Id, Nummer_Id) VALUES (@setlistId, @nummerId)";
        using MySqlCommand command = new MySqlCommand(query, _connection, transaction);
        foreach (var setlistId in setlistIds)
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@setlistId", setlistId);
            command.Parameters.AddWithValue("@nummerId", nummerId);
            command.ExecuteNonQuery();
        }
        transaction.Commit();
        _connection.Close();
    }

    public void DisconnectNummerFromSetlist(int nummerId, int setlistId)
    {
        _connection.Open();
        string query = "DELETE FROM NummerSetlist WHERE Setlist_Id = @setlistId AND Nummer_Id = @nummerId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@setlistId", setlistId);
        command.Parameters.AddWithValue("@nummerId", nummerId);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void DisconnectNummersFromSetlist(List<int> nummerIds, int setlistId)
    {
        _connection.Open();
        using var transaction = _connection.BeginTransaction();
        string query = "DELETE FROM NummerSetlist WHERE Setlist_Id = @setlistId AND Nummer_Id = @nummerId";
        using MySqlCommand command = new MySqlCommand(query, _connection, transaction);
        foreach (var nummerId in nummerIds)
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@setlistId", setlistId);
            command.Parameters.AddWithValue("@nummerId", nummerId);
            command.ExecuteNonQuery();
        }
        transaction.Commit();
        _connection.Close();
    }

    public void DisconnectNummerFromSetlists(int nummerId, List<int> setlistIds)
    {
        _connection.Open();
        using var transaction = _connection.BeginTransaction();
        string query = "DELETE FROM NummerSetlist WHERE Setlist_Id = @setlistId AND Nummer_Id = @nummerId";
        using MySqlCommand command = new MySqlCommand(query, _connection, transaction);
        foreach (var setlistId in setlistIds)
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@setlistId", setlistId);
            command.Parameters.AddWithValue("@nummerId", nummerId);
            command.ExecuteNonQuery();
        }
        transaction.Commit();
        _connection.Close();
    }

    public void DisconnectAllFromNummer(int nummerId)
    {
        _connection.Open();
        string query = "DELETE FROM NummerSetlist WHERE Nummer_Id = @nummerId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@nummerId", nummerId);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void DisconnectFromAllNummers(int setlistId)
    {
        _connection.Open();
        string query = "DELETE FROM NummerSetlist WHERE Setlist_Id = @setlistId";
        using MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@setlistId", setlistId);
        command.ExecuteNonQuery();
        _connection.Close();
    }
}
