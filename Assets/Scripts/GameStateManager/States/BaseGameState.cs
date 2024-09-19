using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGameState : MonoBehaviour
{
    public abstract void EnterState();
    
    public abstract void ExitState();
    
    public abstract void FixedUpdateState(GameStateManager gameStateManager);

    public abstract void UpdateState(GameStateManager gameStateManager);
}
