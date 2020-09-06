using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.DTO.DTOs.ReportDTOs
{
    public class ReportAddDto
    {
        public string Definition { get; set; }
        public string Description { get; set; }
        public Task Task { get; set; }
        public int TaskId { get; set; }
    }
}
