namespace country_info_app.server.Models
{
    public class Country
    {
        public string Id { get; set; }
        public string Iso2Code { get; set; }
        public string Name { get; set; }
        public Region Region { get; set; }
        public Region AdminRegion { get; set; }
        public Region IncomeLevel { get; set; }
        public Region LendingType { get; set; }
        public string CapitalCity { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}