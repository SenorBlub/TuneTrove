namespace TuneTrove_Logic.DAL_Interfaces;

public interface IMuzikantNummerRepository
{
    List<int> GetNummers(int muzikantId);
    List<int> GetMuzikanten(int nummerId);
    void PostConnection(int muzikantId, int nummerId);
    void RemoveConnection(int muzikantId, int nummerId);
}