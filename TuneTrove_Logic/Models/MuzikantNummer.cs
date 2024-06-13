namespace TuneTrove_Logic.Models;

public class MuzikantNummer
{
    private int _id;
    private int _muzikantId;
    private int _nummerId;
    public MuzikantNummer(int id, int muzikantId, int nummerId)
    {
        _id = id;
        _muzikantId = muzikantId;
        _nummerId = nummerId;
    }
}