using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExamples.SelectExamples
{
    public class SelectExample
    {
        public void SelectWithIndex()
        {
            List<int> numbers = new List<int>() { 2, 3, 1, 7, 6, 9, 5, 4, 10, 11, 12 };

            var result = numbers.Select((v, index) =>  {
                if (index % 2 == 0)
                    return v * 2;
                else
                    return v;
            });

            foreach (var item in result)
            {
                Console.Write("{0}, ", item);
            }
        }

        public void SelectMany()
        {
            var result1 = from b in GetBouquetList()
                          from f in b.Flowers
                          select f;

            Console.Write("Result1 = [");
            foreach (var item in result1)
            {
                Console.Write("{0}({1}), ", item.Name, item.Description);
            }
            Console.WriteLine("]");
            Console.WriteLine();

            var result2 = GetBouquetList().SelectMany(b => b.Flowers);

            Console.Write("Result2 = [");
            foreach (var item in result2)
            {
                Console.Write("{0}({1}), ", item.Name, item.Description);
            }
            Console.WriteLine("]");
            Console.WriteLine();
        }

        public void SelectDistinct()
        {
            var result = GetBouquetList().SelectMany(b => b.Flowers)
                                         .GroupBy(f => f.Name).Select(group => group.First());

            Console.Write("Result = [{0}]", string.Join(", ", result.Select(flower => string.Format("{0}({1})", flower.Name, flower.Description))));
            Console.WriteLine();
        }


        #region Private Methods

        private IEnumerable<Bouquet> GetBouquetList()
        {
            return new List<Bouquet> {
                new Bouquet { Flowers = new List<Flower> { new Flower{ Name = "sunflower",  Description = "해바라기"}, new Flower{ Name = "daisy", Description = "데이지"},
                                                           new Flower{ Name = "daffodil", Description ="수선화"}, new Flower{ Name = "larkspur", Description ="미나리아재비" }
                                                         }
                            },
                new Bouquet { Flowers = new List<Flower> { new Flower{ Name = "tulip",  Description = "튜립"}, new Flower{ Name = "rose", Description = "장미"},
                                                           new Flower{ Name = "orchid", Description ="난초"}, new Flower{ Name = "sunflower",  Description = "해바라기"}
                                                         }
                            },
                new Bouquet { Flowers = new List<Flower> { new Flower{ Name = "gladiolis",  Description = "글라디올러스"}, new Flower{ Name = "lily", Description = "백합"},
                                                           new Flower{ Name = "snapdragon", Description ="금어초"}, new Flower{ Name = "aster", Description = "과꽃"},
                                                           new Flower{ Name = "protea", Description ="프로테아"}, new Flower{ Name = "daisy", Description = "데이지"}
                                                         }
                            },
                new Bouquet { Flowers = new List<Flower> { new Flower{ Name = "larkspur",  Description = "미나리아재비"}, new Flower{ Name = "lilac", Description = "라일락"},
                                                           new Flower{ Name = "iris", Description ="붓꽃"}, new Flower{ Name = "dahlia", Description = "달리아"}
                                                         }
                            }
            };
        }

        #endregion
    }

    internal class Bouquet
    {
        public IEnumerable<Flower> Flowers { get; set; }
    }

    internal class Flower
    {
        public string Name;
        public string Description;
    }
}
