using TuneTrove_Logic.Models;

namespace TuneTrove_Logic.IRepositories;

public interface ISetlistRepository
{
    public List<Setlist> GetAllSetlists();
    public List<Setlist> GetSetlistPage(int pageNum, int pageSize);
    public Setlist GetSetlist(int id);
    public List<Setlist> GetSetlistsByBandId(int bandId);
    public List<Setlist> GetSetlistsByMuzikantId(int muzikantId);
    public List<Setlist> GetSetlistsByNummerId(int nummerId);
    public void UpdateSetlist(Setlist newSetlist, int setlistId);
    public void DeleteSetlist(int id);
    public void AddSetlist(Setlist newSetlist);
}