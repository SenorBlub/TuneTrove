using MySqlConnector;
using TuneTrove_Logic.DAL_Interfaces;

namespace TuneTrove_DAL;

public class MuzikantNummerRepository : IMuzikantNummerRepository
{
    private string _connectionString;
    private readonly MySqlConnection _connection;
    public MuzikantBandRepository(string connectionString)
    {
        _connectionString = connectionString;
        _connection = new MySqlConnection(_connectionString);
    }

    public List<int> GetNummers(int muzikantId)
    {
        throw new NotImplementedException();
    }

    public List<int> GetMuzikanten(int nummerId)
    {
        throw new NotImplementedException();
    }

    public void PostConnection(int muzikantId, int nummerId)
    {
        throw new NotImplementedException();
    }

    public void RemoveConnection(int muzikantId, int nummerId)
    {
        throw new NotImplementedException();
    }
}