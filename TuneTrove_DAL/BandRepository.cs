using MySqlConnector;
using TuneTrove_Logic.DAL_Interfaces;
using TuneTrove_Logic.Models;

namespace TuneTrove_DAL;

public class BandRepository : IBandRepository
{
    private string _connectionString;
    private readonly MySqlConnection _connection;
    public BandRepository(string connectionString)
    {
        _connectionString = connectionString;
        _connection = new MySqlConnection(_connectionString);
    }

    public List<BandDTO> GetAllBands()
    {
        List<BandDTO> bandDTOs = new List<BandDTO>();
        _connection.Open();
        string query = "Select * FROM Band";
        using MySqlCommand command = new MySqlCommand(query, _connection);

        using MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            bandDTOs.Add(new BandDTO
            {
                BandLeden = //<< problem because code isnt structered correctly currently
            });
        }

    }

    public BandDTO GetBandById(int id)
    {
        throw new NotImplementedException();
    }

    public void PostBand(BandDTO band)
    {
        throw new NotImplementedException();
    }

    public void RemoveBand(int id)
    {
        throw new NotImplementedException();
    }

    public void EditBand(BandDTO band)
    {
        throw new NotImplementedException();
    }
}