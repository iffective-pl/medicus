using MedicusApp.Models.Dto;
using MedicusApp.Models;
using MedicusApp.Models.Dto.UI;
using Microsoft.EntityFrameworkCore;

namespace MedicusApp.Repositories.Impl
{
    public class UIRepository : IUIRepository
    {
        private readonly DatabaseContext context;

        public UIRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public IEnumerable<HeaderDto> GetHeaders()
        {
            return context.Headers.Where(h => h.Deleted == null).Include(h => h.Options).ThenInclude(o => o.Spec).Select(h => new HeaderDto()
            {
                Id = h.Id,
                Name = h.Name,
                Href = h.Href,
                IsIndex = h.IsIndex,
                IsHidden = h.IsHidden,
                Order = h.Order,
                Options = h.Options.Where(o => o.Deleted == null).Select(o => new LinkDto()
                {
                    Id = o.Id,
                    Href = o.Href,
                    Created = o.Created,
                    Deleted = o.Deleted,
                    Order = o.Order,
                    Spec = new SpecDto()
                    {
                        Id = o.Spec.Id,
                        Name = o.Spec.Name
                    }
                })
            });
        }

        public IEnumerable<LinkDto> GetLinks()
        {
            return context.Links.Where(l => l.Deleted == null).Select(l => new LinkDto()
            {
                Id = l.Id,
                Href = l.Href,
                Created = l.Created,
                Deleted = l.Deleted,
                Order = l.Order,
                Spec = new SpecDto() {
                    Id = l.Spec.Id,
                    Name = l.Spec.Name
                },
                Header = l.Header != null ? new HeaderDto()
                {
                    Id = l.Header.Id,
                } : null
            });
        }
    }
}
