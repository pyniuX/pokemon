// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.menu.commands;

public class OpenShopCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine($"{DateTime.Now} | COMMAND | Opening Shop");
    }
}