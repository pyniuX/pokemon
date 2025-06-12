// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.menu.states;

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

    public virtual void ToFight(State previousState)
    {
        LogFightTransition();
        player.PreviousState = previousState;
        player.State = new FightState(player);
    }

    public virtual void ToShop(State previousState, MyConfig config)
    {
        LogShopTransition();
        player.PreviousState = previousState;
        player.State = new ShopState(player, config);
    }

    public virtual void ToInventory(State previousState)
    {
        LogInventoryTransition();
        player.PreviousState = previousState;
        player.State = new InventoryState(player);
    }

    public virtual void ToMenu(State previousState, MyConfig config)
    {
        LogMenuTransition();
        player.PreviousState = previousState;
        player.State = new MenuState(player, config);
    }

    public virtual void ToPrevious()
    {
        Logger.Log("STATE", $"{Info()} | Returning to previous state...");
        player.State = player.PreviousState;
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