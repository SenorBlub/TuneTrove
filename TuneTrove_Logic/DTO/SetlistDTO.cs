using TuneTrove_Logic.Models;

namespace TuneTrove_Logic.DTO;

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