// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.classes.attacks;

using pokemon.utils;
using System.Text.Json;

public static class AttackFactory
{
    private static MyConfig? config;

    public static Attack CreateAttack(string filePath)
    {
        string path = Path.Combine(Utils.GetProjectDir(), AttackFactory.config.AttacksDataDir ,filePath);
        string jsonString = File.ReadAllText(path);
        Attack attack = JsonSerializer.Deserialize<Attack>(jsonString)!;
        return attack;
    }

    public static void SetConfig(MyConfig? config)
    {
        AttackFactory.config = config;
    }
}