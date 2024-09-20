namespace TheRoadApp.Models.Tours
{
    using TheRoadApp.Data.Models.Enums;

    public class TourViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public int DurationInDays { get; set; }

        public int Capacity { get; set; }

        public int TourGuidesCount { get; set; }

        public string SleepConditions { get; set; }

        public Difficulty Terrain { get; set; }

        public decimal Price { get; set; }
    }
}
