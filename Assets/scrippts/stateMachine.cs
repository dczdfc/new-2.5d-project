using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateMachine : MonoBehaviour
{
    public state currentState;


    public state moveSt;
    public state attack;
    // Start is called before the first frame update
    void Start()
    {
        currentState = moveSt;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
		{
			ChangeState(attack);
		}
        currentState.update();
    }
    void FixedUpdate(){
        currentState.fixedupdate();

    }
    public void ChangeState(state newState)
    {
        currentState.exitState();
        currentState = newState;
        currentState.start();
    }
}
