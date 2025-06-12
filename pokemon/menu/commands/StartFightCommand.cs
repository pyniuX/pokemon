// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.menu.commands;

public class StartFightCommand : ICommand
{

    public void Execute()
    {
        Console.WriteLine($"{DateTime.Now} | COMMAND | Starting Fight");
    }
}