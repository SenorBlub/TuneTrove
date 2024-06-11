using TuneTrove_Logic.DTO;

namespace TuneTrove_Logic.Models;

public class Nummer
{
    public Nummer(int id, string name, int length, string artiest, List<int> setlistIds)
    {
        Id = id;
        Name = name;
        Length = length;
        Artiest = artiest;
        SetlistIds = setlistIds;
    }

    public Nummer(NummerDTO nummerDto, List<int> setlistIds)
    {
        Id = nummerDto.Id;
        Name = nummerDto.Name;
        Length = nummerDto.Length;
        Artiest = nummerDto.Artiest;
        SetlistIds = setlistIds;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public int Length { get; set; } // length is expressed in seconds
    public string Artiest { get; set; }
    public List<int>? SetlistIds { get; set; }
    public List<Setlist>? Setlists { get; set; }
}