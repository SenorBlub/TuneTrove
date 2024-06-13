using TuneTrove_Logic.Models;

namespace TuneTrove_Logic.Presentation_Interfaces;

public interface ISetlistService
{
    List<Setlist> GetAllSetlists();
    Setlist GetSetlistById(int id);
    void PostSetlist (Setlist setlist);
    void RemoveSetlist(int id);
    void EditSetlist(Setlist setlist);
}