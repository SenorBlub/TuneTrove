using TuneTrove_Logic.Models;

namespace TuneTrove_Logic.IRepositories;

public interface IMuzikantRepository
{
    public List<Muzikant> GetAllMuzikants();
    public List<Muzikant> GetMuzikantPage(int pageNum, int pageSize);
    public Muzikant GetMuzikant(int id);
    public List<Muzikant> GetMuzikantsByBandId(int bandId);
    public List<Muzikant> GetMuzikantsBySetlistId(int setlistId);
    public void UpdateMuzikant(Muzikant newMuzikant, int muzikantId);
    public void DeleteMuzikant(int muzikantId);
    public void AddMuzikant(Muzikant newMuzikant);
}