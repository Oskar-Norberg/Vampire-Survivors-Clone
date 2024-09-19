using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private List<BaseGameState> states = new List<BaseGameState>();
    private BaseGameState currentState;
    private void Start()
    {
        // Start in Playing Game State
        foreach (BaseGameState state in states)
        {
            if (state.GetType() == typeof(PlayingGameState))
            {
                currentState = state;
            }
        }
    }

    public void SwitchState<TNextState>()
    {
        foreach (BaseGameState state in states)
        {
            if (state.GetType() == typeof(TNextState))
            {
                currentState?.ExitState();
                currentState = state;
                state.EnterState();
                return;
            }
        }
        Debug.Log("State not found");
    }
}
