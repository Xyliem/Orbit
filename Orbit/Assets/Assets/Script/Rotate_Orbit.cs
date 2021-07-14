using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

public class Rotate_Orbit : MonoBehaviour
{
    Joystick joystick;
    Vector3 moveVector;
    public float power;
    Quaternion quaternion;
    public PlayMakerFSM FSM;


    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }
    void Update()
    {
        power = Mathf.Abs(joystick.Vertical) + Mathf.Abs(joystick.Horizontal);
        FSM.FsmVariables.GetFsmFloat("inpPower").Value = power;

        moveVector = (Vector3.up * joystick.Vertical + Vector3.left* joystick.Horizontal);
        if(power >= 0.3){
            quaternion = Quaternion.LookRotation(Vector3.forward, moveVector);
            transform.rotation = quaternion;
            transform.eulerAngles = new Vector3(0,transform.eulerAngles.z,0);
        }
    }
}
