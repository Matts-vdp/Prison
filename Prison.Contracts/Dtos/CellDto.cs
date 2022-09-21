using Prison.Models.Entities;

namespace Prison.Contracts.Dtos;

public class CellDto
{
    public Guid Id { get; set; }
    public int capacity { get; set; }
    public bool IsIsolation { get; set; }

    public CellDto(Guid id, int capacity, bool isIsolation)
    {
        Id = id;
        this.capacity = capacity;
        IsIsolation = isIsolation;
    }

    public static CellDto FromCell(Cell cell)
    {
        return new CellDto(cell.Id, cell.Capacity, cell.IsIsolation);
    }

    public static IEnumerable<CellDto> FromCells(IEnumerable<Cell> cells)
    {
        return cells.Select(cell => CellDto.FromCell(cell)).ToList();
    }
}