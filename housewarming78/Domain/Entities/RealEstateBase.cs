using System.ComponentModel.DataAnnotations;

namespace housewarming78.Domain.Entities
{
    public abstract class RealEstateBase
    {
        protected RealEstateBase() => DateAdded = DateTime.UtcNow;

        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Название (заголовок)")]
        public virtual string Title { get; set; }

        [Display(Name = "Адресс")]
        public virtual string Address { get; set; }

        [Display(Name = "Цена")]
        public double Price { get; set; }

        [Display(Name = "Титульная картинка")]
        public virtual string? TitleImagePath { get; set; }

        [Required]
        [Display(Name = "картинки")]
        public virtual List<string>? ImagesPaths { get; set; } = new();

        [Display(Name = "Полное описание")]
        public virtual string? Text { get; set; }


        //О квартире
        [Display(Name = "Тип жилья")]
        public string HousingType { get; set; }

        [Display(Name = "Количество комнат")]
        public string CountRooms { get; set; }

        [Display(Name = "Общая площадь")]
        public double TotalArea { get; set; } 

        [Display(Name = "Жилая площадь")]
        public double LivingSpace { get; set; }

        [Display(Name = "Площадь кухни")]
        public double KitchenArea { get; set; }

        [Display(Name = "Высота потолков")]
        public double CeilingHeight { get; set; }

        [Display(Name = "Санузел")]
        public string Bathroom { get; set; }

        [Display(Name = "Вид из окон")]
        public string ViewFromTheWindows { get; set; }

        [Display(Name = "Ремонт")]
        public string Repair { get; set; }

        [Display(Name = "Этаж")]
        public int Floor { get; set; }


        //О доме
        [Display(Name = "Год постройки")]
        public int? YearOfConstruction { get; set; }

        [Display(Name = "Тип дома")]
        public string? HouseType { get; set; }

        [Display(Name = "Строительная серия")]
        public int? ConstructionSeries { get; set; }

        [Display(Name = "Количество лифтов")]
        public string? NumberOfElevators { get; set; } = "-";

        [Display(Name = "Тип перекрытий")]
        public string? FloorType { get; set; } = "-";

        [Display(Name = "Подъездов в доме")]
        public int? Entrances { get; set; }

        [Display(Name = "Отопление")]
        public string? Heating { get; set; } = "-";

        [Display(Name = "Аварийность")]
        public string? AccidentRate { get; set; } = "-";

        [Display(Name = "Газоснабжение")]
        public string? GasSupply { get; set; } = "-";

        [Display(Name = "Этажей в доме")]
        public int EnFloorsInTheHouse { get; set; }


        [Display(Name = "SEO метатег Title")]
        public string? MetaTitle { get; set; }

        [Display(Name = "SEO метатег Description")]
        public string? MetaDescription { get; set; }

        [Display(Name = "SEO метатег Keywords")]
        public string? MetaKeywords { get; set; }


        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    }
}
