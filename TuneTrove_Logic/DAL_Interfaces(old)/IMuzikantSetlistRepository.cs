namespace TuneTrove_Logic.DAL_Interfaces;

public interface IMuzikantSetlistRepository
{
    List<int> GetSetlists(int muzikantId);
    List<int> GetMuzikanten(int setlistId);
    void PostConnection(int muzikantId, int setlistId);
    void RemoveConnection(int muzikantId, int setlistId);
}