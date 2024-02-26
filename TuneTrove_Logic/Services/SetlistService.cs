using TuneTrove_Logic.DAL_Interfaces;
using TuneTrove_Logic.Models;
using TuneTrove_Logic.Presentation_Interfaces;

namespace TuneTrove_Logic.Services;

public class SetlistService : ISetlistService
{
    private ISetlistRepository _repository;
    public List<Setlist> GetAllSetlists()
    {
        List<Setlist> setlistList = new List<Setlist>();
        foreach (SetlistDTO setlistDto in _repository.GetAllSetlists())
        {
            setlistList.Add(new Setlist(setlistDto));
        }
        return setlistList;
    }

    public Setlist GetSetlistById(int id)
    {
        return new Setlist(_repository.GetSetlistById(id));
    }

    public void PostSetlist(Setlist setlist)
    {
        _repository.PostSetlist(new SetlistDTO(setlist));
    }

    public void RemoveSetlist(int id)
    {
        _repository.RemoveSetlist(id);
    }

    public void EditSetlist(Setlist setlist)
    {
        _repository.EditSetlist(new SetlistDTO(setlist));
    }
}