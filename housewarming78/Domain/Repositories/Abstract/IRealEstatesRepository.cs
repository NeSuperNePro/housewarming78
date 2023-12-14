using housewarming78.Domain.Entities;

namespace housewarming78.Domain.Repositories.Abstract
{
    public interface IRealEstatesRepository
    {
        IQueryable<RealEstate> GetRealEstate();
        RealEstate GetRealEstateById(Guid id);
        void SaveRealEstate(RealEstate entity);
        void DeleteRealEstate(Guid id);
    }
}
