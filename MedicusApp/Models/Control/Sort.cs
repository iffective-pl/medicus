using System.ComponentModel.DataAnnotations.Schema;

namespace MedicusApp.Models.Control
{
    public class Sort : Delete
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Order { get; set; }
    }
}
