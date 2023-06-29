﻿using CommandLine;

namespace FinanceSharp.Options;

[Verb("compound-interest", HelpText = "Calculates compound interest.")]
internal class CompoundInterest
{
    [Option('p', "principal", Required = false, HelpText = "The principal amount.")]
    public decimal? Principal { get; set; }

    [Option('r', "rate", Required = false, HelpText = "The interest rate.")]
    public decimal? Rate { get; set; }

    [Option('t', "time", Required = false, HelpText = "The time in years.")]
    public decimal? Time { get; set; }
}
