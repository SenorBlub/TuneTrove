﻿using TuneTrove_Logic.DTO;
using TuneTrove_Logic.Models;

namespace TuneTrove_Logic.DAL_Interfaces;

public interface IBandRepository
{
    List<BandDTO> GetAllBands();
    BandDTO GetBandById(int id);
    void PostBand(BandDTO band);
    void RemoveBand(int id);
    void EditBand(BandDTO band);
    List<int> GetSetlistIds(int id);
}