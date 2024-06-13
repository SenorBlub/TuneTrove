using TuneTrove_Logic.DTOs;
using TuneTrove_Logic.Models;

namespace TuneTrove_Logic.IServices;

public interface ISetlistService
{
    public void AddSetlist(SetlistDTO setlist);
    public void RemoveSetlist(int id);
    public void RemoveSetlist(Setlist setlist);
    public void RemoveSetlist(SetlistDTO setlist);
    public void UpdateSetlist(Setlist setlist);
    public void UpdatSetlist(SetlistDTO setlist);
    public SetlistDTO GetSetlist(int id);
    public List<SetlistDTO> GetAllSetlists();
    public List<SetlistDTO> GetSetlistPage(int pageSize, int pageNum);
}