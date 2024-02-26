namespace TuneTrove_Logic.Models;

public class Setlist
{
    public Setlist(int id, DateTime? datum, List<Muzikant> muzikanten, List<Nummer> nummers, List<Band> bands)
    {
        Id = id;
        Datum = datum;
        Muzikanten = muzikanten;
        Nummers = nummers;
        Bands = bands;
    }

    public Setlist(SetlistDTO setlistDto)
    {
        Id = setlistDto.Id;
        Datum = setlistDto.Datum;
        Muzikanten = setlistDto.Muzikanten;
        Nummers = setlistDto.Nummers;
        Bands = setlistDto.Bands;
    }
    public int Id { get; set; }
    public DateTime? Datum { get; set; }
    public List<Muzikant> Muzikanten { get; set; }
    public List<Nummer> Nummers { get; set; }
    public List<Band> Bands { get; set; }
}