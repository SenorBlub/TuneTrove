using System.Diagnostics;
using System.Runtime;
using Microsoft.VisualBasic.FileIO;
using TuneTrove_Logic.DAL_Interfaces;
using TuneTrove_Logic.DTO;
using TuneTrove_Logic.Models;
using TuneTrove_Logic.Presentation_Interfaces;

namespace TuneTrove_Logic.Services;
// !TODO no HTTP verbs
public class BandServiceold : IBandService
{
    private IBandRepository _bandRepository;
    private IMuzikantBandRepository _muzikantBandRepository;
    private ISetlistRepository _setlistRepository;
    private IBandSetlistRepository _bandSetlistRepository;
    private IMuzikantService _muzikantService;
    private ISetlistService _setlistService;

    public BandService(IBandRepository bandRepository, IMuzikantBandRepository muzikantBandRepository, ISetlistRepository setlistRepository, IBandSetlistRepository bandSetlistRepository, IMuzikantService muzikantService, ISetlistService setlistService)
    {
        _bandRepository = bandRepository;
        _muzikantBandRepository = muzikantBandRepository;
        _setlistRepository = setlistRepository;
        _bandSetlistRepository = bandSetlistRepository;
        _muzikantService = muzikantService;
        _setlistService = setlistService;
    }

    public List<Band> GetAllBands()
    {
        List<Band> BandList = new List<Band>();
        foreach (BandDTO bandDTO in _bandRepository.GetAllBands())
        {
            
            List<int> muzikantList = new List<int>();
            foreach (int muzikantId in _muzikantBandRepository.GetMuzikanten(bandDTO.Id))
            {
                muzikantList.Add(muzikantId);
            }

            List<int> setlistList = new List<int>();
            foreach (int setlistId in _bandSetlistRepository.GetSetlists(bandDTO.Id))
            {
                setlistList.Add(setlistId);
            }
            BandList.Add(new Band(bandDTO, muzikantList, setlistList));
        }
        
        return BandList;
    }

    public Band GetBandById(int id)
    {
        BandDTO bandDto = _bandRepository.GetBandById(id);

        List<int> muzikantList = new List<int>();
        foreach (int muzikantId in _muzikantBandRepository.GetMuzikanten(id))
        {
            muzikantList.Add(muzikantId);
        }

        List<int> setlistList = new List<int>();
        foreach (int setlistId in _bandSetlistRepository.GetSetlists(id))
        {
            setlistList.Add(setlistId);
        }

        return new Band(bandDto, setlistList, muzikantList);
    }

    public void PostBand(Band band)
    {
        _bandRepository.PostBand(new BandDTO(band));
        if (band.MuzikantIds != null)
        {
	        foreach (int muzikantId in band.MuzikantIds)
	        {
		        _muzikantBandRepository.PostConnection(muzikantId, band.Id);
	        }
        }
        _muzikantBandRepository.PostConnection((int)band.BandLeiderId, band.Id);
    }

    public void RemoveBand(int id)
    {
        foreach (int muzikantId in _muzikantBandRepository.GetMuzikanten(id))
        {
            _muzikantBandRepository.RemoveConnection(muzikantId, id);
        }

        foreach (int setlistId in _bandSetlistRepository.GetSetlists(id))
        {
            _bandSetlistRepository.RemoveConnection(setlistId, id);
            if(_setlistService.GetSetlistById(setlistId).BandIds == null)
                _setlistRepository.RemoveSetlist(setlistId);
        }
        _bandRepository.RemoveBand(id);
    }

    public void EditBand(Band band)
    {
        // Remove all existing musician connections for the band
        foreach (int muzikantId in _muzikantBandRepository.GetMuzikanten(band.Id))
        {
            _muzikantBandRepository.RemoveConnection(muzikantId, band.Id);
        }

        // Add the new musician connections for the band
        foreach (int muzikantId in band.MuzikantIds)
        {
            _muzikantBandRepository.PostConnection(muzikantId, band.Id);
        }

        // Handle setlist connections
        var existingSetlists = _bandSetlistRepository.GetSetlists(band.Id).ToList();
        var updatedSetlists = band.SetlistIds;

        // Remove old setlists that are not in the updated list
        foreach (var existingSetlistId in existingSetlists)
        {
            if (!updatedSetlists.Contains(existingSetlistId))
            {
                _bandSetlistRepository.RemoveConnection(existingSetlistId, band.Id);
                if(_setlistService.GetSetlistById(existingSetlistId).BandIds == null)
                    _setlistRepository.RemoveSetlist(existingSetlistId);
            }
        }

        // Add new setlists that are not already in the existing list
        foreach (var newSetlistId in updatedSetlists)
        {
            if (!existingSetlists.Contains(newSetlistId))
            {
                _bandSetlistRepository.PostConnection(newSetlistId, band.Id);
            }
        }

        // Update the band's core details
        _bandRepository.EditBand(new BandDTO(band));
    }


    public List<Band> GetMuzikantRelatedBands(int muzikantId)
    {
        List<int> bandIds = _muzikantBandRepository.GetBands(muzikantId);

        List<Band> bands = new List<Band>();
        foreach (int bandId in bandIds)
        {
            bands.Add(GetBandById(bandId));
        }

        return bands;
    }

    public Band PopulateBand(Band band)
    {
	    band.BandLeider = _muzikantService.GetMuzikantById((int)band.BandLeiderId);
	    if (band.Muzikanten == null)
		    band.Muzikanten = new List<Muzikant>();
	    if (band.Setlists == null)
		    band.Setlists = new List<Setlist>();
	    foreach (int muzikantId in band.MuzikantIds)
	    {
		    band.Muzikanten.Add(_muzikantService.GetMuzikantById(muzikantId));
	    }

	    foreach (int setlistId in band.SetlistIds)
	    {
            band.Setlists.Add(_setlistService.GetSetlistById(setlistId));
	    }
	    return band;
    }

    public List<Band> GetAllBandsPopulated()
    {
        Stopwatch st = Stopwatch.StartNew();
        
        List<Band> BandList = new List<Band>();
        foreach (BandDTO bandDTO in _bandRepository.GetAllBands())
        {

            List<Muzikant> muzikantList = new List<Muzikant>();
            foreach (int muzikantId in _muzikantBandRepository.GetMuzikanten(bandDTO.Id))
            {
                muzikantList.Add(_muzikantService.GetMuzikantById(muzikantId));
            }

            List<Setlist> setlistList = new List<Setlist>();
            foreach (int setlistId in _bandSetlistRepository.GetSetlists(bandDTO.Id))
            {
                setlistList.Add(_setlistService.GetSetlistById(setlistId));
            }
            BandList.Add(new Band(bandDTO, muzikantList, setlistList));
        }
        st.Stop();
        Console.WriteLine(st.ElapsedMilliseconds);
        return BandList;
    }
}