using System;

namespace PocBancoAPI.DTOs
{
    public class BaseDTO 
    {
        public int IdUser { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
