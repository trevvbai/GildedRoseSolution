using System;
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
        public void TestDoesNothingGivenSulfuras()
        {
            const int initialQuality = 80;
            var items = new List<Item> {
                                new() {Name = ItemNames.Sulfuras, SellIn = 0, Quality = initialQuality},

            };
            
            var gildedRose = new GildedRose(items);
            
            gildedRose.UpdateQuality();

            var firstItem = items.First();
            
            firstItem.Quality.ShouldBe(initialQuality);
        }

        [Fact]
        public void TestBackstageIsZeroAtZeroSellIn()
        {
            //Arrange
            var items = new List<Item> {
                new()
                {
                    Name = ItemNames.BackstagePass,
                    SellIn = 0,
                    Quality = 20
                },
            };

            var gildedRose = new GildedRose(items);

            //Act
            gildedRose.UpdateQuality();
            var pass = items.First();

            //Assert
            pass.Quality.ShouldBe(0);
        }

        [Fact]
        public void TestBackstagePassQualityIncreaseBy2()
        {
            //Arrange
            var items = new List<Item> {
                new()
                {
                    Name = ItemNames.BackstagePass,
                    SellIn = 10,
                    Quality = 20
                },
            };
            
            var gildedRose = new GildedRose(items);

            //Act
            gildedRose.UpdateQuality();
            var pass = items.First();

            //Assert
            pass.Quality.ShouldBe(22);
            
        }        
        
        [Fact]
        public void TestBackstagePassQualityIncreaseBy3()
        {
            //Arrange
            var items = new List<Item> {
                new()
                {
                    Name = ItemNames.BackstagePass,
                    SellIn = 5,
                    Quality = 20
                },
            };
            
            var gildedRose = new GildedRose(items);

            //Act
            gildedRose.UpdateQuality();
            var pass = items.First();

            //Assert
            pass.Quality.ShouldBe(23);
            
        }        
        
        [Fact]
        public void TestAgedBrieIncreasesWithAge()
        {
            //Arrange
            var items = new List<Item> {
                new()
                {
                    Name = ItemNames.AgedBrie,
                    SellIn = 5,
                    Quality = 20
                },
            };
            
            var gildedRose = new GildedRose(items);

            //Act
            for (var i = 0; i < 5; i++)
            {
                gildedRose.UpdateQuality();
            }
            var brie = items.First();

            //Assert
            brie.Quality.ShouldBe(25);
            
        }
        
        [Fact]
        public void TestQualityStopAtFifty()
        {
            //Arrange
            var items = new List<Item> {
                new()
                {
                    Name = ItemNames.AgedBrie,
                    SellIn = 5,
                    Quality = 50
                },
            };
            
            var gildedRose = new GildedRose(items);

            //Act

            gildedRose.UpdateQuality();
            var brie = items.First();

            //Assert
            brie.Quality.ShouldBe(50);
        }
        
        [Fact]
        public void TestExceptionIfQualityOverFifty()
        {
            //Arrange
            var items = new List<Item> {
                new()
                {
                    Name = ItemNames.AgedBrie,
                    SellIn = 5,
                    Quality = 51
                },
            };
            
            var gildedRose = new GildedRose(items);

            //Act and Assert
            Should.Throw<Exception>(() => gildedRose.UpdateQuality());
        }
        
        [Fact]
        public void TestExceptionIfQualityUnderZero()
        {
            //Arrange
            var items = new List<Item> {
                new()
                {
                    Name = ItemNames.AgedBrie,
                    SellIn = 5,
                    Quality = -1
                },
            };
            
            var gildedRose = new GildedRose(items);

            //Act and Assert
            Should.Throw<Exception>(() => gildedRose.UpdateQuality());
        }

        [Fact]
        public void TestQualityStopsAtZero()
        {
            //Arrange
            var items = new List<Item> {
                new()
                {
                    Name = ItemNames.MongooseElixir,
                    SellIn = 5,
                    Quality = 0
                },
            };
            
            var gildedRose = new GildedRose(items);

            
            //Act
            gildedRose.UpdateQuality();
            var brie = items.First();

            //Assert
            brie.Quality.ShouldBe(0);
            
        }
        
        [Fact]
        public void TestQualityDegradesTwiceAsFastAfterSellDatePassed()
        {
            //Arrange
            var items = new List<Item> {
                new()
                {
                    Name = ItemNames.MongooseElixir,
                    SellIn = -1,
                    Quality = 3
                },
            };
            
            var gildedRose = new GildedRose(items);

            
            //Act
            gildedRose.UpdateQuality();
                
            var elixir = items.First();

            //Assert
            elixir.Quality.ShouldBe(1);
            
        }
        
        [Fact]
        public void TestBrieUpgradesTwiceAsFastAfterSellDatePassed()
        {
            //Arrange
            var items = new List<Item> {
                new()
                {
                    Name = ItemNames.AgedBrie,
                    SellIn = -1,
                    Quality = 3
                },
            };
            
            var gildedRose = new GildedRose(items);

            
            //Act
            gildedRose.UpdateQuality();
                
            var brie = items.First();

            //Assert
            brie.Quality.ShouldBe(5);
            
        }
        
        

    }
}
