namespace TuneTrove_Logic.Models;

public class NummerDTO
{
    public NummerDTO(int id, string name, int length, string artiest)
    {
        Id = id;
        Name = name;
        Length = length;
        Artiest = artiest;
    }

    public NummerDTO(Nummer nummer)
    {
        Id = nummer.Id;
        Name = nummer.Name;
        Length = nummer.Length;
        Artiest = nummer.Artiest;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public int Length { get; set; } // length is expressed in seconds
    public string Artiest { get; set; }
}