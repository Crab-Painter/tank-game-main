using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Godot;

namespace Tankgamemain.scripts;

public partial class UnitConversion
{

    private static readonly IDictionary<string, float> map = new Dictionary<string, float>()
    {
        {"km", 16}
    };

    public float Import(string valueUnit)
    {        
        Match match = ValueUnitParcerRegex().Match(valueUnit);
        float amount = float.Parse(match.Groups["amount"].Value);
        string unitTop = match.Groups["unitTop"].Value;
        string unitBottom = match.Groups["unitBottom"].Value;

        
        float result = 0.5F;
        return result;
    }

        public string Export(float value, string unit)
    {
        var result = "0.5";
        return result;
    }

    [GeneratedRegex(@"^(?<amount>\d+) *(?<unitTop>[a-zA-Z]+)\/*(?<unitBottom>[a-zA-Z]*)$")]
    private static partial Regex ValueUnitParcerRegex();

}
