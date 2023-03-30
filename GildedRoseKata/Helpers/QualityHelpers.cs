using System;
using GildedRoseKata.Enums;

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
            
            //degrades twice as fast after sell date
            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                    item.Quality -= 1;
                }            
            }

        }
        
        public void HandleConjuredItem(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 2;
            }
            
            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                if (item.Quality > 1)
                {
                    item.Quality -= 2;
                }            
            }
        }

        public void ValidateItemQuality(Item item)
        {
            if (item.Quality > 50 && item.Name != ItemNames.Sulfuras)
            {
                throw new Exception("Quality cannot be over 50");
            }

            if (item.Quality < 0)
            {
                throw new Exception("Quality cannot be less than 0");
            }
        }


    }
}