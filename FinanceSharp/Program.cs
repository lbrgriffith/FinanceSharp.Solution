namespace FinanceSharp;

using CommandLine;
using ConsoleTables;
using Options;
using Sharprompt;

internal class Program
{
    static void Main(string[] args)
    {
        Parser.Default.ParseArguments<SimpleInterestOption>(args)
            .MapResult(
              (SimpleInterestOption opts) =>
              {
                  decimal principle  = 0M;
                  decimal rate       = 0M;
                  decimal time       = 0M;

                  #region Simple Interest Validations

                  if (opts.Principal is not null)
                  {
                      principle = (decimal)opts.Principal;
                  }
                  else
                  {
                      principle = Prompt.Input<decimal>("What's the priciple?",
                                                        defaultValue: 0M,
                                                        placeholder: "Enter an amount greater than zero",
                                                        validators: new[] { Validators.Required(),
                                                                            Validators.MinLength(1, "Amount is required!")
                                                        });
                  }

                  if (opts.Rate is not null)
                  {
                      rate = (decimal)opts.Rate;
                  }
                  else
                  {
                      rate = Prompt.Input<decimal>("What's the interest rate?",
                                                   defaultValue: 0M,
                                                   placeholder: "Enter a percentage greater than zero",
                                                   validators: new[] { Validators.Required(),
                                                                       Validators.MinLength(1, "Amount is required!")
                                                  });
                  }

                  if (opts.Time is not null)
                  {
                      time = (decimal)opts.Time;
                  }
                  else
                  {
                      time = Prompt.Input<decimal>("What's the time in years?",
                                                   defaultValue: 0M,
                                                   placeholder: "Enter a percentage greater than zero",
                                                   validators: new[] { Validators.Required(),
                                                                       Validators.MinLength(1, "Amount is required!")
                                                   });
                  } 

                  #endregion

                  decimal interest = CalculateSimpleInterest(principle,
                                                             rate,
                                                             time);

                  var table = new ConsoleTable("Description", "Result");
                  table.AddRow("Simple interest", interest);

                  table.Write();
                  Console.WriteLine();
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