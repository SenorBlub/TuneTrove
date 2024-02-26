namespace TuneTrove_Logic.Models;

public class Band
{
    public Band(int id, int bandLeider, List<int> setlists, List<Muzikant> bandLeden)
    {
        Id = id;
        BandLeider = bandLeider;
        Setlists = setlists;
        BandLeden = bandLeden;
    }

    public Band(BandDTO bandDto)
    {
        Id = bandDto.Id;
        BandLeider = bandDto.BandLeider;
        BandLeden = bandDto.BandLeden;
        Setlists = bandDto.Setlists;
    }

    public int Id { get; set; }
    public int BandLeider { get; set; }
    public List<int> Setlists { get; set; }
    public List<Muzikant> BandLeden { get; set; }
}