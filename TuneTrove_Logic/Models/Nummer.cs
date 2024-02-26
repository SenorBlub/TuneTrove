namespace TuneTrove_Logic.Models;

public class Nummer
{
    public Nummer(int id, string name, int length, string artiest, List<Setlist> setlists)
    {
        Id = id;
        Name = name;
        Length = length;
        Artiest = artiest;
        Setlists = setlists;
    }

    public Nummer(NummerDTO nummerDto)
    {
        Id = nummerDto.Id;
        Name = nummerDto.Name;
        Length = nummerDto.Length;
        Artiest = nummerDto.Artiest;
        Setlists = nummerDto.Setlists;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public int Length { get; set; } // length is expressed in seconds
    public string Artiest { get; set; }
    public List<Setlist> Setlists { get; set; }
}