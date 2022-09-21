using Prison.Models.Entities;

namespace Prison.Contracts.Dtos;

public class PrisonBuildingDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public int Capacity { get; set; }

    public PrisonBuildingDto(Guid id, string name, int capacity)
    {
        Id = id;
        Name = name;
        Capacity = capacity;
    }
    
    public static PrisonBuildingDto FromPrisonBuilding(PrisonBuilding prison)
    {
        return new PrisonBuildingDto(prison.Id, prison.Name, prison.Capacity);
    }

    public static IEnumerable<PrisonBuildingDto> FromPrisonBuildings(IEnumerable<PrisonBuilding> prisons)
    {
        return prisons.Select(prison => new PrisonBuildingDto(prison.Id, prison.Name, prison.Capacity)).ToList();
    }
}