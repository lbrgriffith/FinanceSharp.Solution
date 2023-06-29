namespace FinanceSharp;

using CommandLine;
using ConsoleTables;
using Options;
using Sharprompt;

internal class Program
{
    static void Main(string[] args)
    {
        Parser.Default.ParseArguments<SimpleInterestOption, CompoundInterest>(args)
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
              (CompoundInterest compound) =>
              {
                  decimal principle = 0M;
                  decimal rate      = 0M;
                  int time          = 1;

                  #region Simple Interest Validations

                  if (compound.Principal is not null)
                  {
                      principle = (decimal)compound.Principal;
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

                  if (compound.Rate is not null)
                  {
                      rate = (decimal)compound.Rate;
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

                  if (compound.Time is not null)
                  {
                      time = (int)compound.Time;
                  }
                  else
                  {
                      time = Prompt.Input<int>("What's the time in years?",
                                                   defaultValue: 0,
                                                   placeholder: "Enter a percentage greater than zero",
                                                   validators: new[] { Validators.Required(),
                                                                       Validators.MinLength(1, "Amount is required!")
                                                   });
                  }

                  #endregion

                  decimal interest = CalculateCompoundInterest(principle,
                                                             rate,
                                                             time);

                  var table = new ConsoleTable("Description", "Result");
                  table.AddRow("Compound interest", interest);

                  table.Write();
                  Console.WriteLine();
                  return interest;
              },
              errs => 1);
    }

    #region Methods

    static decimal CalculateSimpleInterest(decimal principal, decimal rate, decimal time)
    {
        // formula to calculate simple interest: PRT/100
        return (principal * rate * time) / 100;
    }

    /// <summary>
    /// Calculates compound interest based on the principal amount, interest rate, and time period
    /// and returns the resulting amount.
    /// </summary>
    /// <param name="principalAmount">The initial amount of money.</param>
    /// <param name="interestRate">The annual interest rate.</param>
    /// <param name="timePeriod">The time period in years.</param>
    /// <returns>The resulting amount after applying compound interest.</returns>
    /// <exception cref="ArgumentException">Missing arguments required to complete the calculations.</exception>
    static public decimal CalculateCompoundInterest(decimal principalAmount, decimal interestRate, int timePeriod)
    {
        // Ensure the principal amount, interest rate, and time period are non-negative.
        if (principalAmount < 0 || interestRate < 0 || timePeriod < 0)
        {
            throw new ArgumentException("Principal amount, interest rate, and time period must be non-negative.");
        }

        // Calculate the compound interest amount.
        decimal compoundInterest = principalAmount * (decimal)Math.Pow((double)(1 + (interestRate / 100)), timePeriod);

        // Calculate the resulting amount.
        decimal resultingAmount = principalAmount + compoundInterest;

        // Return the resulting amount.
        return resultingAmount;
    } 

    #endregion
}