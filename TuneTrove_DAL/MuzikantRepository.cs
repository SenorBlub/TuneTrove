using MySqlConnector;
using TuneTrove_Logic.DAL_Interfaces;
using TuneTrove_Logic.Models;

namespace TuneTrove_DAL;

public class MuzikantRepository : IMuzikantRepository
{
    private string _connectionString;
    private readonly MySqlConnection _connection;
    public MuzikantRepository(string connectionString)
    {
        _connectionString = connectionString;
        _connection = new MySqlConnection(_connectionString);
    }
    public List<MuzikantDTO> GetAllMuzikanten()
    {
        throw new NotImplementedException();
    }

    public MuzikantDTO GetMuzikantById(int id)
    {
        throw new NotImplementedException();
    }

    public void PostMuzikant(MuzikantDTO muzikant)
    {
        throw new NotImplementedException();
    }

    public void RemoveMuzikant(int id)
    {
        throw new NotImplementedException();
    }

    public void EditMuzikant(MuzikantDTO muzikant)
    {
        throw new NotImplementedException();
    }

    public List<MuzikantDTO> SearchMuzikant(string query)
    {
        throw new NotImplementedException();
    }
}