using System.ComponentModel.DataAnnotations.Schema;

namespace MedicusApp.Models.Control
{
    public class Sort : Delete
    {
        public int Order { get; set; }
    }
}
