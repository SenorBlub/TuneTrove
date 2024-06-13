using TuneTrove_Logic.DTOs;
using TuneTrove_Logic.Models;

namespace TuneTrove_Logic.IServices;

public interface IMuzikantService
{
    public void AddMuzikant(MuzikantDTO muzikant);
    public void RemoveMuzikant(int id);
    public void RemoveMuzikant(Muzikant muzikant);
    public void RemoveMuzikant(MuzikantDTO muzikant);
    public void UpdateMuzikant(Muzikant muzikant);
    public void UpdateMuzikant(MuzikantDTO muzikant);
    public MuzikantDTO GetMuzikant(int id);
    public List<MuzikantDTO> GetAllMuzikanten();
    public List<MuzikantDTO> GetMuzikantPage(int pageSize, int pageNum);
}