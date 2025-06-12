// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.menu.commands;

public class ExitCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine($"{DateTime.Now} | COMMAND | Closing the Game");
        Environment.Exit(0);
    }
}