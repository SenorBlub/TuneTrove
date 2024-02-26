namespace TuneTrove_Logic.Models;

public class SetlistDTO
{
    public SetlistDTO(int id, DateTime? datum, List<Muzikant> muzikanten, List<Nummer> nummers, List<Band> bands)
    {
        Id = id;
        Datum = datum;
        Muzikanten = muzikanten;
        Nummers = nummers;
        Bands = bands;
    }

    public SetlistDTO(Setlist setlist)
    {
        Id = setlist.Id;
        Datum = setlist.Datum;
        Muzikanten = setlist.Muzikanten;
        Nummers = setlist.Nummers;
        Bands = setlist.Bands;
    }
    public int Id { get; set; }
    public DateTime? Datum { get; set; }
    public List<Muzikant> Muzikanten { get; set; }
    public List<Nummer> Nummers { get; set; }
    public List<Band> Bands { get; set; }
}