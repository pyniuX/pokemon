// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.classes.pokemons;

using pokemon.classes.attacks;

public class Pokemon : IPokemon
{
    private int defualtHP;

    private List<Attack> attacks;
    private PokemonType type;

    public string Name { get; set; }
    public int Level { get; set; }
    public int HP { get; set; }
    public float AP { get; set; }
    public string? EvolutionFile { get; set; }

    public PokemonType Type
    {
        get { return type; }
    }
    public IReadOnlyList<Attack> Attacks => attacks.AsReadOnly();

    public void AddAttack(Attack attack)
    {
        attacks.Add(attack);
    }

    public void RemoveAttack(Attack attack)
    {
        attacks.Remove(attack);
    }

    public void Attack(IPokemon target, Attack attack)
    { }

    public IPokemon? Evolve()
    {
        var output = (EvolutionFile is null) ? null : PokemonFactory.CreatePokemon(EvolutionFile);
        return output;
    }

    public void SetDefaultHP(int defaultHP)
    {
        this.defualtHP = defaultHP;
    }

    public void SetType(PokemonType type)
    {
        this.type = type;
    }

    public void Heal(int value)
    {
        value = (value + HP < defualtHP) ? value : defualtHP-HP;
        HP += value;
    }
}