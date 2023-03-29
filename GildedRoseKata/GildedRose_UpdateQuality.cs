﻿using FluentAssertions;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using GildedRoseKata.Enums;
using Xunit;

namespace GildedRoseKata
{
    /// <summary>
    /// Test naming convention recommendation:
    /// https://ardalis.com/unit-test-naming-convention/
    /// </summary>
    public class GildedRose_UpdateQuality
    {
        [Fact]
        public void DoesNothingGivenSulfuras()
        {
            const int initialQuality = 80;
            var items = new List<Item> {
                                new() {Name = ItemNames.Sulfuras, SellIn = 0, Quality = initialQuality},

            };
            
            var gildedRose = new GildedRose(items);
            
            gildedRose.UpdateQuality();

            var firstItem = items.First();
            
            // Use your preferred assertion library (already included - pick one delete others)
            // xunit default
            Assert.Equal(initialQuality, firstItem.Quality);

            // fluentassertions
            firstItem.Quality.Should().Be(initialQuality);

            // shouldly
            firstItem.Quality.ShouldBe(initialQuality);
        }
    }
}
