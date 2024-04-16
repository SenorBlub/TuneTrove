using TuneTrove_Logic.Models;

namespace TuneTrove_Logic.DTO;

public class BandDTO
{
    public BandDTO(int id, string name, int bandLeider)
    {
        Id = id;
        BandLeider = bandLeider;
        Name = name;
    }

    public BandDTO(Band band)
    {
        Id = band.Id;
        BandLeider = band.BandLeider;
        Name = band.Name;
    }
    public int Id { get; set; }
    public int BandLeider { get; set; }
    public string Name { get; set; }
}