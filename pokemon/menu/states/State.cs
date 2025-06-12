// Copyright (c) 2025 Krzysztof Puk
// All rights reserved
// https://github.com/pyniuX

namespace pokemon.menu.states;


class StateTransitionForbidden(): Exception();

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

    public virtual void ToShop(State previousState)
    {
        LogShopTransition();
        player.PreviousState = previousState;
        player.State = new ShopState(player);
    }

    public virtual void ToInventory(State previousState)
    {
        LogInventoryTransition();
        player.PreviousState = previousState;
        player.State = new InventoryState(player);
    }

    public virtual void ToMenu(State previousState)
    {
        LogMenuTransition();
        player.PreviousState = previousState;
        player.State = new MenuState(player);
    }

    public virtual void ToPrevious()
    {
        Console.WriteLine($"{DateTime.Now} | STATE| {Info()} | Returning to previous state...");
        player.State = player.PreviousState;
    }

    public void LogShopTransition()
    { Console.WriteLine($"{DateTime.Now} | STATE | {Info()} | Opening shop..."); }

    public void LogFightTransition()
    { Console.WriteLine($"{DateTime.Now} | STATE | {Info()} | Starting fight...");}

    public void LogInventoryTransition()
    { Console.WriteLine($"{DateTime.Now} | STATE | {Info()} | Opening inventory...");}

    public void LogMenuTransition()
    { Console.WriteLine($"{DateTime.Now} | STATE | {Info()} | Returning to menu...");}

}