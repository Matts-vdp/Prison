using Prison.Models.Entities;

namespace Prison.Contracts.Dtos;

public class PrisonerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsMale { get; set; }
    public string PType { get; set; }
    public DateTime WhenFree { get; set; }
    public bool EarlyRelease { get; set; }
    public DateTime LastVisited { get; set; }

    public PrisonerDto(Guid id, string name, string pType, bool isMale, DateTime whenFree, bool earlyRelease, DateTime lastVisited)
    {
        Id = id;
        Name = name;
        PType = pType;
        IsMale = isMale;
        WhenFree = whenFree;
        EarlyRelease = earlyRelease;
        LastVisited = lastVisited;
    }
    
    public static PrisonerDto FromPrisoner(Prisoner prisoner)
    {
        return new PrisonerDto(
            prisoner.Id,
            prisoner.Name,
            prisoner.PType,
            prisoner.IsMale,
            prisoner.WhenFree, 
            prisoner.EarlyRelease, 
            prisoner.LastVisited
            );
    }

    public static IEnumerable<PrisonerDto> FromPrisoners(IEnumerable<Prisoner> prisoners)
    {
        return prisoners.Select(prisoner => PrisonerDto.FromPrisoner(prisoner)).ToList();
    }
}