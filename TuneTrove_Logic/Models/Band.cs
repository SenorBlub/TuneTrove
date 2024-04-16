using TuneTrove_Logic.DTO;

namespace TuneTrove_Logic.Models;

public class Band
{
    public Band(int id, string name, int bandLeider, List<int> setlistIds, List<int> muzikantIds)
    {
        Id = id;
        BandLeider = bandLeider;
        SetlistIds = setlistIds;
        MuzikantIds = muzikantIds;
        Name = name;
    }

    public Band(BandDTO bandDto, List<int> muzikantIds, List<int> setlistIds)
    {
        Id = bandDto.Id;
        BandLeider = bandDto.BandLeider;
        MuzikantIds = muzikantIds;
        SetlistIds = setlistIds;
        Name = bandDto.Name;
    }

    public Band()
    {

    }

    public int Id { get; set; }
    public int BandLeider { get; set; }
    public List<int> SetlistIds { get; set; }
    public List<int> MuzikantIds { get; set; }
    public string Name { get; set; }
}