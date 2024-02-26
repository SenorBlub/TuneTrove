using MySqlConnector;
using TuneTrove_Logic.DAL_Interfaces;
using TuneTrove_Logic.Models;

namespace TuneTrove_DAL;

public class SetlistRepository : ISetlistRepository
{
    private string _connectionString;
    private readonly MySqlConnection _connection;
    public SetlistRepository(string connectionString)
    {
        _connectionString = connectionString;
        _connection = new MySqlConnection(_connectionString);
    }
    public List<SetlistDTO> GetAllSetlists()
    {
        throw new NotImplementedException();
    }

    public SetlistDTO GetSetlistById(int id)
    {
        throw new NotImplementedException();
    }

    public void PostSetlist(SetlistDTO setlist)
    {
        throw new NotImplementedException();
    }

    public void RemoveSetlist(int id)
    {
        throw new NotImplementedException();
    }

    public void EditSetlist(SetlistDTO setlist)
    {
        throw new NotImplementedException();
    }
}