using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBox : MonoBehaviour
{
    TextMeshProUGUI boxText;
    Camera gameCam;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        boxText = GetComponentInChildren<TextMeshProUGUI>();
        gameCam = Camera.main;
    }

    private void Update()
    {
        if (gameCam)
        {
            transform.LookAt(gameCam.transform.position);
        }
    }

    public void SetText(string newText)
    {
        boxText.text = newText;
    }

    public void ActivateBox()
    {
        anim.SetTrigger("activate");
    }

    public void DeactivateBox()
    {
        anim.SetTrigger("deactivate");
    }
}
