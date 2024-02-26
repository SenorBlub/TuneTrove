namespace TuneTrove_Logic.DAL_Interfaces;

public interface INummerSetlistRepository
{
    List<int> GetSetlists(int nummerId);
    List<int> GetNummers(int setlistId);
    void PostConnection(int nummerId, int setlistId);
    void RemoveConnection(int nummerId, int setlistId);
}