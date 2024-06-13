namespace TuneTrove_Logic.Models;

public class NummerSetlist
{
    private int _id;
    private int _nummerId;
    private int _setlistId;

    public NummerSetlist(int id, int nummerId, int setlistId)
    {
        _id = id;
        _nummerId = nummerId;
        _setlistId = setlistId;
    }
}