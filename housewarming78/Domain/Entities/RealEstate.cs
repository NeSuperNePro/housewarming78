using System.ComponentModel.DataAnnotations;

namespace housewarming78.Domain.Entities
{
    public class RealEstate : RealEstateBase
    {

        [Display(Name = "Название услуги")]
        public override string? Title { get; set; }

        [Display(Name = "Полное описание услуги")]
        public override string? Text { get; set; }

    }
}
