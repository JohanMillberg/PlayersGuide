using System;

namespace WarPrep;

public class WarPrepClass
{
    public static void Main(string[] args)
    {
        Sword original = new(materials.iron, gemstoneType.noStone, 1, 0.2);
        Sword fancy = original with {material = materials.binarium, gemstone = gemstoneType.bitstone};
        Sword ultraLong = original with {material = materials.bronze, length = 8, gemstone = gemstoneType.emerald};

        Console.WriteLine(original);
        Console.WriteLine(fancy);
        Console.WriteLine(ultraLong);
    }
    public record Sword(materials material, gemstoneType gemstone, double length, double crossguardWidth);

    public enum gemstoneType {noStone, emerald, amber, sapphire, diamond, bitstone};
    public enum materials {wood, bronze, iron, steel, binarium};

}