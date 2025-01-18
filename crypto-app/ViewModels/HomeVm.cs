using crypto_app.Models;

namespace crypto_app.ViewModels;

public class HomeVm
{
    public ICollection<Agent> Agents { get; set; }
    public ICollection<Position> Positions { get; set; }
}
