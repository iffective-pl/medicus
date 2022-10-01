using MedicusApp.Models.Control;
using MedicusApp.Models.Data.UI;

namespace MedicusApp.Models.Data.Desc
{
    public class Description : Sort
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public List<DescriptionText> DescriptionTexts { get; set; }

        public Spec? Spec { get; set; }
        public Static? Static { get; set; }
    }
}
