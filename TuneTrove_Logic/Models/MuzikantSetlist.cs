namespace TuneTrove_Logic.Models;

public class MuzikantSetlist
{
    private int _id;
    private int _muzikantId;
    private int _setlistId;
    public MuzikantSetlist(int id, int muzikantId, int setlistId)
    {
        _id = id;
        _muzikantId = muzikantId;
        _setlistId = setlistId;
    }
}