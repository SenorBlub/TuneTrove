using TuneTrove_Logic.DAL_Interfaces;
using TuneTrove_Logic.Models;
using TuneTrove_Logic.Presentation_Interfaces;

namespace TuneTrove_Logic.Services;

public class BandService : IBandService
{
    private IBandRepository _bandRepository;
    private IMuzikantBandRepository _muzikantBandRepository;
    private IMuzikantRepository _muzikantRepository;
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
        return new Band(_repository.GetBandById(id));
    }

    public void PostBand(Band band)
    {
        _repository.PostBand(new BandDTO(band));
    }

    public void RemoveBand(int id)
    {
        _repository.RemoveBand(id);
    }

    public void EditBand(Band band)
    {
        _repository.EditBand(new BandDTO(band));
    }
}