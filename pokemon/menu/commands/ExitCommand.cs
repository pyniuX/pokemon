// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.menu.commands;

using pokemon.utils;

public class ExitCommand : ICommand
{
    public void Execute()
    {
        Logger.Log("COMMAND", "Closing the Game");
        Environment.Exit(0);
    }
}