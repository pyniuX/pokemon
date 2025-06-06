// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.classes.pokemons;

using pokemon.classes.attacks;
using pokemon.classes.types;

public interface IPokemon
{
    public string Name{ get; set; }
    public int Level{ get; set; }
    public int HP{ get; set; }
    public float AP{ get; set; }
    public IType Type{ get; set; }
    public IReadOnlyList<Attack> Attacks{ get; }

    public void Evolve();
    public void Attack(IPokemon target, Attack attack);
    public void AddAttack(Attack attack);
    public void RemoveAttack(Attack attack);
}