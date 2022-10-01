using MedicusApp.Models;
using MedicusApp.Models.Data.UI;
using MedicusApp.Models.Dto.Desc;
using MedicusApp.Models.Dto.UI;

namespace MedicusApp.Repositories.Impl
{
    public class StaticRepository : IStaticRepository
    {
        private readonly DatabaseContext context;

        public StaticRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public bool AddStatic(StaticDto staticDto)
        {
            try
            {
                context.Statics.Add(new Static()
                {
                    Name = staticDto.Name,
                    HasMap = staticDto.HasMap,
                });
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteStatic(int staticId)
        {
            try
            {
                var s = context.Statics.Single(s => s.Id == staticId);
                s.Deleted = DateTime.UtcNow;
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public StaticDto GetStatic(int staticId)
        {
            return context.Statics.Where(s => s.Id == staticId && s.Deleted == null).Select(s => new StaticDto()
            {
                Id = s.Id,
                Name = s.Name,
                HasMap = s.HasMap,
                Created = s.Created,
                Deleted = s.Deleted,
                Descriptions = s.Descriptions.Select(d => new DescriptionDto()
                {
                    Id = d.Id,
                    Image = d.Image,
                    DescriptionTexts = d.DescriptionTexts.Select(dt => new DescriptionTextDto()
                    {
                        Id = dt.Id,
                        Title = dt.Title,
                        Text = dt.Text
                    })
                })
            }).Single();
        }

        public IEnumerable<StaticDto> GetStaticDropdown()
        {
            return context.Statics.Where(s => s.Deleted == null).Select(s => new StaticDto()
            {
                Id = s.Id,
                Name = s.Name
            });
        }

        public IEnumerable<int> GetStaticIds()
        {
            return context.Statics.Where(s => s.Deleted == null).Select(s => s.Id);
        }

        public bool UpdateStatic(StaticDto staticDto)
        {
            try
            {
                var s = context.Statics.Single(s => s.Id == staticDto.Id);
                s.Name = staticDto.Name;
                s.HasMap = staticDto.HasMap;
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return true;
            }
        }
    }
}
