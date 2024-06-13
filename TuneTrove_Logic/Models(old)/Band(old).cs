using TuneTrove_Logic.DTO;

namespace TuneTrove_Logic.Models;

public class Bandold
{
    public Band(int id, string name, int bandLeider, List<int> setlistIds, List<int> muzikantIds)
    {
        Id = id;
        BandLeiderId = bandLeider;
        SetlistIds = setlistIds;
        MuzikantIds = muzikantIds;
        Name = name;
    }

    public Band(BandDTO bandDto, List<int> muzikantIds, List<int> setlistIds)
    {
        Id = bandDto.Id;
        BandLeiderId = bandDto.BandLeider;
        MuzikantIds = muzikantIds;
        SetlistIds = setlistIds;
        Name = bandDto.Name;
    }

    public Band(BandDTO bandDto, List<Muzikant> muzikanten, List<Setlist> setlists)
    {
        Id = bandDto.Id;
        BandLeiderId = bandDto.BandLeider;
        Muzikanten= muzikanten;
        Setlists = setlists;
        Name = bandDto.Name;
    }

    public Band()
    {

    }

    public int Id { get; set; }
    public int? BandLeiderId { get; set; }
    public Muzikant? BandLeider { get; set; }
    public List<int>? SetlistIds { get; set; }
    public List<Setlist>? Setlists { get; set; }
    public List<int>? MuzikantIds { get; set; }
    public List<Muzikant>? Muzikanten { get; set; }
    public string Name { get; set; }
}