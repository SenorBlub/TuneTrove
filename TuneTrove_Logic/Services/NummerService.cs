using TuneTrove_Logic.DTOs;
using TuneTrove_Logic.IRepositories;
using TuneTrove_Logic.IServices;
using TuneTrove_Logic.Models;
using System.Collections.Generic;

namespace TuneTrove_Logic.Services;

public class NummerService : INummerService
{
    private readonly INummerRepository _nummerRepository;
    private readonly INummerSetlistRepository _nummerSetlistRepository;
    private readonly IMuzikantNummerRepository _muzikantNummerRepository;
    private readonly IMuzikantRepository _muzikantRepository;
    private readonly ISetlistRepository _setlistRepository;
    private readonly IBandRepository _bandRepository;

    public NummerService(INummerRepository nummerRepository, INummerSetlistRepository nummerSetlistRepository, IMuzikantNummerRepository muzikantNummerRepository, IMuzikantRepository muzikantRepository, ISetlistRepository setlistRepository, IBandRepository bandRepository)
    {
        _nummerRepository = nummerRepository;
        _nummerSetlistRepository = nummerSetlistRepository;
        _muzikantNummerRepository = muzikantNummerRepository;
        _bandRepository = bandRepository;
        _setlistRepository = setlistRepository;
        _muzikantRepository = muzikantRepository;
    }

    public void AddNummer(NummerDTO nummerDto)
    {
        var nummer = new Nummer(nummerDto.Id, nummerDto.Name, nummerDto.Length, nummerDto.Artiest);
        _nummerRepository.AddNummer(nummer);
    }

    public void RemoveNummer(int id)
    {
        _nummerRepository.DeleteNummer(id);
    }

    public void RemoveNummer(Nummer nummer)
    {
        _nummerRepository.DeleteNummer(nummer.GiveId());
    }

    public void RemoveNummer(NummerDTO nummerDto)
    {
        _nummerRepository.DeleteNummer(nummerDto.Id);
    }

    public void UpdateNummer(Nummer nummer)
    {
        _nummerRepository.UpdateNummer(nummer, nummer.GiveId());
    }

    public void UpdateNummer(NummerDTO nummerDto)
    {
        var nummer = new Nummer(nummerDto.Id, nummerDto.Name, nummerDto.Length, nummerDto.Artiest);
        _nummerRepository.UpdateNummer(nummer, nummerDto.Id);
    }

    public NummerDTO GetNummer(int id)
    {
        var nummer = _nummerRepository.GetNummer(id);
        var setlists = _setlistRepository.GetSetlistsByNummerId(id);
        var setlistDtos = new List<SetlistDTO>();

        foreach (var setlist in setlists)
        {
            setlistDtos.Add(new SetlistDTO(setlist.GiveId(), setlist.GiveDate()));
        }

        return new NummerDTO(nummer.GiveId(), nummer.GiveName(), nummer.GiveLength(), nummer.GiveArtiest(), setlistDtos);
    }

    public List<NummerDTO> GetAllNummers()
    {
        var nummers = _nummerRepository.GetAllNummers();
        var nummerDtos = new List<NummerDTO>();

        foreach (var nummer in nummers)
        {
            var setlists = _setlistRepository.GetSetlistsByNummerId(nummer.GiveId());
            var setlistDtos = new List<SetlistDTO>();

            foreach (var setlist in setlists)
            {
                setlistDtos.Add(new SetlistDTO(setlist.GiveId(), setlist.GiveDate()));
            }

            nummerDtos.Add(new NummerDTO(nummer.GiveId(), nummer.GiveName(), nummer.GiveLength(), nummer.GiveArtiest(), setlistDtos));
        }

        return nummerDtos;
    }

    public List<NummerDTO> GetNummerPage(int pageSize, int pageNum)
    {
        var nummers = _nummerRepository.GetNummerPage(pageSize, pageNum);
        var nummerDtos = new List<NummerDTO>();

        foreach (var nummer in nummers)
        {
            var setlists = _setlistRepository.GetSetlistsByNummerId(nummer.GiveId());
            var setlistDtos = new List<SetlistDTO>();

            foreach (var setlist in setlists)
            {
                setlistDtos.Add(new SetlistDTO(setlist.GiveId(), setlist.GiveDate()));
            }

            nummerDtos.Add(new NummerDTO(nummer.GiveId(), nummer.GiveName(), nummer.GiveLength(), nummer.GiveArtiest(), setlistDtos));
        }

        return nummerDtos;
    }
}
