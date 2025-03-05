namespace PatternsConsoleApp.src.utils;

public static class Extensions
{
    public static string IndentLines(this string str, string indent)
    {
        string[] lines = str.Split('\n');
        for (int i = 0; i < lines.Length; i++)
            lines[i] = indent + lines[i];

        return string.Join('\n', lines);
    }
}
