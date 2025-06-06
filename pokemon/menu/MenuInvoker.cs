// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.menu;

static class MenuInvoker
{
    public static void TakeInput(string message, Type desiredType)
    {
        while (true)
        {
            Console.WriteLine(message);
            var value = Console.ReadKey();
        }
    }
}