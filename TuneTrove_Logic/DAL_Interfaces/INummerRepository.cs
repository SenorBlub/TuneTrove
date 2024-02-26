using TuneTrove_Logic.Models;

namespace TuneTrove_Logic.DAL_Interfaces;

public interface INummerRepository
{
    List<NummerDTO> GetAllNummers();
    NummerDTO GetNummerById(int id);
    void PostNummer(NummerDTO nummer);
    void RemoveNummer(int id);
    void EditNummer(NummerDTO nummer);
    List<NummerDTO> SearchNummer(string query);
}