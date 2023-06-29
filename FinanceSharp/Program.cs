namespace FinanceSharp;

using CommandLine;
using Options;

internal class Program
{
    static void Main(string[] args)
    {
        Parser.Default.ParseArguments<SimpleInterestOption>(args)
            .MapResult(
              (SimpleInterestOption opts) =>
              {
                      decimal interest = CalculateSimpleInterest(opts.Principal, 
                                                                 opts.Rate, 
                                                                 opts.Time);
                      Console.WriteLine($"Simple interest: {interest}");
                  return interest;
              },
              errs => 1);
    }

    static decimal CalculateSimpleInterest(decimal principal, decimal rate, decimal time)
    {
        // formula to calculate simple interest: PRT/100
        return (principal * rate * time) / 100;
    }
}