﻿using System.ComponentModel.DataAnnotations;

namespace Emulator_WYD.Model.Database
{
    public record class ModelBase
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public DateTimeOffset CreatedIn { get; set; }

        [Required]
        public int CreatedBy { get; set; }

        [Required]
        public DateTimeOffset UpdatedIn { get; set; }

        [Required]
        public int UpdatedBy { get; set; }
    }
}
