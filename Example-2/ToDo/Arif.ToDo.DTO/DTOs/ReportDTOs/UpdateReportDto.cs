using System;
using System.Collections.Generic;
using System.Text;

namespace Arif.ToDo.DTO.DTOs.ReportDTOs
{
    public class UpdateReportDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public string Description { get; set; }
        //public Task Task { get; set; }
    }
}
