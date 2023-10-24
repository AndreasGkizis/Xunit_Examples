// See https://aka.ms/new-console-template for more information
Console.WriteLine("Simple Calculator");
Console.WriteLine("Enter two numbers and an operator (+, -, *, /):");

double num1 = SomeApp.GetUserInput.GetNumber("Enter the first number: ");
char operation = SomeApp.GetUserInput.GetOperator("Enter the operator: ");
double num2 = SomeApp.GetUserInput.GetNumber("Enter the second number: ");

double result = SomeApp.PerformOperation.RunOp(num1, operation, num2);

Console.WriteLine($"Result: {num1} {operation} {num2} = {result}");

