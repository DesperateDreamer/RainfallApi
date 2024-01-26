namespace RainfallApi.Models
{
    public class ReadingApiModel
    {
        public IEnumerable<ReadingApiItemModel> Items { get; set; }
    }

    public class ReadingApiItemModel
    {
        public DateTime DateTime { get; set; }
        public decimal Value { get; set; }
    }
}
