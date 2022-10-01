using MedicusApp.Models;
using MedicusApp.Models.Data.Main;
using MedicusApp.Models.Dto.Main;

namespace MedicusApp.Repositories.Impl
{
    public class MPRepository : IMPRepository
    {
        private readonly DatabaseContext context;

        public MPRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public MainPageDto GetMainPage()
        {
            return context.MainPages.Select(mp => new MainPageDto() { 
                Id = mp.Id,
                Advantages = mp.Advantages.Select(a => new AdvantageDto() { 
                    Id = a.Id,
                    Name = a.Name,
                    Icon = a.Icon,
                    Href = a.Href
                })
            }).Single();
        }

        public bool UpdateAdvantage(AdvantageDto advantage)
        {
            try
            {
                var a = context.Advantages.Single(a => a.Id == advantage.Id);
                a.Name = advantage.Name;
                a.Href = advantage.Href;
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }
    }
}
