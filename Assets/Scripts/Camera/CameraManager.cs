using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;
    CinemachineConfiner CinemachineConfiner;
    BoxCollider box;

    private void Awake()
    {
        Instance = this;
        CinemachineConfiner = GetComponentInChildren<CinemachineConfiner>();
        box = GetComponent<BoxCollider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(CinemachineConfiner.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCameraConfiner(BoxCollider collider)
    {
        CinemachineConfiner.m_BoundingVolume = collider;
    }
}
