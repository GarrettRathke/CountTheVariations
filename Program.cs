namespace CountTheVariations;

using CountTheVariations.Models;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

class Program
{

    static private List<IceCreamSundae> LoadIceCreamSundaeData()
    {
        using (StreamReader r = new StreamReader("data/flavors.json"))
        {
            string json = r.ReadToEnd();
            return JsonSerializer.Deserialize<List<IceCreamSundae>>(json);          
        }
    }

    static private List<IceCreamSundae> CountDistinctVariations(List<IceCreamSundae> iceCreamSundaeData)
    {
        var distinctVariations = new List<IceCreamSundae>();
        for(var i = 0; i < iceCreamSundaeData.Count; i++)
        {
            var sundae = iceCreamSundaeData[i];
            for(var j = 0; j < iceCreamSundaeData.Count; j++)
            {
                // don't compare the current sundae to itself
                if(i == j)
                {
                    continue;
                }
                var otherSundae = iceCreamSundaeData[j];
                if (sundae.Equals(otherSundae))
                {
                    // if the sundae is already in the list, increment the TimesEaten property
                    var existingSundae = distinctVariations.Find(x => x.Equals(sundae));
                    if(existingSundae != null)
                    {
                        existingSundae.TimesEaten++;
                    }
                    else
                    {
                        // otherwise, add it to the list
                        sundae.TimesEaten++;
                        distinctVariations.Add(sundae);
                    }
                }
            }
        }
        return distinctVariations;
    }

    static void Main(string[] args)
    {
        var iceCreamSundaeData = LoadIceCreamSundaeData();
        var distinctVariationCounts = CountDistinctVariations(iceCreamSundaeData);
        Console.WriteLine($"There are {distinctVariationCounts.Count} distinct variations.");
    }
}
