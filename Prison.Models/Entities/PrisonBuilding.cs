using Prison.Models.Base;

namespace Prison.Models.Entities;

public class PrisonBuilding : BaseAuditableEntity
{
    public string Name { get; set; }
    public int Capacity { get; set; }
    public bool IsFull
    {
        get
        {
            int sum = Cells.Sum(cell => cell.Prisoners.Count);
            return Capacity > sum;
        }
    }
    public ICollection<Cell> Cells { get; set; } = new List<Cell>();


    public PrisonBuilding(string name, int capacity)
    {
        Name = name;
        Capacity = capacity;
    }
    
    

    public void Add(Cell cell)
    {
        if (IsFull) throw new Exception("Prison full");
        Cells.Add(cell);
    }

    public void Add(Prisoner prisoner)
    {
        bool added = false;
        foreach (var cell in Cells)
        {
            if (cell.CanAdd(prisoner))
            {
                cell.Add(prisoner);
                break;
            }
        }

        if (!added) throw new Exception("no place in prison");
    }
}