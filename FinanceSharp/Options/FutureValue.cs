using CommandLine;

namespace FinanceSharp.Options;

[Verb("future-value", HelpText = "Calculates future value.")]
internal class FutureValue
{
    [Option('p', "principal", Required = false, HelpText = "The principal amount.")]
    public decimal? Principal { get; set; }

    [Option('r', "rate", Required = false, HelpText = "The interest rate.")]
    public decimal? Rate { get; set; }

    [Option('t', "time", Required = false, HelpText = "The time in years.")]
    public decimal? Time { get; set; }

    [Option('f', "frequency", Required = false, HelpText = "The compounding frequency.")]
    public decimal Frequency { get; set; }
}
