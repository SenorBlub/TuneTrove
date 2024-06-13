using TuneTrove_Logic.IRepositories;
using System;
using System.Collections.Generic;

namespace TuneTrove_Logic.Models;

public class Muzikant
{
    private int _id;
    private string _name;
    private string _instrument;
    private Func<List<Band>>? _loadBands;
    private Func<List<Setlist>>? _loadSetlists;
    private Func<List<Nummer>>? _loadNummers;

    public Muzikant(int id, string name, string instrument)
    {
        _id = id;
        _name = name;
        _instrument = instrument;
    }

    public void LoadBands(IBandRepository muzikantBandRepository)
    {
        this._loadBands = () => muzikantBandRepository.GetBandsByMuzikantId(_id);
    }

    public void LoadSetlists(ISetlistRepository muzikantSetlistRepository)
    {
        this._loadSetlists = () => muzikantSetlistRepository.GetSetlistsByMuzikantId(_id);
    }

    public void LoadNummers(INummerRepository muzikantNummerRepository)
    {
        this._loadNummers = () => muzikantNummerRepository.GetNummersByMuzikantId(_id);
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

    public List<Setlist> GiveSetlists(ISetlistRepository setlistRepository)
    {
        LoadSetlists(setlistRepository);
        try
        {
            return this._loadSetlists?.Invoke() ?? new List<Setlist>();
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

    public string GiveName()
    {
        return this._name;
    }

    public string GiveInstrument()
    {
        return this._instrument;
    }

    public int GiveId()
    {
        return this._id;
    }
}
