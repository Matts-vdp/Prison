using Prison.Models.Base;

namespace Prison.Models.Entities;

public class Prisoner : BaseAuditableEntity
{
    public string Name { get; set; }
    public bool IsMale { get; set; }
    public string PType { get; set; }
    public DateTime WhenFree { get; set; }
    public bool EarlyRelease { get; set; }
    public DateTime LastVisited { get; set; }
    public Cell Cell { get; set; }

    public Prisoner(string name, bool isMale, string pType, DateTime whenFree, bool earlyRelease, DateTime lastVisited)
    {
        Name = name;
        IsMale = isMale;
        PType = pType;
        WhenFree = whenFree;
        EarlyRelease = earlyRelease;
        LastVisited = lastVisited;
    }
    
    public Prisoner(string name, DateTime whenFree, string pType, bool isMale) 
        : this(name, isMale, pType, whenFree, false, DateTime.MinValue)
    {
    }
}