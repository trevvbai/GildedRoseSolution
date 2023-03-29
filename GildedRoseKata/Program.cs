using System;
using System.Collections.Generic;
using GildedRoseKata.Enums;
using Xunit;

namespace GildedRoseKata
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");
            const int daysInMonth = 31;

            IList<Item> inventoryItems = new List<Item>{
                new() {Name = ItemNames.DexterityVest, SellIn = 10, Quality = 20},
                new() {Name = ItemNames.AgedBrie, SellIn = 2, Quality = 0},
                new() {Name = ItemNames.MongooseElixir, SellIn = 5, Quality = 7},
                new() {Name = ItemNames.Sulfuras, SellIn = 0, Quality = 80},
                new() {Name = ItemNames.Sulfuras, SellIn = -1, Quality = 80},
                new()
                {
                    Name = ItemNames.BackstagePass,
                    SellIn = 15,
                    Quality = 20
                },
                new()
                {
                    Name = ItemNames.BackstagePass,
                    SellIn = 10,
                    Quality = 49
                },
                new()
                {
                    Name = ItemNames.BackstagePass,
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new() {Name = ItemNames.ManaCake, SellIn = 3, Quality = 6}
            };

            var app = new GildedRose(inventoryItems);


            for (var i = 0; i < daysInMonth; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                foreach (var item in inventoryItems)
                {
                    Console.WriteLine(item.Name + ", " + item.SellIn + ", " + item.Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
