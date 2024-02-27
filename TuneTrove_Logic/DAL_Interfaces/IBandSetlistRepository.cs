namespace TuneTrove_Logic.DAL_Interfaces;

public interface IBandSetlistRepository
{
    List<int> GetBands(int setlistId);
    List<int> GetSetlists(int bandId);
    void PostConnection(int setlistId, int bandId);
    void RemoveConnection(int setlistId, int bandId);
}