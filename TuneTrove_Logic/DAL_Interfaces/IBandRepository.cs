﻿using TuneTrove_Logic.DTO;

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