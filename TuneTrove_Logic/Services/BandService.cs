using Microsoft.VisualBasic.FileIO;
using TuneTrove_Logic.DAL_Interfaces;
using TuneTrove_Logic.Models;
using TuneTrove_Logic.Presentation_Interfaces;

namespace TuneTrove_Logic.Services;

public class BandService : IBandService
{
    private IBandRepository _bandRepository;
    private IMuzikantBandRepository _muzikantBandRepository;
    private ISetlistRepository _setlistRepository;
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
            foreach (int setlistId in _setlistRepository.getSetlistsByBand(bandDTO.Id))
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
        foreach (int setlistId in _setlistRepository.getSetlistsByBand(id))
        {
            setlistList.Add(setlistId);
        }

        return new Band(bandDto, setlistList, muzikantList);
    }

    public void PostBand(Band band)
    {
        _bandRepository.PostBand(new BandDTO(band));
        foreach (int muzikantId in band.MuzikantIds)
        {
            _muzikantBandRepository.PostConnection(muzikantId, band.Id);
        }
    }

    public void RemoveBand(int id)
    {
        _bandRepository.RemoveBand(id);
        foreach (int muzikantId in _muzikantBandRepository.GetMuzikanten(id))
        {
            _muzikantBandRepository.RemoveConnection(muzikantId, id);
        }

        foreach (int setlistId in _setlistRepository.getSetlistsByBand(id))
        {
            _setlistRepository.RemoveSetlist(setlistId);
        }
    }

    public void EditBand(Band band)
    {
        foreach (int muzikantId in _muzikantBandRepository.GetMuzikanten(band.Id))
        {
            _muzikantBandRepository.RemoveConnection(muzikantId, band.Id);
        }

        foreach (int muzikantId in band.MuzikantIds)
        {
            _muzikantBandRepository.PostConnection(muzikantId, band.Id);
        }

        foreach (int bandSetlistId in band.SetlistIds)
        {
            bool delete = true;
            foreach (SetlistDTO setlistId in _setlistRepository.GetAllSetlists())
            {
                if (setlistId.Id == band.Id)
                    delete = false;
            }
            if(delete)
                _setlistRepository.RemoveSetlist(bandSetlistId);
        }

        _bandRepository.EditBand(new BandDTO(band));
    }
}