﻿namespace TuneTrove_Logic.Models;

public class MuzikantDTO
{
    public MuzikantDTO(int id, string name, string instrument, List<Band> bands, List<Nummer> nummers, List<Setlist> setlists)
    {
        Id = id;
        Name = name;
        Instrument = instrument;
        Bands = bands;
        Nummers = nummers;
        Setlists = setlists;
    }

    public MuzikantDTO(Muzikant muzikant)
    {
        Id = muzikant.Id;
        Name = muzikant.Name;
        Instrument = muzikant.Instrument;
        Bands = muzikant.Bands;
        Nummers = muzikant.Nummers;
        Setlists = muzikant.Setlists;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Instrument { get; set; }
    public List<Band> Bands { get; set; }
    public List<Nummer> Nummers { get; set; }
    public List<Setlist> Setlists { get; set; }
}