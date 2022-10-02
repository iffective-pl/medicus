using MedicusApp.Models;
using MedicusApp.Models.Data.Desc;
using MedicusApp.Models.Dto.Desc;
using Microsoft.EntityFrameworkCore;

namespace MedicusApp.Repositories.Impl
{
    public class DescRepository : IDescRepository
    {
        private readonly DatabaseContext context;

        public DescRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public bool AddDesc(DescriptionDto description)
        {
            try
            {
                if(description.SpecId.HasValue)
                {
                    var sp = context.Specs.Where(s => s.Id == description.SpecId).Include(s => s.Descriptions).Single();
                    var desc = new Description()
                    {
                        Image = description.Image
                    };
                    sp.Descriptions.Add(desc);
                } else if(description.StaticId.HasValue)
                {
                    var st = context.Statics.Where(s => s.Id == description.StaticId).Include(s => s.Descriptions).Single();
                    var desc = new Description()
                    {
                        Image = description.Image
                    };
                    st.Descriptions.Add(desc);
                } else
                {
                    return false;
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateDesc(DescriptionDto description)
        {
            try
            {
                var desc = context.Descriptions.Where(d => d.Id == description.Id).Include(d => d.DescriptionTexts).Single();
                desc.Image = description.Image;

                var toBeDeleted = desc.DescriptionTexts.Where(dt => !description.DescriptionTexts.Select(dt2 => dt2.Id).Contains(dt.Id)).Select(dt => dt.Id).ToList();

                foreach (var item in toBeDeleted)
                {
                    desc.DescriptionTexts.Remove(desc.DescriptionTexts.Where(dt => dt.Id == item).Single());
                }

                foreach (var item in description.DescriptionTexts.Where(dt => dt.Id != 0))
                {
                    var dt = desc.DescriptionTexts.Where(q => q.Id == item.Id).Single();
                    dt.Title = item.Title;
                    dt.Text = item.Text;
                }

                desc.DescriptionTexts.AddRange(description.DescriptionTexts
                    .Where(dt => dt.Id == 0)
                    .Select(dt => new DescriptionText()
                    {
                        Id = dt.Id,
                        Title = dt.Title,
                        Text = dt.Text
                    }));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteDesc(int descId)
        {
            try
            {
                var desc = context.Descriptions.Where(d => d.Id == descId).Single();
                desc.Deleted = DateTime.UtcNow;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
