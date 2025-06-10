// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.classes.attacks;

using pokemon.utils;
using System.Text.Json;
using Newtonsoft.Json;
using System.Collections.Generic;

public static class AttackFactory
{
    private static AttackDatabase database = new AttackDatabase();
    private static MyConfig? config;

    public static Attack CreateAttack(string filePath)
    {
        string path = Path.Combine(Utils.GetProjectDir(), AttackFactory.config.AttacksDataDir, filePath);
        string jsonString = File.ReadAllText(path);

        var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
        if (! IsInDatabase(dict["Name"].ToString()))
        {
            Console.WriteLine($"{DateTime.Now} | ATTACK | Creating attack from {filePath}");
            Attack attack = JsonConvert.DeserializeObject<Attack>(jsonString)!;
            AddAttackToDatabase(attack);
            return attack;
        }
        else
        {
            return GetAttackFromDatabase(dict["Name"].ToString());
        }
    }

    public static bool AddAttackToDatabase(Attack attack)
    {
        return database.AddAttack(attack);
    }

    public static bool IsInDatabase(string key)
    {
        return database.IsInDatabase(key);
    }

    public static Attack GetAttackFromDatabase(string key)
    {
        return database.GetAttack(key);
    }

    public static void ClearDatabase()
    {
        database.Clear();
    }

    public static void SetConfig(MyConfig? config)
    {
        AttackFactory.config = config;
    }
}