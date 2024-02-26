using TuneTrove_Logic.DAL_Interfaces;
using TuneTrove_Logic.Models;
using TuneTrove_Logic.Presentation_Interfaces;

namespace TuneTrove_Logic.Services;
// !TODO no HTTP verbs
public class SetlistService : ISetlistService
{
    private ISetlistRepository _setlistRepository;
    private INummerSetlistRepository _nummerSetlistRepository;
    private IMuzikantSetlistRepository _muzikantSetlistRepository;
    public List<Setlist> GetAllSetlists()
    {
        List<Setlist> setlistList = new List<Setlist>();
        foreach (SetlistDTO setlistDto in _setlistRepository.GetAllSetlists())
        {
            setlistList.Add(new Setlist(setlistDto));
        }
        return setlistList;
    }

    public Setlist GetSetlistById(int id)
    {
        return new Setlist(_setlistRepository.GetSetlistById(id));
    }

    public void PostSetlist(Setlist setlist)
    {
        _setlistRepository.PostSetlist(new SetlistDTO(setlist));
    }

    public void RemoveSetlist(int id)
    {
        _setlistRepository.RemoveSetlist(id);
    }

    public void EditSetlist(Setlist setlist)
    {
        _setlistRepository.EditSetlist(new SetlistDTO(setlist));
    }
}