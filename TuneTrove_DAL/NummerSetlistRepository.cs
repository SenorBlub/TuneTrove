using MySqlConnector;
using TuneTrove_Logic.DAL_Interfaces;

namespace TuneTrove_DAL;

public class NummerSetlistRepository : INummerSetlistRepository
{
    private string _connectionString;
    private readonly MySqlConnection _connection;
    public NummerSetlistRepository(string connectionString)
    {
        _connectionString = connectionString;
        _connection = new MySqlConnection(_connectionString);
    }

    public List<int> GetSetlists(int nummerId)
    {
        throw new NotImplementedException();
    }

    public List<int> GetNummers(int setlistId)
    {
        throw new NotImplementedException();
    }

    public void PostConnection(int nummerId, int setlistId)
    {
        throw new NotImplementedException();
    }

    public void RemoveConnection(int nummerId, int setlistId)
    {
        throw new NotImplementedException();
    }
}