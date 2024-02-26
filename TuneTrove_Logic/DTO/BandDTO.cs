namespace TuneTrove_Logic.Models;

public class BandDTO
{
    public BandDTO(int id, int bandLeider, List<int> setlists, List<Muzikant> bandLeden)
    {
        Id = id;
        BandLeider = bandLeider;
        Setlists = setlists;
        BandLeden = bandLeden;
    }

    public BandDTO(Band band)
    {
        Id = band.Id;
        BandLeider = band.BandLeider;
        BandLeden = band.BandLeden;
        Setlists = band.Setlists;
    }
    public int Id { get; set; }
    public int BandLeider { get; set; }
    public List<int> Setlists { get; set; }
    public List<Muzikant> BandLeden { get; set; }
}