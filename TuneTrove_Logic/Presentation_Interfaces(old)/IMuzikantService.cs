using TuneTrove_Logic.Models;

namespace TuneTrove_Logic.Presentation_Interfaces;

public interface IMuzikantService
{
    List<Muzikant> GetAllMuzikanten();
    Muzikant GetMuzikantById(int id);
    void PostMuzikant(Muzikant muzikant);
    void RemoveMuzikant(int id);
    void EditMuzikant(Muzikant muzikant);
    List<Muzikant> SearchMuzikant(string query);
}