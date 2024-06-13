namespace TuneTrove_Logic.Models;

public class MuzikantBand
{
    private int _id;
    private int _muzikantId;
    private int _bandId;
    public MuzikantBand(int id, int muzikantId, int bandId)
    {
        _id = id;
        _muzikantId = muzikantId;
        _bandId = bandId;
    }
}