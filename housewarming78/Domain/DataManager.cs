using housewarming78.Domain.Repositories.Abstract;

namespace housewarming78.Domain
{
    public class DataManager
    {

        public IRealEstatesRepository RealEstates { get; set; }
        //public IImagesRepository Images { get; set; }


        public DataManager( IRealEstatesRepository realEstatesRepository) 
        { 

            RealEstates = realEstatesRepository;
            //Images = imagesRepository;
        }
    }
}
