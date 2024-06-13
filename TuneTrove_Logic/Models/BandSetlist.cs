namespace TuneTrove_Logic.Models;

public class BandSetlist
{
    private int _id;
    private int _bandId;
    private int _setlistId;
    public BandSetlist(int id, int bandId, int setlistId)
    {
        _id = id;
        _bandId = bandId;
        _setlistId = setlistId;
    }
}