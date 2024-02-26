namespace TuneTrove_Logic.Models;

public class BandDTO
{
    public BandDTO(int id, int bandLeider)
    {
        Id = id;
        BandLeider = bandLeider;
    }

    public BandDTO(Band band)
    {
        Id = band.Id;
        BandLeider = band.BandLeider;
    }
    public int Id { get; set; }
    public int BandLeider { get; set; }
}