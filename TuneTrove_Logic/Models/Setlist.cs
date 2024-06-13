using TuneTrove_Logic.IRepositories;
using System;
using System.Collections.Generic;

namespace TuneTrove_Logic.Models;

public class Setlist
{
    private int _id;
    private DateTime _date;
    private Func<List<Muzikant>>? _loadMuzikants;
    private Func<List<Nummer>>? _loadNummers;
    private Func<List<Band>>? _loadBands;

    public Setlist(int id, DateTime date)
    {
        _id = id;
        _date = date;
    }

    public void LoadMuzikants(IMuzikantRepository muzikantSetlistRepository)
    {
        this._loadMuzikants = () => muzikantSetlistRepository.GetMuzikantsBySetlistId(_id);
    }

    public void LoadNummers(INummerRepository nummerSetlistRepository)
    {
        this._loadNummers = () => nummerSetlistRepository.GetNummersBySetlistId(_id);
    }

    public void LoadBands(IBandRepository bandSetlistRepository)
    {
        this._loadBands = () => bandSetlistRepository.GetBandsBySetlistId(_id);
    }

    public List<Muzikant> GiveMuzikants(IMuzikantRepository muzikantRepository)
    {
        LoadMuzikants(muzikantRepository);
        try
        {
            return this._loadMuzikants?.Invoke() ?? new List<Muzikant>();
        }
        catch
        {
            throw new Exception("Data retrieval failed");
        }
    }

    public List<Nummer> GiveNummers(INummerRepository nummerRepository)
    {
        LoadNummers(nummerRepository);
        try
        {
            return this._loadNummers?.Invoke() ?? new List<Nummer>();
        }
        catch
        {
            throw new Exception("Data retrieval failed");
        }
    }

    public List<Band> GiveBands(IBandRepository bandRepository)
    {
        LoadBands(bandRepository);
        try
        {
            return this._loadBands?.Invoke() ?? new List<Band>();
        }
        catch
        {
            throw new Exception("Data retrieval failed");
        }
    }

    public DateTime GiveDate()
    {
        return this._date;
    }

    public int GiveId()
    {
        return this._id;
    }
}