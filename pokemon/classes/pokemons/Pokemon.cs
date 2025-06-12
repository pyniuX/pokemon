// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.classes.pokemons;

using pokemon.classes.attacks;

public class Pokemon : IPokemon
{
    private int? defualtHP;
    private string? evolutionFile;
    private List<Attack> attacks = new List<Attack>();
    private PokemonType? type;


    public string Name { get; set; }
    public int Level { get; set; }
    public int HP { get; set; }
    public float AP { get; set; }
    public int? DefaultHP {
        get{ return defualtHP; }
    }
    public string? EvolutionFile
    {
        get { return evolutionFile; }
    }
    public PokemonType? Type
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
        // if defaultHP is null assign, else nothing
        this.defualtHP ??= defaultHP;
    }

    public void SetEvolution(string fileName)
    {
        this.evolutionFile ??= fileName;
    }

    public void SetType(PokemonType type)
    {
        this.type ??= type;
    }

    public void Heal(int value)
    {
        value = (int)((value + HP < defualtHP) ? value : defualtHP-HP);
        Console.WriteLine($"{DateTime.Now} | POKEMON | Healing {Name} from {HP} to {HP+value}");
        HP += value;
    }
}