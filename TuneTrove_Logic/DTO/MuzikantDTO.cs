using TuneTrove_Logic.Models;

namespace TuneTrove_Logic.DTO;

public class MuzikantDTO
{
    public MuzikantDTO(int id, string name, string instrument)
    {
        Id = id;
        Name = name;
        Instrument = instrument;
    }

    public MuzikantDTO(Muzikant muzikant)
    {
        Id = muzikant.Id;
        Name = muzikant.Name;
        Instrument = muzikant.Instrument;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Instrument { get; set; }
}