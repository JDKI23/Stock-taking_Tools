using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace Stock_taking_Tools.Models
{
    public class Tool 
    {
        public int Id { get; set; }

        [Required]
        public string ToolName { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }
    }
}
