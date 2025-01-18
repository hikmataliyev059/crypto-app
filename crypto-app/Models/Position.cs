using crypto_app.Models.Common;

namespace crypto_app.Models;

public class Position : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Agent> Agents { get; set; }
}
