// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.classes.pokemons;

using pokemon.classes.attacks;
using pokemon.classes.types;

public class Pokemon : IPokemon
{
    private int defualtHP;

    private List<Attack> attacks;

    public string Name { get; set; }
    public int Level { get; set; }
    public int HP { get; set; }
    public float AP { get; set; }
    public string? EvolutionFile { get; set; }

    public IType Type { get; set; }
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
    public void SetType()
    {
        // TODO: set type
    }
}