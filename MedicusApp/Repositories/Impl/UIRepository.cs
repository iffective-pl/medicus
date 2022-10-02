using MedicusApp.Migrations;
using MedicusApp.Models;
using MedicusApp.Models.Data.UI;
using MedicusApp.Models.Dto;
using MedicusApp.Models.Dto.UI;
using MedicusApp.Models.Links;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace MedicusApp.Repositories.Impl
{
    public class UIRepository : IUIRepository
    {
        private readonly DatabaseContext context;

        public UIRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public HeaderDto GetHeader(int headerId)
        {
            return context.Headers.Where(q => q.Id == headerId && q.Deleted == null)
                .Include(h => h.Links).ThenInclude(l => l.Spec)
                .Select(h => new HeaderDto()
                {
                    Id = h.Id,
                    Name = h.Name,
                    Href = h.Href,
                    IsIndex = h.IsIndex,
                    IsHidden = h.IsHidden,
                    IsDropdown = h.IsDropdown,
                    IsPredefined = h.IsPredefined,
                    Created = h.Created,
                    Deleted = h.Deleted,
                    Order = h.Order,
                    Links = h.Links.OrderBy(l => l.Order).Select(l => new LinkDto()
                    {
                        Id = l.Id,
                        Href = l.Href,
                        Created = l.Created,
                        Deleted = l.Deleted,
                        Order = l.Order,
                        Spec = new SpecDto()
                        {
                            Id = l.Spec.Id,
                            Name = l.Spec.Name
                        }
                    })
                }).Single();
        }

        public IEnumerable<HeaderDto> GetHeaders()
        {
            return context.Headers.Where(h => h.Deleted == null).OrderBy(h => h.Order)
                .Include(h => h.Links).ThenInclude(o => o.Spec)
                .Select(h => new HeaderDto()
                {
                    Id = h.Id,
                    Name = h.Name,
                    Href = h.Href,
                    IsIndex = h.IsIndex,
                    IsHidden = h.IsHidden,
                    IsDropdown = h.IsDropdown,
                    IsPredefined = h.IsPredefined,
                    Created = h.Created,
                    Deleted = h.Deleted,
                    Order = h.Order,
                    Links = h.Links.OrderBy(l => l.Order).Where(o => o.Deleted == null).Select(o => new LinkDto()
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
            return context.Links.OrderBy(l => l.Order).Where(l => l.Deleted == null).Select(l => new LinkDto()
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

        public bool MoveLink(int linkId, DestinationDto destination)
        {
            try
            {
                var link = context.Links.Where(l => l.Deleted == null).Include(l => l.Header).Single(l => l.Id == linkId);
                var header = context.Headers.SingleOrDefault(h => h.Id == destination.DroppableId);
                var oldHeader = link.Header != null ? link.Header.Id : 0;
                var isNull = link.Header == null;
                link.Header = header;
                ReOrderLinks(oldHeader, isNull);
                return OrderLink(linkId, destination);
            } catch (Exception)
            {
                return false;
            }
        }

        private void ReOrderLinks(int headerId, bool isNull = false)
        {
            List<Link> links;
            if(isNull)
            {
                links = context.Links.Where(l => l.Header == null).OrderBy(l => l.Order).ToList();
            } else
            {
                links = context.Links.Where(l => l.Header != null && l.Header.Id == headerId).OrderBy(l => l.Order).ToList();
            }
            ReAssignLinksOrder(links);
        }

        private void ReAssignLinksOrder(List<Link> links)
        {
            for (int i = 0; i < links.Count(); i++)
            {
                links[i].Order = i;
            }
        }

        public bool OrderLink(int linkId, DestinationDto destination)
        {
            try
            {
                var link = context.Links.Where(l => l.Id == linkId).Include(l => l.Header).Single();
                IOrderedQueryable<Link> links;
                if (link.Header == null)
                {
                    links = context.Links.Include(l => l.Header).Where(l => l.Header == null && l.Id != link.Id).OrderBy(l => l.Order);
                   
                } else
                {
                    links = context.Links.Include(l => l.Header).Where(l => l.Header != null && l.Header.Id == link.Header.Id && l.Id != link.Id).OrderBy(l => l.Order);
                }
                var total = new List<Link>();
                if (destination.Index == null)
                {
                    total.AddRange(links);
                    total.Add(link);
                } else
                {
                    var begining = links.Take(destination.Index.Value).ToList();
                    var ending = links.OrderByDescending(l => l.Order).Take(links.Count() - begining.Count()).OrderBy(l => l.Order).ToList();
                    total.AddRange(begining);
                    total.Add(link);
                    total.AddRange(ending);
                }
                ReAssignLinksOrder(total);
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        private void ReAssignHeadersOrder(List<Header> headers)
        {
            for (int i = 0; i < headers.Count(); i++)
            {
                headers[i].Order = i;
            }
        }

        public bool OrderHeader(int headerId, DestinationDto destination)
        {
            try
            {
                var header = context.Headers.Single(h => h.Id == headerId);
                var headers = context.Headers.Where(h => h.Deleted == null && h.Id != headerId).OrderBy(h => h.Order);
                var begining = headers.Take(destination.Index.Value).ToList();
                var ending = headers.OrderByDescending(h => h.Order).Take(headers.Count() - begining.Count()).OrderBy(h => h.Order).ToList();
                List<Header> output = new List<Header>();
                output.AddRange(begining);
                output.Add(header);
                output.AddRange(ending);
                ReAssignHeadersOrder(output);
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public bool AddHeader(HeaderDto header)
        {
            try
            {
                if (header.IsDropdown)
                {
                    header.Href = string.Empty;
                } else if (string.IsNullOrEmpty(header.Href))
                {
                    return false;
                }

                var headers = context.Headers.Where(h => h.Deleted == null).OrderBy(h => h.Order).ToList();
                
                var h = new Header()
                {
                    Name = header.Name,
                    Href = header.Href,
                    IsDropdown = header.IsDropdown,
                    IsHidden = header.IsHidden
                };

                context.Headers.Add(h);
                context.SaveChanges();
                headers.Add(h);
                ReAssignHeadersOrder(headers);
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateHeader(HeaderDto header)
        {
            try
            {
                if (header.IsDropdown)
                {
                    header.Href = string.Empty;
                }
                else if (string.IsNullOrEmpty(header.Href))
                {
                    return false;
                }

                var h = context.Headers.Where(h => h.Id == header.Id && h.Deleted == null).Single();
                h.Name = header.Name;
                h.Href = header.Href;
                h.IsDropdown = header.IsDropdown;
                h.IsHidden = header.IsHidden;
                var headers = context.Headers.Where(h => h.Deleted == null).OrderBy(h => h.Order).ToList();
                ReAssignHeadersOrder(headers);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteHeader(int headerId)
        {
            try
            {
                var header = context.Headers.Where(h => h.Deleted == null).Include(h => h.Links).Single(h => h.Id == headerId);
                header.Deleted = DateTime.UtcNow;
                foreach (var l in header.Links)
                {
                    l.Header = null;
                }
                var headers = context.Headers.Where(h => h.Deleted == null).OrderBy(h => h.Order).ToList();
                ReAssignHeadersOrder(headers);
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<HeaderDto> GetHeaderDropdown()
        {
            return context.Headers.Where(h => h.Deleted == null).Select(h => new HeaderDto()
            {
                Name = h.Name,
                Href = h.Href
            });
        }

        public IEnumerable<LinkDto> GetLinkDropdown()
        {
            return context.Links.Where(l => l.Deleted == null).Include(l => l.Spec).Select(l => new LinkDto()
            {
                Href = l.Href,
                Spec = new SpecDto()
                {
                    Name = l.Spec.Name
                }
            });
        }
    }
}
