using System;

namespace APLabDigiKalaProject
{
    public interface IFilter
    {
        bool Filter(Item item);
    }
    public class PriceFilter : IFilter
    {
        public double PriceBoundry { get; set; }
        public PriceFilter(double priceBoundry)
        {
            PriceBoundry = priceBoundry;
        }

        public bool Filter(Item item) => item.Price <= PriceBoundry;
    }
    public class PriceRangeFilter: IFilter
    {
        public double PriceUpperBound { get; set; }
        public double PriceLowerBound { get; set; }
        public PriceRangeFilter(double priceLowerBound, double priceUpperBound)
        {
            PriceLowerBound = priceLowerBound;
            PriceUpperBound = priceUpperBound;
        }
        public bool Filter(Item item) => (PriceLowerBound <= item.Price) && (PriceUpperBound >= item.Price);
    }
    public class ReleaseDateFilter : IFilter
    {
        public DateTime ReleaseDate { get; set; }
        public ReleaseDateFilter(DateTime releaseDate)
        {
            ReleaseDate = releaseDate;
        }
        public bool Filter(Item item) => item.Date > ReleaseDate;
    }
    public class BrandFilter: IFilter
    {
        public string Brand { get; set; }
        public BrandFilter(string brand)
        {
            Brand = brand;
        }
        public bool Filter(Item item) => item.Brand == Brand;
    }
}
