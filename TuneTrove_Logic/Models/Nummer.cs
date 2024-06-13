using TuneTrove_Logic.IRepositories;
using System;
using System.Collections.Generic;

namespace TuneTrove_Logic.Models;

public class Nummer
{
    private int _id;
    private string _name;
    private int _length;
    private string _artiest;
    private Func<List<Setlist>>? _loadSetlists;

    public Nummer(int id, string name, int length, string artiest)
    {
        _id = id;
        _name = name;
        _length = length;
        _artiest = artiest;
    }

    public void LoadSetlists(ISetlistRepository nummerSetlistRepository)
    {
        this._loadSetlists = () => nummerSetlistRepository.GetSetlistsByNummerId(_id);
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

    public string GiveName()
    {
        return this._name;
    }

    public int GiveLength()
    {
        return this._length;
    }

    public string GiveArtiest()
    {
        return this._artiest;
    }

    public int GiveId()
    {
        return this._id;
    }
}