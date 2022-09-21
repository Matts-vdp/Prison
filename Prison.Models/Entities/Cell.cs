using Prison.Models.Base;

namespace Prison.Models.Entities;

public class Cell : BaseAuditableEntity
{
    public int Capacity { get; set; }
    public bool IsIsolation { get; set; }
    public ICollection<Prisoner> Prisoners { get; set; } = new List<Prisoner>();
    public PrisonBuilding PrisonBuilding { get; set; }
    public Cell(int capacity, bool isIsolation = false)
    {
        this.Capacity = capacity;
        this.IsIsolation = isIsolation;
        if (isIsolation)
            this.Capacity = 1;
    }
}