using housewarming78.Domain.Entities;
using housewarming78.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace housewarming78.Domain.Repositories.EntityFramework
{
    public class EFRealEstatesRepository : IRealEstatesRepository
    {
        private readonly AppDbContext context;

        public EFRealEstatesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<RealEstate> GetRealEstate()
        {
            return context.realEstates;
        }

        public RealEstate GetRealEstateById(Guid id)
        {
            return context.realEstates.FirstOrDefault(x => x.Id == id);
        }

        public void SaveRealEstate(RealEstate entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteRealEstate(Guid id)
        {
            context.realEstates.Remove(new RealEstate { Id = id });
            context.SaveChanges();
        }
    }
}
