using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StrengthText : MonoBehaviour
{
    TextMeshPro strengthText;
    // Start is called before the first frame update
    void Start()
    {
        //strengthText = GameObject.Find("UI_Manager").transform.Find("Strength").gameObject.GetComponent<TextMeshPro>();
        strengthText = gameObject.GetComponent<TextMeshPro>();
        DontDestroyOnLoad(strengthText);
    }

    // Update is called once per frame
    void Update()
    {
        strengthText.text = "Strength: x" + Player.strength;
    }
}
