using TuneTrove_Logic.Models;

namespace TuneTrove_Logic.DTOs;

public class MuzikantDTO
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Instrument { get; private set; }
    public List<BandDTO>? Bands { get; private set; }
    public List<NummerDTO>? Nummers { get; private set; }
    public List<SetlistDTO>? Setlists { get; private set; }

    public MuzikantDTO(int id, string name, string instrument, List<BandDTO>? bands, List<NummerDTO>? nummers, List<SetlistDTO>? setlists)
    {
        Id = id;
        Name = name;
        Instrument = instrument;
        Bands = bands;
        Nummers = nummers;
        Setlists = setlists;
    }

    public MuzikantDTO(int id, string name, string instrument)
    {
        Id = id;
        Name = name;
        Instrument = instrument;
    }
}