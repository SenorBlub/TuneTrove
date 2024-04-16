using TuneTrove_Logic.DTO;

namespace TuneTrove_Logic.DAL_Interfaces;

public interface ISetlistRepository
{
    List<SetlistDTO> GetAllSetlists();
    SetlistDTO GetSetlistById(int id);
    void PostSetlist(SetlistDTO setlist);
    void RemoveSetlist(int id);
    void EditSetlist(SetlistDTO setlist);
}