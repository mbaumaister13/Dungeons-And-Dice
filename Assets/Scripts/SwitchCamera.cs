using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    Rigidbody rb;
    public UIManager uiManager;
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        uiManager.Disable("DiceUI");
        uiManager.Disable("Health");
        uiManager.Disable("Strength");
        uiManager.Disable("Gold");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeInHierarchy && rb.IsSleeping()){
            gameObject.SetActive(false);
            cam.SetActive(true);
            uiManager.Enable("DiceUI");
            uiManager.Enable("Health");
            uiManager.Enable("Strength");
            uiManager.Enable("Gold");
        }
    }
}
