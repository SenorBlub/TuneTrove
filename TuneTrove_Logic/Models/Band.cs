using TuneTrove_Logic.IRepositories;

namespace TuneTrove_Logic.Models;

public class Band
{
    private int _id;
    private string _name;
    private int _bandLeiderId;
    private Func<List<Muzikant>>? _loadMuzikants;
    private Func<List<Setlist>>? _loadSetlists;
    private Func<Muzikant>? _loadBandleider;

    public Band(int id, string name, int bandLeiderId)
    {
        _id = id;
        _name = name;
        _bandLeiderId = bandLeiderId;
    }

    private void LoadMuzikants(IMuzikantRepository muzikantRepository)
    {
        this._loadMuzikants = () => muzikantRepository.GetMuzikantsByBandId(_id);
    }

    private void LoadSetlists(ISetlistRepository setlistRepository)
    {
        this._loadSetlists = () => setlistRepository.GetSetlistsByBandId(_id);
    }

    private void LoadBandLeider(IMuzikantRepository muzikantRepository)
    {
        this._loadBandleider = () => muzikantRepository.GetMuzikant(_bandLeiderId);
    }

    public Muzikant GiveBandLeider(IMuzikantRepository muzikantRepository)
    {
        LoadBandLeider(muzikantRepository);
        try
        {
            return this._loadBandleider.Invoke();
        }
        catch
        {
            throw new Exception("Data retrieval failed");
        }
    }

    public List<Muzikant> GiveMuzikants(IMuzikantRepository muzikantRepository)
    {
        LoadMuzikants(muzikantRepository);
        try
        {
            return this._loadMuzikants.Invoke();
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
            return this._loadSetlists.Invoke();
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

    public int GiveBandleiderId()
    {
        return this._bandLeiderId;
    }

    public int GiveId()
    {
        return this._id;
    }
}