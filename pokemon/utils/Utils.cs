// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.utils;

public static class Utils
{
    public static string GetProjectDir()
    {
        var baseDir = AppContext.BaseDirectory;
        return Directory.GetParent(baseDir)?.Parent?.Parent?.Parent?.FullName;
    }

    public static string TakeString(string message)
    {
        while (true)
        {
            Console.WriteLine(message);
            string value = Console.ReadLine();
            if (value.Length != 0)
                return value;
            Console.WriteLine("ERROR: plain input, string expected");
        }
    }

    public static int TakeInt(string message)
    {
        while (true)
        {
            Console.WriteLine(message);
            if (int.TryParse(Console.ReadLine(), out var value))
            {
                return value;
            }
            else
            {
                Console.WriteLine("ERROR: wrong input type, integer expected.");
                continue;
            }
        }
    }
}