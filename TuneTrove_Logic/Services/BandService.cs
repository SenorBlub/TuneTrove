using TuneTrove_Logic.DAL_Interfaces;
using TuneTrove_Logic.Models;
using TuneTrove_Logic.Presentation_Interfaces;

namespace TuneTrove_Logic.Services;

public class BandService : IBandService
{
    private IBandRepository _repository;
    public List<Band> GetAllBands()
    {
        List<Band> BandList = new List<Band>();
        foreach (BandDTO bandDTO in _repository.GetAllBands())
        {
            BandList.Add(new Band(bandDTO));
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