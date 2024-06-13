using TuneTrove_Logic.DTOs;
using TuneTrove_Logic.IRepositories;
using TuneTrove_Logic.IServices;
using TuneTrove_Logic.Models;
using System.Collections.Generic;

namespace TuneTrove_Logic.Services;

public class SetlistService : ISetlistService
{
    private readonly ISetlistRepository _setlistRepository;
    private readonly INummerSetlistRepository _nummerSetlistRepository;
    private readonly IMuzikantSetlistRepository _muzikantSetlistRepository;
    private readonly IBandSetlistRepository _bandSetlistRepository;
    private readonly IBandRepository _bandRepository;
    private readonly INummerRepository _nummerRepository;
    private readonly IMuzikantRepository _muzikantRepository;

    public SetlistService(ISetlistRepository setlistRepository, INummerSetlistRepository nummerSetlistRepository, IMuzikantSetlistRepository muzikantSetlistRepository, IBandSetlistRepository bandSetlistRepository, IBandRepository bandRepository, INummerRepository nummerRepository, IMuzikantRepository muzikantRepository)
    {
        _setlistRepository = setlistRepository;
        _nummerSetlistRepository = nummerSetlistRepository;
        _muzikantSetlistRepository = muzikantSetlistRepository;
        _bandSetlistRepository = bandSetlistRepository;
        _bandRepository = bandRepository;
        _nummerRepository = nummerRepository;
        _muzikantRepository = muzikantRepository;
    }

    public void AddSetlist(SetlistDTO setlistDto)
    {
        var setlist = new Setlist(setlistDto.Id, setlistDto.Date);
        _setlistRepository.AddSetlist(setlist);
    }

    public void RemoveSetlist(int id)
    {
        _setlistRepository.DeleteSetlist(id);
    }

    public void RemoveSetlist(Setlist setlist)
    {
        _setlistRepository.DeleteSetlist(setlist.GiveId());
    }

    public void RemoveSetlist(SetlistDTO setlistDto)
    {
        _setlistRepository.DeleteSetlist(setlistDto.Id);
    }

    public void UpdateSetlist(Setlist setlist)
    {
        _setlistRepository.UpdateSetlist(setlist, setlist.GiveId());
    }

    public void UpdatSetlist(SetlistDTO setlistDto)
    {
        var setlist = new Setlist(setlistDto.Id, setlistDto.Date);
        _setlistRepository.UpdateSetlist(setlist, setlistDto.Id);
    }

    public SetlistDTO GetSetlist(int id)
    {
        var setlist = _setlistRepository.GetSetlist(id);
        var nummers = _nummerRepository.GetNummersBySetlistId(id);
        var muzikanten = _muzikantRepository.GetMuzikantsBySetlistId(id);
        var bands = _bandRepository.GetBandsBySetlistId(id);

        var nummerDtos = new List<NummerDTO>();
        foreach (var nummer in nummers)
        {
            nummerDtos.Add(new NummerDTO(nummer.GiveId(), nummer.GiveName(), nummer.GiveLength(), nummer.GiveArtiest()));
        }

        var muzikantDtos = new List<MuzikantDTO>();
        foreach (var muzikant in muzikanten)
        {
            muzikantDtos.Add(new MuzikantDTO(muzikant.GiveId(), muzikant.GiveName(), muzikant.GiveInstrument()));
        }

        var bandDtos = new List<BandDTO>();
        foreach (var band in bands)
        {
            var bandLeider = band.GiveBandLeider(_muzikantRepository);
            var bandLeiderDto = new MuzikantDTO(bandLeider.GiveId(), bandLeider.GiveName(), bandLeider.GiveInstrument());
            bandDtos.Add(new BandDTO(band.GiveId(), band.GiveName(), bandLeiderDto, new List<MuzikantDTO>(), new List<SetlistDTO>()));
        }

        return new SetlistDTO(setlist.GiveId(), setlist.GiveDate(), muzikantDtos, nummerDtos, bandDtos);
    }

    public List<SetlistDTO> GetAllSetlists()
    {
        var setlists = _setlistRepository.GetAllSetlists();
        var setlistDtos = new List<SetlistDTO>();

        foreach (var setlist in setlists)
        {
            var nummers = _nummerRepository.GetNummersBySetlistId(setlist.GiveId());
            var muzikanten = _muzikantRepository.GetMuzikantsBySetlistId(setlist.GiveId());
            var bands = _bandRepository.GetBandsBySetlistId(setlist.GiveId());

            var nummerDtos = new List<NummerDTO>();
            foreach (var nummer in nummers)
            {
                nummerDtos.Add(new NummerDTO(nummer.GiveId(), nummer.GiveName(), nummer.GiveLength(), nummer.GiveArtiest()));
            }

            var muzikantDtos = new List<MuzikantDTO>();
            foreach (var muzikant in muzikanten)
            {
                muzikantDtos.Add(new MuzikantDTO(muzikant.GiveId(), muzikant.GiveName(), muzikant.GiveInstrument()));
            }

            var bandDtos = new List<BandDTO>();
            foreach (var band in bands)
            {
                var bandLeider = band.GiveBandLeider(_muzikantRepository);
                var bandLeiderDto = new MuzikantDTO(bandLeider.GiveId(), bandLeider.GiveName(), bandLeider.GiveInstrument());
                bandDtos.Add(new BandDTO(band.GiveId(), band.GiveName(), bandLeiderDto, new List<MuzikantDTO>(), new List<SetlistDTO>()));
            }

            setlistDtos.Add(new SetlistDTO(setlist.GiveId(), setlist.GiveDate(), muzikantDtos, nummerDtos, bandDtos));
        }

        return setlistDtos;
    }

    public List<SetlistDTO> GetSetlistPage(int pageSize, int pageNum)
    {
        var setlists = _setlistRepository.GetSetlistPage(pageSize, pageNum);
        var setlistDtos = new List<SetlistDTO>();

        foreach (var setlist in setlists)
        {
            var nummers = _nummerRepository.GetNummersBySetlistId(setlist.GiveId());
            var muzikanten = _muzikantRepository.GetMuzikantsBySetlistId(setlist.GiveId());
            var bands = _bandRepository.GetBandsBySetlistId(setlist.GiveId());

            var nummerDtos = new List<NummerDTO>();
            foreach (var nummer in nummers)
            {
                nummerDtos.Add(new NummerDTO(nummer.GiveId(), nummer.GiveName(), nummer.GiveLength(), nummer.GiveArtiest()));
            }

            var muzikantDtos = new List<MuzikantDTO>();
            foreach (var muzikant in muzikanten)
            {
                muzikantDtos.Add(new MuzikantDTO(muzikant.GiveId(), muzikant.GiveName(), muzikant.GiveInstrument()));
            }

            var bandDtos = new List<BandDTO>();
            foreach (var band in bands)
            {
                var bandLeider = band.GiveBandLeider(_muzikantRepository);
                var bandLeiderDto = new MuzikantDTO(bandLeider.GiveId(), bandLeider.GiveName(), bandLeider.GiveInstrument());
                bandDtos.Add(new BandDTO(band.GiveId(), band.GiveName(), bandLeiderDto, new List<MuzikantDTO>(), new List<SetlistDTO>()));
            }

            setlistDtos.Add(new SetlistDTO(setlist.GiveId(), setlist.GiveDate(), muzikantDtos, nummerDtos, bandDtos));
        }

        return setlistDtos;
    }
}
