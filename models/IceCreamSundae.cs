namespace CountTheVariations.Models;

using System;


public class IceCreamSundae  : IEquatable<IceCreamSundae>
{
    public string FlavorOne { get; set; }
    public string FlavorTwo { get; set; }
    public string FlavorThree { get; set; }
    public int TimesEaten { get; set; }

    public override bool Equals(object obj)
    {
        return obj is IceCreamSundae && this.Equals(obj);
    }

    public bool Equals(IceCreamSundae other)
    {
        if (other == null) {
            return false;
        }
        var thisFlavors = new List<string> { this.FlavorOne, this.FlavorTwo, this.FlavorThree };
        var otherFlavors = new List<string> { other.FlavorOne, other.FlavorTwo, other.FlavorThree };
        return thisFlavors.OrderBy(x => x).SequenceEqual(otherFlavors.OrderBy(x => x));
    }
}