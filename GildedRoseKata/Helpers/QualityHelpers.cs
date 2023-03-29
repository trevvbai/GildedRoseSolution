namespace GildedRoseKata.Helpers
{
    public class QualityHelpers
    {
        private const int MaxQuality = 50;
        
        private static bool IsLessThanMaxQuality(int quality)
        {
            return quality < MaxQuality;
        }

        private int IncrementQuality(int quality)
        {
            if (IsLessThanMaxQuality(quality))
            {
                return quality + 1;
            }
            return quality;
        }

        public void HandleAgedBrie(Item item)
        {
            item.Quality = IncrementQuality(item.Quality);

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                item.Quality = IncrementQuality(item.Quality);
            }
        }

        public void HandleBackstagePass(Item item)
        {
            item.Quality = IncrementQuality(item.Quality);
            if (item.SellIn < 11)
            {
                item.Quality = IncrementQuality(item.Quality);
            }

            if (item.SellIn < 6)
            {
                item.Quality = IncrementQuality(item.Quality);
            }


            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }

        public void HandleNormalItem(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }

            item.SellIn -= 1;

            if (item.SellIn >= 0) return;
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }
        }

    }
}