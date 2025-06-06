// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.classes.attacks;

using pokemon.utils;
using System.Text.Json;

public static class AttackFactory
{
    public static Attack CreateAttack(string filePath)
    {
        // TODO: use path combine
        string jsonString = File.ReadAllText($"{Utils.GetProjectDir()}{filePath}");
        return JsonSerializer.Deserialize<Attack>(jsonString)!;
    }
}