namespace TuneTrove_Logic.Models;

public class Muzikant
{
    public Muzikant(int id, string name, string instrument, List<Band> bands, List<Nummer> nummers, List<Setlist> setlists)
    {
        Id = id;
        Name = name;
        Instrument = instrument;
        Bands = bands;
        Nummers = nummers;
        Setlists = setlists;
    }

    public Muzikant(MuzikantDTO muzikantDto)
    {
        Id = muzikantDto.Id;
        Name = muzikantDto.Name;
        Instrument = muzikantDto.Instrument;
        Bands = muzikantDto.Bands;
        Nummers = muzikantDto.Nummers;
        Setlists = muzikantDto.Setlists;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Instrument { get; set; }
    public List<Band> Bands { get; set; }
    public List<Nummer> Nummers { get; set; }
    public List<Setlist> Setlists { get; set; }
}