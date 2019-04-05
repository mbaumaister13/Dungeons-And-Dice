using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StrengthText : UIManager
{
    TextMeshPro strengthText;
    // Start is called before the first frame update
    void Start()
    {
        //strengthText = GameObject.Find("UI_Manager").transform.Find("Strength").gameObject.GetComponent<TextMeshPro>();
        strengthText = GetComponent<TextMeshPro>();
        DontDestroyOnLoad(strengthText);
    }

    // Update is called once per frame
    void Update()
    {
        strengthText.text = "Strength: x" + player.strength;
    }
}
