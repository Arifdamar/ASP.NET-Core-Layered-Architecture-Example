﻿using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.DTO.DTOs.ReportDTOs
{
    public class ReportUpdateDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public string Description { get; set; }
        public Task Task { get; set; }
    }
}
