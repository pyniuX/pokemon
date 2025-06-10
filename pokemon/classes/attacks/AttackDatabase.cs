// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.classes.attacks;

using pokemon.classes.attacks;

public class AttackDatabase
{
    private Dictionary<string, Attack> database = new Dictionary<string, Attack> { };

    public Attack GetAttack(string key)
    {
        return database[key];
    }

    public bool AddAttack(Attack attack)
    {
        if (!IsInDatabase(attack.Name))
        {
            database.Add(attack.Name, attack);
            return true;
        }
        else { return false; }
    }

    public bool IsInDatabase(string key)
    {
        return database.TryGetValue(key, out var value);
    }

    public void Clear()
    {
        database.Clear();
    }
}