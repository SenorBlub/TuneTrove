using TuneTrove_Logic.DTOs;
using TuneTrove_Logic.IRepositories;
using TuneTrove_Logic.IServices;
using TuneTrove_Logic.Models;
using System.Collections.Generic;

namespace TuneTrove_Logic.Services;

public class MuzikantService : IMuzikantService
{
    private readonly IMuzikantRepository _muzikantRepository;
    private readonly IMuzikantBandRepository _muzikantBandRepository;
    private readonly IMuzikantNummerRepository _muzikantNummerRepository;
    private readonly IMuzikantSetlistRepository _muzikantSetlistRepository;
    private readonly IBandRepository _bandRepository;
    private readonly INummerRepository _nummerRepository;
    private readonly ISetlistRepository _setlistRepository;

    public MuzikantService(IMuzikantRepository muzikantRepository, IMuzikantBandRepository muzikantBandRepository, IMuzikantNummerRepository muzikantNummerRepository, IMuzikantSetlistRepository muzikantSetlistRepository, ISetlistRepository setlistRepository, IBandRepository bandRepository, INummerRepository nummerRepository)
    {
        _muzikantRepository = muzikantRepository;
        _muzikantBandRepository = muzikantBandRepository;
        _muzikantNummerRepository = muzikantNummerRepository;
        _muzikantSetlistRepository = muzikantSetlistRepository;
        _setlistRepository = setlistRepository;
        _bandRepository = bandRepository;
        _nummerRepository = nummerRepository;
    }

    public void AddMuzikant(MuzikantDTO muzikantDto)
    {
        var muzikant = new Muzikant(muzikantDto.Id, muzikantDto.Name, muzikantDto.Instrument);
        _muzikantRepository.AddMuzikant(muzikant);

        _muzikantBandRepository.ConnectMuzikantToBands(muzikantDto.Id, muzikantDto.Bands.Select(b => b.Id).ToList());
        _muzikantNummerRepository.ConnectMuzikantToNummers(muzikantDto.Id, muzikantDto.Nummers.Select(n => n.Id).ToList());
        _muzikantSetlistRepository.ConnectMuzikantToSetlists(muzikantDto.Id, muzikantDto.Setlists.Select(s => s.Id).ToList());
    }

    public void RemoveMuzikant(int id)
    {
        _muzikantRepository.DeleteMuzikant(id);
    }

    public void RemoveMuzikant(Muzikant muzikant)
    {
        _muzikantRepository.DeleteMuzikant(muzikant.GiveId());
    }

    public void RemoveMuzikant(MuzikantDTO muzikantDto)
    {
        _muzikantRepository.DeleteMuzikant(muzikantDto.Id);
    }

    public void UpdateMuzikant(Muzikant muzikant)
    {
        _muzikantRepository.UpdateMuzikant(muzikant, muzikant.GiveId());
    }

    public void UpdateMuzikant(MuzikantDTO muzikantDto)
    {
        var muzikant = new Muzikant(muzikantDto.Id, muzikantDto.Name, muzikantDto.Instrument);
        _muzikantRepository.UpdateMuzikant(muzikant, muzikantDto.Id);
    }

    public MuzikantDTO GetMuzikant(int id)
    {
        var muzikant = _muzikantRepository.GetMuzikant(id);
        var bands = _bandRepository.GetBandsByMuzikantId(id);
        var nummers = _nummerRepository.GetNummersByMuzikantId(id);
        var setlists = _setlistRepository.GetSetlistsByMuzikantId(id);

        var bandDtos = new List<BandDTO>();
        foreach (var band in bands)
        {
            var bandLeider = band.GiveBandLeider(_muzikantRepository);
            var bandLeiderDto = new MuzikantDTO(bandLeider.GiveId(), bandLeider.GiveName(), bandLeider.GiveInstrument());
            bandDtos.Add(new BandDTO(band.GiveId(), band.GiveName(), bandLeiderDto, new List<MuzikantDTO>(), new List<SetlistDTO>()));
        }

        var nummerDtos = new List<NummerDTO>();
        foreach (var nummer in nummers)
        {
            nummerDtos.Add(new NummerDTO(nummer.GiveId(), nummer.GiveName(), nummer.GiveLength(), nummer.GiveArtiest()));
        }

        var setlistDtos = new List<SetlistDTO>();
        foreach (var setlist in setlists)
        {
            setlistDtos.Add(new SetlistDTO(setlist.GiveId(), setlist.GiveDate()));
        }

        return new MuzikantDTO(muzikant.GiveId(), muzikant.GiveName(), muzikant.GiveInstrument(), bandDtos, nummerDtos, setlistDtos);
    }

    public List<MuzikantDTO> GetAllMuzikanten()
    {
        var muzikanten = _muzikantRepository.GetAllMuzikants();
        var muzikantDtos = new List<MuzikantDTO>();

        foreach (var muzikant in muzikanten)
        {
            var bands = _bandRepository.GetBandsByMuzikantId(muzikant.GiveId());
            var nummers = _nummerRepository.GetNummersByMuzikantId(muzikant.GiveId());
            var setlists = _setlistRepository.GetSetlistsByMuzikantId(muzikant.GiveId());

            var bandDtos = new List<BandDTO>();
            foreach (var band in bands)
            {
                var bandLeider = band.GiveBandLeider(_muzikantRepository);
                var bandLeiderDto = new MuzikantDTO(bandLeider.GiveId(), bandLeider.GiveName(), bandLeider.GiveInstrument());
                bandDtos.Add(new BandDTO(band.GiveId(), band.GiveName(), bandLeiderDto, new List<MuzikantDTO>(), new List<SetlistDTO>()));
            }

            var nummerDtos = new List<NummerDTO>();
            foreach (var nummer in nummers)
            {
                nummerDtos.Add(new NummerDTO(nummer.GiveId(), nummer.GiveName(), nummer.GiveLength(), nummer.GiveArtiest()));
            }

            var setlistDtos = new List<SetlistDTO>();
            foreach (var setlist in setlists)
            {
                setlistDtos.Add(new SetlistDTO(setlist.GiveId(), setlist.GiveDate()));
            }

            muzikantDtos.Add(new MuzikantDTO(muzikant.GiveId(), muzikant.GiveName(), muzikant.GiveInstrument(), bandDtos, nummerDtos, setlistDtos));
        }

        return muzikantDtos;
    }

    public List<MuzikantDTO> GetMuzikantPage(int pageSize, int pageNum)
    {
        var muzikanten = _muzikantRepository.GetMuzikantPage(pageSize, pageNum);
        var muzikantDtos = new List<MuzikantDTO>();

        foreach (var muzikant in muzikanten)
        {
            var bands = _bandRepository.GetBandsByMuzikantId(muzikant.GiveId());
            var nummers = _nummerRepository.GetNummersByMuzikantId(muzikant.GiveId());
            var setlists = _setlistRepository.GetSetlistsByMuzikantId(muzikant.GiveId());

            var bandDtos = new List<BandDTO>();
            foreach (var band in bands)
            {
                var bandLeider = band.GiveBandLeider(_muzikantRepository);
                var bandLeiderDto = new MuzikantDTO(bandLeider.GiveId(), bandLeider.GiveName(), bandLeider.GiveInstrument());
                bandDtos.Add(new BandDTO(band.GiveId(), band.GiveName(), bandLeiderDto, new List<MuzikantDTO>(), new List<SetlistDTO>()));
            }

            var nummerDtos = new List<NummerDTO>();
            foreach (var nummer in nummers)
            {
                nummerDtos.Add(new NummerDTO(nummer.GiveId(), nummer.GiveName(), nummer.GiveLength(), nummer.GiveArtiest()));
            }

            var setlistDtos = new List<SetlistDTO>();
            foreach (var setlist in setlists)
            {
                setlistDtos.Add(new SetlistDTO(setlist.GiveId(), setlist.GiveDate()));
            }

            muzikantDtos.Add(new MuzikantDTO(muzikant.GiveId(), muzikant.GiveName(), muzikant.GiveInstrument(), bandDtos, nummerDtos, setlistDtos));
        }

        return muzikantDtos;
    }
}
