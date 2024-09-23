using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] public PlayerController player;
    [SerializeField] public EnemyManager enemyManager;
    [SerializeField] public WaveSpawner waveSpawner;

    [Header("UI Elements")]
    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public GameObject upgradeMenu;
    
    [SerializeField] private List<BaseGameState> states = new List<BaseGameState>();
    private BaseGameState currentState;

    private void Start()
    {
        // Start in Playing Game State
        SwitchState<PlayingGameState>();
    }

    public void SwitchState<TNextState>()
    {
        foreach (BaseGameState state in states)
        {
            if (state.GetType() == typeof(TNextState))
            {
                currentState?.ExitState(this);
                currentState = state;
                state.EnterState(this);
                return;
            }
        }
        Debug.Log("State not found");
    }

    private void Update()
    {
        currentState?.UpdateState(this);
    }

    private void FixedUpdate()
    {
        currentState?.FixedUpdateState(this);
    }
}
