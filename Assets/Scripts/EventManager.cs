using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void PlayerEvent();
    public static event PlayerEvent onPlayerEvent;  
    public delegate void DiceEvent();
    public static event DiceEvent onDiceEvent;  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(onPlayerEvent != null)
            onPlayerEvent();
            
        if(onDiceEvent != null)
            onDiceEvent();
    }
}
