using TuneTrove_Logic.DAL_Interfaces;
using TuneTrove_Logic.Models;
using TuneTrove_Logic.Presentation_Interfaces;

namespace TuneTrove_Logic.Services;
// !TODO no HTTP verbs
public class MuzikantService : IMuzikantService
{
    private IMuzikantRepository _muzikantRepository;
    private IMuzikantBandRepository _muzikantBandRepository;
    private IMuzikantNummerRepository _muzikantNummerRepository;
    private IMuzikantSetlistRepository _muzikantSetlistRepository;
    public List<Muzikant> GetAllMuzikanten()
    {
        List<Muzikant> MuzikantList = new List<Muzikant>();
        foreach (MuzikantDTO muzikantDto in _muzikantRepository.GetAllMuzikanten())
        {
            List<int> bandIds = new List<int>();
            foreach (int bandId in _muzikantBandRepository.GetBands(muzikantDto.Id))
            {
                bandIds.Add(bandId);
            }

            List<int> nummerIds = new List<int>();
            foreach (int nummerId in _muzikantNummerRepository.GetNummers(muzikantDto.Id))
            {
                nummerIds.Add(nummerId);
            }

            List<int> setlistIds = new List<int>();
            foreach (int setlistId in _muzikantSetlistRepository.GetSetlists(muzikantDto.Id))
            {
                setlistIds.Add(setlistId);
            }

            MuzikantList.Add(new Muzikant(muzikantDto, bandIds, nummerIds, setlistIds));
        }
        return MuzikantList;
    }

    public Muzikant GetMuzikantById(int id)
    {
        List<int> bandIds = new List<int>();
        foreach (int bandId in _muzikantBandRepository.GetBands(id))
        {
            bandIds.Add(bandId);
        }

        List<int> nummerIds = new List<int>();
        foreach (int nummerId in _muzikantNummerRepository.GetNummers(id))
        {
            nummerIds.Add(nummerId);
        }

        List<int> setlistIds = new List<int>();
        foreach (int setlistId in _muzikantSetlistRepository.GetSetlists(id))
        {
            setlistIds.Add(setlistId);
        }

        return new Muzikant(_muzikantRepository.GetMuzikantById(id), bandIds, nummerIds, setlistIds);
    }

    public void PostMuzikant(Muzikant muzikant)
    {
        _muzikantRepository.PostMuzikant(new MuzikantDTO(muzikant));
        foreach (int nummerId in muzikant.NummerIds)
        {
            _muzikantNummerRepository.PostConnection(muzikant.Id, nummerId);
        }

        foreach (int setlistId in muzikant.SetlistIds)
        {
            _muzikantSetlistRepository.PostConnection(muzikant.Id, setlistId);
        }

        foreach (int bandId in muzikant.BandIds)
        {
            _muzikantBandRepository.PostConnection(muzikant.Id, bandId);
        }
    }

    public void RemoveMuzikant(int id)
    {
        foreach (int nummerId in _muzikantNummerRepository.GetNummers(id))
        {
            _muzikantNummerRepository.RemoveConnection(id, nummerId);
        }

        foreach (int setlistId in _muzikantSetlistRepository.GetSetlists(id))
        {
            _muzikantSetlistRepository.RemoveConnection(id, setlistId);
        }
        foreach (int bandId in _muzikantBandRepository.GetBands(id))
        {
            _muzikantBandRepository.RemoveConnection(id, bandId);
        }
        _muzikantRepository.RemoveMuzikant(id);
    }

    public void EditMuzikant(Muzikant muzikant)
    {
        _muzikantRepository.EditMuzikant(new MuzikantDTO(muzikant));
        foreach (int nummerId in _muzikantNummerRepository.GetNummers(muzikant.Id))
        {
            _muzikantNummerRepository.RemoveConnection(muzikant.Id, nummerId);
        }

        foreach (int nummerId in muzikant.NummerIds)
        {
            _muzikantNummerRepository.PostConnection(muzikant.Id, nummerId);
        }

        foreach (int setlistId in _muzikantSetlistRepository.GetSetlists(muzikant.Id))
        {
            _muzikantSetlistRepository.RemoveConnection(muzikant.Id, setlistId);
        }

        foreach (int setlistId in muzikant.SetlistIds)
        {
            _muzikantSetlistRepository.PostConnection(muzikant.Id, setlistId);
        }

        foreach (int bandId in _muzikantBandRepository.GetBands(muzikant.Id))
        {
            _muzikantBandRepository.RemoveConnection(muzikant.Id, bandId);
        }

        foreach (int bandId in muzikant.BandIds)
        {
            _muzikantBandRepository.PostConnection(muzikant.Id, bandId);
        }
    }

    public List<Muzikant> SearchMuzikant(string query)
    {
        List<Muzikant> MuzikantList = new List<Muzikant>();
        foreach (MuzikantDTO muzikantDto in _muzikantRepository.SearchMuzikant(query))
        {
            List<int> bandIds = new List<int>();
            foreach (int bandId in _muzikantBandRepository.GetBands(muzikantDto.Id))
            {
                bandIds.Add(bandId);
            }

            List<int> nummerIds = new List<int>();
            foreach (int nummerId in _muzikantNummerRepository.GetNummers(muzikantDto.Id))
            {
                nummerIds.Add(nummerId);
            }

            List<int> setlistIds = new List<int>();
            foreach (int setlistId in _muzikantSetlistRepository.GetSetlists(muzikantDto.Id))
            {
                setlistIds.Add(setlistId);
            }

            MuzikantList.Add(new Muzikant(muzikantDto, bandIds, nummerIds, setlistIds));
        }
        return MuzikantList;
    }
}