using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public delegate void OnPauseDelegate();
    public static event OnPauseDelegate onPause;
    
    public delegate void OnResumeDelegate();
    public static event OnResumeDelegate onResume;
    
    [Header("Managers")]
    [SerializeField] public PlayerController player;
    [SerializeField] public EnemyManager enemyManager;
    [SerializeField] public WaveSpawner waveSpawner;
    [SerializeField] public RoundTimer roundTimer;

    [Header("UI Elements")]
    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public GameObject upgradeMenu;
    [SerializeField] public GameObject gameOverMenu;
    
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
    
    public void Pause()
    {
        onPause?.Invoke();
    }

    public void Resume()
    {
        onResume?.Invoke();
    }

    public void GoToMainMenu()
    {
        currentState?.ExitState(this);
        currentState = null;
        SceneManager.LoadScene("Main Menu");
    }
}
