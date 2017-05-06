using System;
using System.Collections.Generic;

using UnityEngine;

public enum GameState
{
    Init = 0,

    Running = 1,

    Paused = 2,

    Exit = 3
}

public class GameStateBehaviour : MonoBehaviour
{
    private static readonly int EXIT = Animator.StringToHash("EXIT");

    private static readonly int INIT = Animator.StringToHash("INIT");

    private static readonly int PAUSED = Animator.StringToHash("PAUSED");

    private static readonly int RUNNING = Animator.StringToHash("RUNNING");

    public GameState current;

    private readonly Dictionary<GameState, List<GameState>> valids =
        new Dictionary<GameState, List<GameState>>
        {
            {
                GameState.Init,
                new List<GameState> { GameState.Running }
            },
            {
                GameState.Running,
                new List<GameState>
                    {
                        GameState.Paused
                    }
            },
            {
                GameState.Paused,
                new List<GameState>
                    {
                        GameState.Running,
                        GameState.Exit
                    }
            },
            { GameState.Exit, new List<GameState>() }
        };

    public interface IStateHandler
    {
        void ToState(IStateHandler state);

        void Update(IStateHandler state);
    }

    public void Pause()
    {
        if(ChangeState(GameState.Paused))
        {
            Time.timeScale = 0;
        }

        else if (ChangeState(GameState.Running))
        {
            Time.timeScale = 1;
            
        }
    }

    // Use this for initialization
    private void Awake()
    {
        current = GameState.Init;
    }

    private bool ChangeState(GameState state)
    {
        if(!valids.ContainsKey(state))
        {
            Debug.LogError(state + " is not in dictionary");
            return false;
        }

    
            if (!valids[current].Contains(state))
            {
                Debug.LogError(string.Format("can not transition to {0} from {1}", state, current));
                return false;
            }
    

        Debug.Log(string.Format("valid::transition to {0} from {1}", state, current));
         

        current = state;
        return true;
    }

    private void Start()
    {
        ChangeState(GameState.Running);
    }
    
}