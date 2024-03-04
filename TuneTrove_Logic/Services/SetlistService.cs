using System.Runtime.CompilerServices;
using TuneTrove_Logic.DAL_Interfaces;
using TuneTrove_Logic.DTO;
using TuneTrove_Logic.Models;
using TuneTrove_Logic.Presentation_Interfaces;

namespace TuneTrove_Logic.Services;
// !TODO no HTTP verbs
public class SetlistService : ISetlistService
{
    private ISetlistRepository _setlistRepository;
    private INummerSetlistRepository _nummerSetlistRepository;
    private IMuzikantSetlistRepository _muzikantSetlistRepository;
    private IBandRepository _bandRepository;
    private IBandSetlistRepository _bandSetlistRepository;
    public List<Setlist> GetAllSetlists()
    {
        List<Setlist> setlistList = new List<Setlist>();
        foreach (SetlistDTO setlistDto in _setlistRepository.GetAllSetlists())
        {
            List<int> nummerIds = new List<int>();
            foreach (int nummerId in _nummerSetlistRepository.GetNummers(setlistDto.Id))
            {
                nummerIds.Add(nummerId);
            }

            List<int> muzikantIds = new List<int>();
            foreach (int muzikantId in _muzikantSetlistRepository.GetMuzikanten(setlistDto.Id))
            {
                muzikantIds.Add(muzikantId);
            }

            List<int> bandIds = new List<int>();
            foreach (int bandId in _bandSetlistRepository.GetBands(setlistDto.Id))
            {
                bandIds.Add(bandId);
            }
            setlistList.Add(new Setlist(setlistDto, muzikantIds, nummerIds, bandIds));
        }
        return setlistList;
    }

    public Setlist GetSetlistById(int id)
    {
        List<int> nummerIds = new List<int>();
        foreach (int nummerId in _nummerSetlistRepository.GetNummers(id))
        {
            nummerIds.Add(nummerId);
        }

        List<int> muzikantIds = new List<int>();
        foreach (int muzikantId in _muzikantSetlistRepository.GetMuzikanten(id))
        {
            muzikantIds.Add(muzikantId);
        }

        List<int> bandIds = new List<int>();
        foreach (int bandId in _bandSetlistRepository.GetBands(id))
        {
            bandIds.Add(bandId);
        }
        return new Setlist(_setlistRepository.GetSetlistById(id), muzikantIds, nummerIds, bandIds);
    }

    public void PostSetlist(Setlist setlist)
    {
        foreach(int bandId in setlist.BandIds)
            _setlistRepository.PostSetlist(new SetlistDTO(setlist), bandId);
        foreach (int muzikantId in setlist.MuzikantIds)
        {
            _muzikantSetlistRepository.PostConnection(muzikantId, setlist.Id);
        }

        foreach (int nummerId in setlist.NummerIds)
        {
            _nummerSetlistRepository.PostConnection(nummerId, setlist.Id);
        }

        foreach (int bandId in setlist.BandIds)
        {
            _bandSetlistRepository.PostConnection(setlist.Id, bandId);
        }
    }

    public void RemoveSetlist(int id)
    {
        foreach (int muzikantId in _muzikantSetlistRepository.GetMuzikanten(id))
        {
            _muzikantSetlistRepository.RemoveConnection(muzikantId, id);
        }

        foreach (int nummerId in _nummerSetlistRepository.GetNummers(id))
        {
            _nummerSetlistRepository.RemoveConnection(nummerId, id);
        }

        foreach (int bandId in _bandSetlistRepository.GetBands(id))
        {
            _bandSetlistRepository.RemoveConnection(id, bandId);
        }
        _setlistRepository.RemoveSetlist(id);
    }

    public void EditSetlist(Setlist setlist)
    {
        foreach (int muzikantId in _muzikantSetlistRepository.GetMuzikanten(setlist.Id))
        {
            _muzikantSetlistRepository.RemoveConnection(muzikantId, setlist.Id);
        }

        foreach (int nummerId in _nummerSetlistRepository.GetNummers(setlist.Id))
        {
            _nummerSetlistRepository.RemoveConnection(nummerId, setlist.Id);
        }

        foreach (int bandId in _bandSetlistRepository.GetBands(setlist.Id))
        {
            _bandSetlistRepository.RemoveConnection(setlist.Id, bandId);
        }

        foreach (int muzikantId in setlist.MuzikantIds)
        {
            _muzikantSetlistRepository.PostConnection(muzikantId, setlist.Id);
        }

        foreach (int nummerId in setlist.NummerIds)
        {
            _nummerSetlistRepository.PostConnection(nummerId, setlist.Id);
        }

        foreach (int bandId in setlist.BandIds)
        {
            _bandSetlistRepository.PostConnection(setlist.Id, bandId);
        }
        foreach (int bandId in setlist.BandIds)
            _setlistRepository.EditSetlist(new SetlistDTO(setlist), bandId);
    }
}