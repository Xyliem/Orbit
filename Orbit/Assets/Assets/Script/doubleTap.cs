using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using HutongGames.PlayMaker;

public class doubleTap : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PlayMakerFSM fsm;
    public void OnPointerDown(PointerEventData eventData)
    {
        fsm.FsmVariables.GetFsmBool("touch").Value = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        fsm.FsmVariables.GetFsmBool("touch").Value = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
