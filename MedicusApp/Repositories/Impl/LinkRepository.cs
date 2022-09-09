using MedicusApp.Model.Dto;
using MedicusApp.Model.Links;
using MedicusApp.Models;

namespace MedicusApp.Repositories.Impl
{
    public class LinkRepository : ILinkRepository
    {
        private readonly DatabaseContext context;

        public LinkRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public IEnumerable<LinkDto> GetLinks()
        {
            return context.Links.Select(l => new LinkDto()
            {
                Id = l.Id,
                Name = l.Name,
                Href = l.Href,
                IsIndex = l.IsIndex,
                Options = l.Options.Select(o => new OptionDto()
                {
                    Id = o.Id,
                    Href = o.Href,
                    Name = o.Name
                })
            });
        }
    }
}
