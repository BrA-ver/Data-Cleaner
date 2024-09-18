using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    public Enemy enemy;

    private void Start()
    {
        SwitchState(new EnemyChaseState(enemy ,this, "move"));
        
    }
}
