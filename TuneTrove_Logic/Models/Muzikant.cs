namespace TuneTrove_Logic.Models;

public class Muzikant
{
    public Muzikant(int id, string name, string instrument, List<int> bandIds, List<int> nummerIds, List<int> setlistIds)
    {
        Id = id;
        Name = name;
        Instrument = instrument;
        BandIds = bandIds;
        NummerIds = nummerIds;
        SetlistIds = setlistIds;
    }

    public Muzikant(MuzikantDTO muzikantDto, List<int> bandIds, List<Nummer> nummerIds, List<Setlist> setlistIds)
    {
        Id = muzikantDto.Id;
        Name = muzikantDto.Name;
        Instrument = muzikantDto.Instrument;
        BandIds = bandIds;
        NummerIds = nummerIds;
        SetlistIds = setlistIds;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Instrument { get; set; }
    public List<int> BandIds { get; set; }
    public List<int> NummerIds { get; set; }
    public List<int> SetlistIds { get; set; }
}