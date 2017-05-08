using System;
using System.Collections.Generic;

using UnityEngine;

public interface IGameState
{
    void OnEnter(GameStateBehaviour context);
    void OnExit(GameStateBehaviour context);
    void Update(GameStateBehaviour context);
    void ToState(GameStateBehaviour context, IGameState state);

}

public abstract class GameState : IGameState
{
    public static readonly IGameState INIT_STATE = new InitState();
    public static readonly IGameState RUNNING_STATE = new RunningState();
    public static readonly IGameState PAUSE_STATE = new PauseState();
    public static readonly IGameState CURRENT = INIT_STATE;
    public virtual void OnEnter(GameStateBehaviour context) { }

    public virtual void OnExit(GameStateBehaviour context) { }

    public virtual void Update(GameStateBehaviour context) { }

    public virtual void ToState(GameStateBehaviour context, IGameState state)
    {
        CURRENT.OnExit(context);
        context.CURRENT = state;
        CURRENT.OnEnter(context);
    }
}

public class InitState : GameState
{
    public override void OnEnter(GameStateBehaviour context)
    {
        CURRENT.ToState(context, RUNNING_STATE);
    }
}

public class PauseState : GameState
{
    public override void OnEnter(GameStateBehaviour context)
    {
        Time.timeScale = 0f;
    }

    public override void OnExit(GameStateBehaviour context)
    {
        Time.timeScale = 1f;
    }
}

public class RunningState : GameState
{

}

public class GameStateBehaviour : MonoBehaviour, IGameState
{
    
    public IGameState CURRENT = GameState.CURRENT;

    private void Start()
    {
        CURRENT.ToState(this, GameState.INIT_STATE);
    }

    public void Pause()
    {
        CURRENT.ToState(this, GameState.PAUSE_STATE);
    }

    public void UnPause()
    {
        CURRENT.ToState(this, GameState.RUNNING_STATE);
    }
    private void Update()
    {
        CURRENT.Update(this);
    }


    public void OnEnter(GameStateBehaviour context)
    {
        throw new NotImplementedException();
    }

    public void OnExit(GameStateBehaviour context)
    {
        throw new NotImplementedException();
    }

    public void Update(GameStateBehaviour context)
    {
        throw new NotImplementedException();
    }

    public void ToState(GameStateBehaviour context, IGameState state)
    {
        throw new NotImplementedException();
    }
}