using CommandLine;

namespace FinanceSharp.Options;

[Verb("present-value", HelpText = "Calculates present value.")]
internal class PresentValue
{
    [Option('f', "future-value", Required = false, HelpText = "The future value.")]
    public decimal? FutureValue { get; set; }

    [Option('r', "rate", Required = false, HelpText = "The interest rate.")]
    public decimal? Rate { get; set; }

    [Option('t', "time", Required = false, HelpText = "The time in years.")]
    public int? Time { get; set; }
}
