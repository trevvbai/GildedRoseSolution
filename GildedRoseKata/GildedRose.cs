using System;
using System.Collections.Generic;
using GildedRoseKata.Enums;
using GildedRoseKata.Helpers;
using Xunit.Sdk;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private readonly IList<Item> _inventoryItems;

        public GildedRose(IList<Item> inventoryItems)
        {
            _inventoryItems = inventoryItems;
        }
        
        public void UpdateQuality()
        {
            try
            {
                var qualityHelpers = new QualityHelpers();

                foreach (var item in _inventoryItems)
                {
                    qualityHelpers.ValidateItemQuality(item);

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
                            if (item.Name.Contains("Conjured"))
                            {
                                qualityHelpers.HandleConjuredItem(item);
                            }
                            else
                            {
                                qualityHelpers.HandleNormalItem(item);
                            }
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}