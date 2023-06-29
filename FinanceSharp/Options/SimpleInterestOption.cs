using CommandLine;

namespace FinanceSharp.Options;

[Verb("simple-interest", HelpText = "Calculates simple interest.")]
internal class SimpleInterestOption
{
    [Option('p', "principal", Required = false, HelpText = "The principal amount.")]
    public decimal Principal { get; set; }

    [Option('r', "rate", Required = false, HelpText = "The interest rate.")]
    public decimal Rate { get; set; }

    [Option('t', "time", Required = false, HelpText = "The time in years.")]
    public decimal Time { get; set; }
}
