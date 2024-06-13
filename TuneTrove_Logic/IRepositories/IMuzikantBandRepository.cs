namespace TuneTrove_Logic.IRepositories;

public interface IMuzikantBandRepository
{
    public void ConnectMuzikantToBand(int muzikantId, int bandId);
    public void ConnectMuzikantenToBand(List<int> muzikantIds, int bandId);
    public void ConnectMuzikantToBands(int muzikantId, List<int> bandIds);
    public void DisconnectMuzikantFromBand(int muzikantId, int bandId);
    public void DisconnectMuzikantenFromBand(List<int> muzikantIds, int bandId);
    public void DisconnectMuzikantFromBands(int muzikantId, List<int> bandIds);
    public void DisconnectAllFromMuzikant(int muzikantId);
    public void DisconnectFromAllMuzikanten(int bandId);
}