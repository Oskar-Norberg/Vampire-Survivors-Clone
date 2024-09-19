using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private List<BaseGameState> states = new List<BaseGameState>();
    private BaseGameState currentState;
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
