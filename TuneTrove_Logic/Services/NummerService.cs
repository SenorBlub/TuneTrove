using TuneTrove_Logic.DAL_Interfaces;
using TuneTrove_Logic.DTO;
using TuneTrove_Logic.Models;
using TuneTrove_Logic.Presentation_Interfaces;

namespace TuneTrove_Logic.Services;
// !TODO no HTTP verbs
public class NummerService : INummerService
{
    private INummerRepository _nummerRepository;
    private INummerSetlistRepository _nummerSetlistRepository;
    private IMuzikantNummerRepository _muzikantNummerRepository;
    public List<Nummer> GetAllNummers()
    {
        List<Nummer> NummerList = new List<Nummer>();
        foreach (NummerDTO nummerDto in _nummerRepository.GetAllNummers())
        {
            List<int> setlistIds = new List<int>();
            foreach (int setlistId in _nummerSetlistRepository.GetSetlists(nummerDto.Id))
            {
                setlistIds.Add(setlistId);
            }
            NummerList.Add(new Nummer(nummerDto, setlistIds));
        }
        return NummerList;
    }

    public Nummer GetNummerById(int id)
    {
        List<int> setlistIds = new List<int>();
        foreach (int setlistId in _nummerSetlistRepository.GetSetlists(id))
        {
            setlistIds.Add(setlistId);
        }
        return new Nummer(_nummerRepository.GetNummerById(id), setlistIds);
    }

    public void PostNummer(Nummer nummer)
    {
        _nummerRepository.PostNummer(new NummerDTO(nummer));
        foreach (int setlistId in nummer.SetlistIds)
        {
            _nummerSetlistRepository.PostConnection(nummer.Id, setlistId);
        }
    }

    public void RemoveNummer(int id)
    {
        foreach (int setlistId in _nummerSetlistRepository.GetSetlists(id))
        {
            _nummerSetlistRepository.RemoveConnection(id, setlistId);
        }

/*        foreach (int muzikantId in _muzikantNummerRepository.GetMuzikanten(id))
        {
           _muzikantNummerRepository.RemoveConnection(muzikantId, id); 
        }*/ //!TODO could do could not do doesnt matter for functonality just means ill get orphaned connections that will show not founds
        _nummerRepository.RemoveNummer(id);
    }

    public void EditNummer(Nummer nummer)
    {
        _nummerRepository.EditNummer(new NummerDTO(nummer));
        foreach (int setlistId in _nummerSetlistRepository.GetSetlists(nummer.Id))
        {
            _nummerSetlistRepository.RemoveConnection(nummer.Id, setlistId);
        }

        foreach (int setlistId in nummer.SetlistIds)
        {
            _nummerSetlistRepository.PostConnection(nummer.Id, setlistId);
        }
    }

    public List<Nummer> SearchNummer(string query)
    {
        List<Nummer> NummerList = new List<Nummer>();
        foreach (NummerDTO nummerDto in _nummerRepository.SearchNummer(query))
        {
            List<int> setlistIds = new List<int>();
            foreach (int setlistId in _nummerSetlistRepository.GetSetlists(nummerDto.Id))
            {
                setlistIds.Add(setlistId);
            }
            NummerList.Add(new Nummer(nummerDto, setlistIds));
        }
        return NummerList;
    }
}