using TuneTrove_Logic.Models;

namespace TuneTrove_Logic.DAL_Interfaces;

public interface ISetlistRepository
{
    List<SetlistDTO> GetAllSetlists();
    SetlistDTO GetSetlistById(int id);
    void PostSetlist(SetlistDTO setlist, int bandId);
    void RemoveSetlist(int id);
    void EditSetlist(SetlistDTO setlist, int bandId);
    List<int> getSetlistsByBand(int bandId);
}