# LINQ Practice Questions

This repository contains C# code for practicing LINQ (Language Integrated Query) based on questions from [W3Resource](https://www.w3resource.com/csharp-exercises/linq/index.php). Each C# file corresponds to different LINQ exercises demonstrating various query operations.

## Files Included

- **PracticeQuestionsFromW3Resource.cs**
  - Contains methods for different LINQ exercises such as filtering, projection, aggregation, and joining operations.
  - Each method corresponds to a specific question from the W3Resource LINQ exercises.
  - Examples include finding positive numbers, calculating squares, counting frequencies, and more.

- **Person.cs**
  - A class representing a Person with properties like Id, Name, and Age.
  - Implements `IEquatable<Person>` for equality comparison.
  - Used in some LINQ queries for demonstrating object querying.

- **Item_mast.cs, Purchase.cs, Country.cs, City.cs**
  - Classes used in examples demonstrating LINQ joins and object querying.
  - `Item_mast` and `Purchase` demonstrate joining operations.
  - `Country` and `City` demonstrate object querying scenarios.

## How to Use

1. Clone the repository to your local machine:

   ```
   git clone https://github.com/yourusername/LINQPractice.git
   ```

2. Open the solution in your preferred IDE (e.g., Visual Studio, VS Code with C# extensions).

3. Explore each C# file (`PracticeQuestionsFromW3Resource.cs`, `Person.cs`, etc.) to understand the LINQ examples and object querying techniques demonstrated.

4. Run the `Test()` method in `PracticeQuestionsFromW3Resource.cs` or individual methods in other files to execute and see the output of each LINQ query.

## Notes

- Ensure you have .NET Core or .NET Framework installed to compile and run the C# code.
- Modify and expand the codebase to practice more LINQ queries or integrate with your own projects.

## Contributions

Contributions are welcome! If you have additional LINQ exercises or improvements to the existing code, feel free to fork the repository and submit a pull request.
