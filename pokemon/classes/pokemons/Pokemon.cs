// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.classes.pokemons;

using pokemon.classes.attacks;
using pokemon.classes.types;

public class Pokemon : IPokemon
{
    private int defualtHP;
    private string baseData;
    // TODO: maybe two different json?

    private List<IAttack> attacks;

    public string Name { get; set; }
    public int Level { get; set; }
    public int HP { get; set; }
    public float AP { get; set; }
    public IType Type { get; set; }

    // public Pokemon(int _defaultHP)
    // {
    // defualtHP = _defaultHP;
    // }

    public IReadOnlyList<IAttack> Attacks => attacks.AsReadOnly();

    public void AddAttack(IAttack attack)
    {
        attacks.Add(attack);
    }

    public void RemoveAttack(IAttack attack)
    {
        attacks.Remove(attack);
    }

    public void Evolve()
    { }

    public void Attack(IPokemon target, IAttack attack)
    { }
    
}