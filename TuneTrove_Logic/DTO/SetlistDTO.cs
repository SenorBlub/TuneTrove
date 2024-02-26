namespace TuneTrove_Logic.Models;

public class SetlistDTO
{
    public SetlistDTO(int id, DateTime? datum)
    {
        Id = id;
        Datum = datum;
    }

    public SetlistDTO(Setlist setlist)
    {
        Id = setlist.Id;
        Datum = setlist.Datum;
    }
    public int Id { get; set; }
    public DateTime? Datum { get; set; }
}