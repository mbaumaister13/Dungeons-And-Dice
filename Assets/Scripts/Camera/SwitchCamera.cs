using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    Rigidbody rb;
    public MeterManager meterManager;
    public GameObject cam;
    public Dice dice;
    // Start is called before the first frame update
    void Start()
    {
        meterManager.Disable("PlayerMeters");
        meterManager.Disable("DiceUI");
        //dice.gameObject.SetActive(false);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeInHierarchy && rb.IsSleeping()){
            gameObject.SetActive(false);
            cam.SetActive(true);
            meterManager.Enable("DiceUI");
            meterManager.Enable("PlayerMeters");
            //dice.gameObject.SetActive(true);
        }
    }
}
