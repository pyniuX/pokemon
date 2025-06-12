// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.menu.commands;

using pokemon.utils;

public class OpenInventoryCommand : ICommand
{
    public void Execute()
    {
        Logger.Log("COMMAND", "Opening Inventory");
    }
}