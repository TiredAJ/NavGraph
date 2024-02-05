using System.Numerics;

namespace AdminPanelCLI.Utilities;

public class Utilities
{
    private string ValidStrInput(string _Query)
    {
        bool Valid = false;

        string? Input;

        do
        {
            Console.WriteLine(_Query);

            Input = Console.ReadLine();

            if (Input != null && Input != string.Empty)
            { return Input; }

        } while (!Valid);

        return default;
    }

    private T ValidNumericInput<T>(string _Query) where T : INumber<T>
    {
        bool Valid = false;
        string? Input;
        T? Result;

        do
        {
            Console.WriteLine(_Query);

            Input = Console.ReadLine();

            if (T.TryParse(Input, null, out Result))
            { return Result; }

        } while (!Valid);

        return default;
    }
}
