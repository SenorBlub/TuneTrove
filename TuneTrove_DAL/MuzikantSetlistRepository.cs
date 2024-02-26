using MySqlConnector;
using TuneTrove_Logic.DAL_Interfaces;

namespace TuneTrove_DAL;

public class MuzikantSetlistRepository : IMuzikantSetlistRepository
{
    private string _connectionString;
    private readonly MySqlConnection _connection;
    public MuzikantSetlistRepository(string connectionString)
    {
        _connectionString = connectionString;
        _connection = new MySqlConnection(_connectionString);
    }

    public List<int> GetSetlists(int muzikantId)
    {
        throw new NotImplementedException();
    }

    public List<int> GetMuzikanten(int setlistId)
    {
        throw new NotImplementedException();
    }

    public void PostConnection(int muzikantId, int setlistId)
    {
        throw new NotImplementedException();
    }

    public void RemoveConnection(int muzikantId, int setlistId)
    {
        throw new NotImplementedException();
    }
}