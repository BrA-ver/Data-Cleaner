using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private TextBox textBox;
    [TextArea]
    public string tutorialMessage;

    private void Start()
    {
        textBox = GetComponentInChildren<TextBox>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!textBox) { return; }

        textBox.ActivateBox();
        textBox.SetText(tutorialMessage);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!textBox) { return; }

        textBox.DeactivateBox();
    }
}
