using TuneTrove_Logic.Models;

namespace TuneTrove_Logic.Presentation_Interfaces;

public interface INummerService
{
    List<Nummer> GetAllNummers();
    Nummer GetNummerById(int id);
    void PostNummer(Nummer nummer);
    void RemoveNummer(int id);
    void EditNummer(Nummer nummer);
    List<Nummer> SearchNummer(string query);
}