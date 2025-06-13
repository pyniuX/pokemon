// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.menu.states;

using pokemon.classes.pokemons;
using pokemon.utils;

class StateTransitionForbidden() : Exception();

// TODO: keep states stored to not create new one each change
public abstract class State
{
    protected Player player;

    public State(Player player)
    {
        this.player = player;
    }

    public abstract void ShowMenu();
    public abstract void HandleInput(string input);

    public string Info()
    {
        return this.GetType().Name;
    }

    public virtual void ToFight()
    {
        LogFightTransition();
        player.State = new FightState(player);
    }

    public virtual void ToShop(MyConfig config)
    {
        LogShopTransition();
        player.State = new ShopState(player, config);
    }

    public virtual void ToInventory(IPokemon? pokemon = null)
    {
        LogInventoryTransition();
        player.State = new InventoryState(player, pokemon);
    }

    public virtual void ToMenu(MyConfig config)
    {
        LogMenuTransition();
        player.State = new MenuState(player, config);
    }

    public virtual void ToPrevious()
    {
        Logger.Log("STATE", $"{Info()} | Returning to previous state...");
        player.PopState();
    }

    public void LogShopTransition()
    { Logger.Log("STATE", $"{Info()} | Opening shop..."); }

    public void LogFightTransition()
    { Logger.Log("STATE", $"{Info()} | Starting fight...");}

    public void LogInventoryTransition()
    { Logger.Log("STATE", $"{Info()} | Opening inventory...");}

    public void LogMenuTransition()
    { Logger.Log("STATE", $"{Info()} | Returning to menu...");}

}