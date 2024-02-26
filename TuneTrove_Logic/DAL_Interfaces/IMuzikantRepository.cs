using TuneTrove_Logic.Models;

namespace TuneTrove_Logic.DAL_Interfaces;

public interface IMuzikantRepository
{
    List<MuzikantDTO> GetAllMuzikanten();
    MuzikantDTO GetMuzikantById(int id);
    void PostMuzikant(MuzikantDTO muzikant);
    void RemoveMuzikant(int id);
    void EditMuzikant(MuzikantDTO muzikant);
    List<MuzikantDTO> SearchMuzikant(string query);
}