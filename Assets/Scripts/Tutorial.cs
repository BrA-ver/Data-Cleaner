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
        AudioManager.Instance.PlaySFX("Pop Up");
    }

    private void OnTriggerExit(Collider other)
    {
        if (!textBox) { return; }

        textBox.DeactivateBox();
        AudioManager.Instance.PlaySFX("Pop Down");
    }
}
