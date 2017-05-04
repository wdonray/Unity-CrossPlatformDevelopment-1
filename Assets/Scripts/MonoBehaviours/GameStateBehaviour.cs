using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState
{
    Init = 0,
    Running = 1,
    Paused = 2,
    Exit = 3,
}

public class GameStateBehaviour : MonoBehaviour
{
    static readonly int RUNNING = Animator.StringToHash("RUNNING");
    static readonly int PAUSED = Animator.StringToHash("PAUSED");
    static readonly int INIT = Animator.StringToHash("INIT");
    static readonly int EXIT = Animator.StringToHash("EXIT");

    public Animator m_anim;
	
    GameState current;

    // Use this for initialization
    private void Awake ()
	{
	    m_anim = GetComponent<Animator>();
	    m_anim.SetTrigger(INIT);
	    current = GameState.Init;
    }

    private void Update()
    {
        
    }
    private bool ChangeState(GameState state)
    {
        switch (state)
        {
            case GameState.Init:
                return (state == GameState.Running);
            case GameState.Running:
                return (state == GameState.Paused);
            case GameState.Exit:
                break;
            case GameState.Paused:
                break;
            default:
                break;
        }
        current = state;
        return true;
    }
}
