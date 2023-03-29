using System.Collections.Generic;
using GildedRoseKata.Enums;
using GildedRoseKata.Helpers;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private readonly IList<Item> _inventoryItems;

        public GildedRose(IList<Item> inventoryItems)
        {
            _inventoryItems = inventoryItems;
        }


        //todo reduce nesting level
        //todo reduce conditional complexity
        //todo use short functions that are well named and easily fit into one screen
        public void UpdateQuality()
        {
            var qualityHelpers = new QualityHelpers();

            foreach (var item in _inventoryItems)
            {
                switch (item.Name)
                {
                    case ItemNames.Sulfuras:
                        break;

                    case ItemNames.AgedBrie:
                        qualityHelpers.HandleAgedBrie(item);
                        break;

                    case ItemNames.BackstagePass:
                        qualityHelpers.HandleBackstagePass(item);
                        break;

                    default:
                        qualityHelpers.HandleNormalItem(item);
                        break;
                }
            }
        }
    }
}