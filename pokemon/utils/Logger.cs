// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

using pokemon.menu.states;

namespace pokemon.utils;

// TODO: log levels
public static class Logger
{
    public static void Log(string scope, string message)
    {
        Console.WriteLine($"{DateTime.Now} | {scope} | {message}");
    }
}