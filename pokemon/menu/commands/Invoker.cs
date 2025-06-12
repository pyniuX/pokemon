// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

using Microsoft.CodeAnalysis.CSharp;

namespace pokemon.menu.commands;

public class Invoker
{
    private ICommand? command;

    public void SetCommand(ICommand command)
    {
        this.command = command;
    }

    public void ExecuteCommand()
    {
        command.Execute();
    }

    public void SetAndExecuteCommand(ICommand command)
    {
        SetCommand(command);
        ExecuteCommand();
    }
}