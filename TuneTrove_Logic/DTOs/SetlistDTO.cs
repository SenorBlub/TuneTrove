using TuneTrove_Logic.Models;

namespace TuneTrove_Logic.DTOs;

public class SetlistDTO
{
    public int Id { get; private set; }
    public DateTime Date { get; private set; }
    public List<MuzikantDTO>? Muzikanten { get; private set; }
    public List<NummerDTO>? Nummers { get; private set; }
    public List<BandDTO>? Bands { get; private set; }

    public SetlistDTO(int id, DateTime date, List<MuzikantDTO>? muzikanten, List<NummerDTO>? nummers, List<BandDTO>? bands)
    {
        Id = id;
        Date = date;
        Muzikanten = muzikanten;
        Nummers = nummers;
        Bands = bands;
    }

    public SetlistDTO(int id, DateTime date)
    {
        Id = id;
        Date = date;
    }
}