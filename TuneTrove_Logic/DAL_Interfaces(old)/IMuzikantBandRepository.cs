namespace TuneTrove_Logic.DAL_Interfaces;

public interface IMuzikantBandRepository
{
    List<int> GetBands(int muzikantId);
    List<int> GetMuzikanten(int bandId);
    void PostConnection(int muzikantId, int bandId);
    void RemoveConnection(int muzikantId, int bandId);
}