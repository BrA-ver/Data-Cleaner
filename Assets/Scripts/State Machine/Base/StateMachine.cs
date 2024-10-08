using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine 
{
    public State currentState;

    public void SwitchState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }
}
