﻿namespace TuneTrove_Logic.Models;

public class Setlist
{
    public Setlist(int id, DateTime? datum, List<int> muzikantIds, List<int> nummerIds, List<int> bandIds)
    {
        Id = id;
        Datum = datum;
        MuzikantIds = muzikantIds;
        NummerIds = nummerIds;
        BandIds = bandIds;
    }

    public Setlist(SetlistDTO setlistDto, List<int> muzikantIds, List<int> nummerIds, List<int> bandIds)
    {
        Id = setlistDto.Id;
        Datum = setlistDto.Datum;
        MuzikantIds = muzikantIds;
        NummerIds = nummerIds;
        BandIds = bandIds;
    }
    public int Id { get; set; }
    public DateTime? Datum { get; set; }
    public List<int> MuzikantIds { get; set; }
    public List<int> NummerIds { get; set; }
    public List<int> BandIds { get; set; }
}