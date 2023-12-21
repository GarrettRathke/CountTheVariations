namespace CountTheVariations;

using CountTheVariations.Models;
using System.Text.Json;

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

    static void Main(string[] args)
    {
        var iceCreamSundaeData = LoadIceCreamSundaeData();
    }
}
