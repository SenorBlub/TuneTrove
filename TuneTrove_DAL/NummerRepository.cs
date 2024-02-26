using MySqlConnector;
using TuneTrove_Logic.DAL_Interfaces;
using TuneTrove_Logic.Models;

namespace TuneTrove_DAL;

public class NummerRepository : INummerRepository
{
    private string _connectionString;
    private readonly MySqlConnection _connection;
    public NummerRepository(string connectionString)
    {
        _connectionString = connectionString;
        _connection = new MySqlConnection(_connectionString);
    }

    public List<NummerDTO> GetAllNummers()
    {
        throw new NotImplementedException();
    }

    public NummerDTO GetNummerById(int id)
    {
        throw new NotImplementedException();
    }

    public void PostNummer(NummerDTO nummer)
    {
        throw new NotImplementedException();
    }

    public void RemoveNummer(int id)
    {
        throw new NotImplementedException();
    }

    public void EditNummer(NummerDTO nummer)
    {
        throw new NotImplementedException();
    }

    public List<NummerDTO> SearchNummer(string query)
    {
        throw new NotImplementedException();
    }
}