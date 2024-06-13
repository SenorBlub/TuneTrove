using TuneTrove_Logic.DTOs;
using TuneTrove_Logic.IRepositories;
using TuneTrove_Logic.IServices;
using TuneTrove_Logic.Models;

namespace TuneTrove_Logic.Services;

public class BandService : IBandService
{
    private IBandRepository _bandRepository;
    private IMuzikantBandRepository _muzikantBandRepository;
    private ISetlistRepository _setlistRepository;
    private IBandSetlistRepository _bandSetlistRepository;
    private IMuzikantService _muzikantService;
    private ISetlistService _setlistService;
    private readonly IMuzikantRepository _muzikantRepository;

    public BandService(IBandRepository bandRepository, IMuzikantBandRepository muzikantBandRepository, ISetlistRepository setlistRepository, IBandSetlistRepository bandSetlistRepository, IMuzikantService muzikantService, ISetlistService setlistService, IMuzikantRepository muzikantRepository)
    {
        _bandRepository = bandRepository;
        _muzikantBandRepository = muzikantBandRepository;
        _setlistRepository = setlistRepository;
        _bandSetlistRepository = bandSetlistRepository;
        _muzikantService = muzikantService;
        _setlistService = setlistService;
        _muzikantRepository = muzikantRepository;
    }
    public void AddBand(BandDTO band)
    {
        if (_muzikantService.GetMuzikant(band.Bandleider.Id) == null)
        {
            _muzikantService.AddMuzikant(band.Bandleider);
        }
        _bandRepository.AddBand(new Band(band.Id, band.Name, band.Bandleider.Id));
        List<int> muzikantIds = new List<int>();
        if (band.Muzikanten.Count() > 0)
        {
            foreach (MuzikantDTO muzikant in band.Muzikanten)
            {
                _muzikantService.AddMuzikant(muzikant);
                muzikantIds.Add(muzikant.Id);
            }
        }
        _muzikantBandRepository.ConnectMuzikantenToBand(muzikantIds, band.Id);

        List<int> setlistIds = new List<int>();
        if (band.Muzikanten.Count() > 0)
        {
            foreach (SetlistDTO setlist in band.Setlists)
            {
                _setlistService.AddSetlist(setlist);
                setlistIds.Add(setlist.Id);
            }
        }
        _bandSetlistRepository.ConnectBandToSetlists(band.Id, setlistIds);
    }

    public void RemoveBand(int bandId)
    {
        _bandRepository.DeleteBand(bandId);
    }

    public void RemoveBand(Band band)
    {
        int bandId = band.GiveId();
        _bandRepository.DeleteBand(bandId);
    }

    public void RemoveBand(BandDTO band)
    {
        int bandId = band.Id;
        _bandRepository.DeleteBand(bandId);
    }

    public void UpdateBand(BandDTO band)
    {
        Band newBand = new Band(band.Id, band.Name, band.Bandleider.Id);
        _bandRepository.UpdateBand(newBand, band.Id);
    }

    public void UpdateBand(Band band)
    {
        _bandRepository.UpdateBand(band, band.GiveId());
    }

    public BandDTO GetBand(int bandId)
    {
        Band tempBand = _bandRepository.GetBand(bandId);
        Muzikant tempBandLeider = tempBand.GiveBandLeider(_muzikantRepository);
        MuzikantDTO bandLeider = new MuzikantDTO(tempBandLeider.GiveId(), tempBandLeider.GiveName(), tempBandLeider.GiveInstrument());
        List<MuzikantDTO> muzikanten = new List<MuzikantDTO>();
        foreach (Muzikant muzikant in tempBand.GiveMuzikants(_muzikantRepository))
        {
            MuzikantDTO tempMuzikantDto = new MuzikantDTO(muzikant.GiveId(), muzikant.GiveName(), muzikant.GiveInstrument());
            muzikanten.Add(tempMuzikantDto);
        }

        List<SetlistDTO> setlists = new List<SetlistDTO>();
        foreach (Setlist setlist in tempBand.GiveSetlists(_setlistRepository))
        {
            SetlistDTO tempSetlistDto = new SetlistDTO(setlist.GiveId(), setlist.GiveDate());
            setlists.Add(tempSetlistDto);
        }
        BandDTO band = new BandDTO(tempBand.GiveId(), tempBand.GiveName(), bandLeider, muzikanten, setlists);

        return band;
    }

    public List<BandDTO> GetAllBands()
    {
        List<BandDTO> bands = new List<BandDTO>();
        foreach (Band tempBand in _bandRepository.GetAllBands())
        {
            Muzikant tempBandLeider = tempBand.GiveBandLeider(_muzikantRepository);
            MuzikantDTO bandLeider = new MuzikantDTO(tempBandLeider.GiveId(), tempBandLeider.GiveName(),
                tempBandLeider.GiveInstrument());
            List<MuzikantDTO> muzikanten = new List<MuzikantDTO>();
            foreach (Muzikant muzikant in tempBand.GiveMuzikants(_muzikantRepository))
            {
                MuzikantDTO tempMuzikantDto =
                    new MuzikantDTO(muzikant.GiveId(), muzikant.GiveName(), muzikant.GiveInstrument());
                muzikanten.Add(tempMuzikantDto);
            }

            List<SetlistDTO> setlists = new List<SetlistDTO>();
            foreach (Setlist setlist in tempBand.GiveSetlists(_setlistRepository))
            {
                SetlistDTO tempSetlistDto = new SetlistDTO(setlist.GiveId(), setlist.GiveDate());
                setlists.Add(tempSetlistDto);
            }

            bands.Add(new BandDTO(tempBand.GiveId(), tempBand.GiveName(), bandLeider, muzikanten, setlists));
        }

        return bands;
    }

    public List<BandDTO> GetBandPage(int pageSize, int pageNum)
    {
        List<BandDTO> bands = new List<BandDTO>();
        foreach (Band tempBand in _bandRepository.GetBandPage(pageNum, pageSize))
        {
            Muzikant tempBandLeider = tempBand.GiveBandLeider(_muzikantRepository);
            MuzikantDTO bandLeider = new MuzikantDTO(tempBandLeider.GiveId(), tempBandLeider.GiveName(),
                tempBandLeider.GiveInstrument());
            List<MuzikantDTO> muzikanten = new List<MuzikantDTO>();
            foreach (Muzikant muzikant in tempBand.GiveMuzikants(_muzikantRepository))
            {
                MuzikantDTO tempMuzikantDto =
                    new MuzikantDTO(muzikant.GiveId(), muzikant.GiveName(), muzikant.GiveInstrument());
                muzikanten.Add(tempMuzikantDto);
            }

            List<SetlistDTO> setlists = new List<SetlistDTO>();
            foreach (Setlist setlist in tempBand.GiveSetlists(_setlistRepository))
            {
                SetlistDTO tempSetlistDto = new SetlistDTO(setlist.GiveId(), setlist.GiveDate());
                setlists.Add(tempSetlistDto);
            }

            bands.Add(new BandDTO(tempBand.GiveId(), tempBand.GiveName(), bandLeider, muzikanten, setlists));
        }

        return bands;
    }
}