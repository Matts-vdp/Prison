using Prison.Models.Base;

namespace Prison.Models.Entities;

public class PrisonBuilding : BaseAuditableEntity
{
    public string Name { get; set; }
    public int Capacity { get; set; }
    public ICollection<Cell> Cells { get; set; } = new List<Cell>();


    public PrisonBuilding(string name, int capacity)
    {
        Name = name;
        Capacity = capacity;
    }
}