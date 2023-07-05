# FinanceSharp CLI
FinanceSharp CLI is a command-line interface (CLI) application developed in .NET to calculate simple financial values. The application currently supports the following commands:

- Simple Interest Calculation
- Future Value Calculation

## Prerequisites
Make sure you have the .NET Runtime installed on your machine. You can download it from the official .NET website.

## Usage
Simple Interest Calculation
This command calculates the simple interest given a principal amount, the rate of interest, and a time period.

### Command:
```shell
FinanceSharp.exe simpleinterest <principal> <rate> <time>
```
**Parameters:**

- <principal>: The principal amount (must be a numeric value)
- <rate>: The rate of interest (must be a numeric value)
- <time>: The time period in years (must be a numeric value)

**Example:**

To calculate the simple interest for a principal of 10,000 with a rate of 5% over 3 years, use the following command:
```shell
FinanceSharp.exe simpleinterest 10000 5 3
```
## Future Value Calculation
This command calculates the future value of an investment given a principal amount, the rate of interest, the compounding frequency, and a time period.

### Command:
```shell
FinanceSharp.exe futurevalue <principal> <rate> <compounding_frequency> <time>
```
Parameters:

- <principal>: The principal amount (must be a numeric value)
- <rate>: The annual interest rate (must be a numeric value)
- <compounding_frequency>: The number of times that interest is compounded per year (must be a numeric value)
- <time>: The time period in years (must be a numeric value)

**Example:**
To calculate the future value for a principal of 10,000 with an annual interest rate of 5%, compounded quarterly, over 3 years, use the following command:
```shell
FinanceSharp.exe futurevalue 10000 5 4 3
```
# License
This project is licensed under the terms of the MIT license.

Please note, the above instructions assume that the FinanceSharp.exe executable is in the system's PATH or the current directory. If this is not the case, the user will need to provide the full path to the executable.


