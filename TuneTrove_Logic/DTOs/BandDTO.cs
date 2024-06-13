using TuneTrove_Logic.Models;

namespace TuneTrove_Logic.DTOs;

public class BandDTO
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public MuzikantDTO? Bandleider { get; private set; }
    public List<MuzikantDTO>? Muzikanten { get; private set; }
    public List<SetlistDTO>? Setlists { get; private set; }

    public BandDTO(int id, string name, MuzikantDTO? bandleider, List<MuzikantDTO>? muzikanten, List<SetlistDTO>? setlists)
    {
        Id = id;
        Name = name;
        Bandleider = bandleider;
        Muzikanten = muzikanten;
        Setlists = setlists;
    }

    public BandDTO(int id, string name)
    {
        Id = id;
        Name = name;
    }
}