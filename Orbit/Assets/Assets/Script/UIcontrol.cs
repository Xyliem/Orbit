using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

public class UIcontrol : MonoBehaviour
{
    public Vector2 joystickVector;
    protected Joystick joystick;
    public PlayMakerFSM FSM;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    void Update()
    {
        joystickVector = new Vector2(joystick.Horizontal, joystick.Vertical);
        // FSM.FsmVariables.GetFsmVector2("joyInp").Value = joystickVector;
    }
}
