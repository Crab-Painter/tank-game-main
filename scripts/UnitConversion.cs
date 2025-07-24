using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Godot;

namespace Tankgamemain.scripts;

public partial class UnitConversion
{



    // how many of standart for ths project units are in 1 of specified unit
    // f.e. there is 16px in 1m
    // standart units are: radians, seconds and pixels
    private static readonly Dictionary<string, float> map = new()
    {
        {"rad", 1F},
        {"px", 1F},
        {"s", 1F},

        {"m", 16F},
        {"km", 16000F},
        {"h", 3600F},
        {"deg", (float)Math.PI/180}
    };

    public static float Import(string valueUnit)
    {
        Match match = ValueUnitParcerRegex().Match(valueUnit);
        float amount = float.Parse(match.Groups["amount"].Value);
        string unitTop = match.Groups["unitTop"].Value;
        string unitBottom = match.Groups["unitBottom"].Value;

        float amountConverted = amount * map[unitTop] / (unitBottom != null ? map[unitBottom] : 1F);

        return amountConverted;
    }

    public static string Export(float amount, string unit)
    {
        Match match = ValueUnitParcerRegex().Match(unit);
        string unitTop = match.Groups["unitTop"].Value;
        string unitBottom = match.Groups["unitBottom"].Value;
        float amountConverted = amount * map[unitTop] / (unitBottom != null ? map[unitBottom] : 1F);
        string result = amountConverted + " " + unit;
        return result;
    }

    [GeneratedRegex(@"^(?<amount>\d+) *(?<unitTop>[a-zA-Z]+)\/*(?<unitBottom>[a-zA-Z]*)$")]
    private static partial Regex ValueUnitParcerRegex();
    
    [GeneratedRegex(@"^(?<unitTop>[a-zA-Z]+)\/*(?<unitBottom>[a-zA-Z]*)$")]
    private static partial Regex UnitParcerRegex();

}
