using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraConfiner : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player Enter");
        CameraManager.Instance.SetCameraConfiner(GetComponent<BoxCollider>());
    }
}
