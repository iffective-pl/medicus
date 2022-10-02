using MedicusApp.Models;
using MedicusApp.Models.Data.Desc;
using MedicusApp.Models.Data.Main;
using MedicusApp.Models.Dto.Main;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace MedicusApp.Repositories.Impl
{
    public class MPRepository : IMPRepository
    {
        private readonly DatabaseContext context;

        public MPRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public bool AddCarousel(CarouselDto carousel)
        {
            try
            {
                var mp = context.MainPages.Include(mp => mp.Carousels).Single();
                var c = new Carousel()
                {
                    Source = carousel.Source,
                    MainTitle = carousel.MainTitle,
                    SubTitle = carousel.SubTitle,
                    Text = carousel.Text,
                    ButtonHref = carousel.ButtonHref,
                    ButtonText = carousel.ButtonText
                };
                mp.Carousels.Add(c);
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateCarousel(CarouselDto carousel)
        {
            try
            {
                var c = context.Carousels.Single(c => c.Id == carousel.Id && c.Deleted == null);
                c.Source = carousel.Source;
                c.MainTitle = carousel.MainTitle;
                c.SubTitle = carousel.SubTitle;
                c.Text = carousel.Text;
                c.ButtonHref = carousel.ButtonHref;
                c.ButtonText = carousel.ButtonText;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCarousel(int carouselId)
        {
            try
            {
                var c = context.Carousels.Single(c => c.Id == carouselId && c.Deleted == null);
                c.Deleted = DateTime.UtcNow;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public MainPageDto GetMainPage()
        {
            return context.MainPages.Select(mp => new MainPageDto() { 
                Id = mp.Id,
                Carousels = mp.Carousels.Select(c => new CarouselDto()
                {
                    Id = c.Id,
                    Source = c.Source,
                    MainTitle = c.MainTitle,
                    SubTitle = c.SubTitle,
                    Text = c.Text,
                    ButtonHref = c.ButtonHref,
                    ButtonText = c.ButtonText
                }),
                Services = mp.Services.Select(s => new ServiceDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    Href = s.Href,
                    Source = s.Source
                }),
                Advantages = mp.Advantages.Select(a => new AdvantageDto() { 
                    Id = a.Id,
                    Name = a.Name,
                    Icon = a.Icon,
                    Href = a.Href
                })
            }).Single();
        }

        public bool AddService(ServiceDto service)
        {
            try
            {
                var mp = context.MainPages.Include(mp => mp.Services).Single();
                var s = new Service()
                {
                    Name = service.Name,
                    Description = service.Description,
                    Href = service.Href,
                    Source = service.Source,
                };
                mp.Services.Add(s);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateService(ServiceDto service)
        {
            try
            {
                var c = context.Services.Single(s => s.Id == service.Id && s.Deleted == null);
                c.Name = service.Name;
                c.Description = service.Description;
                c.Href = service.Href;
                c.Source = service.Source;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteService(int serviceId)
        {
            try
            {
                var s = context.Services.Single(s => s.Id == serviceId && s.Deleted == null);
                s.Deleted = DateTime.UtcNow;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
