using TuneTrove_Logic.Models;

namespace TuneTrove_Logic.DTOs;

public class NummerDTO
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Length { get; private set; }
    public string Artiest { get; private set; }
    public List<SetlistDTO>? Setlists { get; private set; }

    public NummerDTO(int id, string name, int length, string artiest, List<SetlistDTO>? setlists)
    {
        Id = id;
        Name = name;
        Length = length;
        Artiest = artiest;
        Setlists = setlists;
    }

    public NummerDTO(int id, string name, int length, string artiest)
    {
        Id = id;
        Name = name;
        Length = length;
        Artiest = artiest;
    }

    public NummerDTO(int id, string name, int length, string artiest, List<SetlistDTO> setlists, int notNull)
    {
        Id = id;
        Name = name;
        Length = length;
        Artiest = artiest;
        Setlists = setlists;
    }

    public NummerDTO()
    {
    }
}