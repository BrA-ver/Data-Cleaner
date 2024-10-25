using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Material wallMat;
    [SerializeField] Material tranparentMat;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        wallMat = meshRenderer.material;
    }

    public void HideWall()
    {
        meshRenderer.material = tranparentMat;
    }

    public void ShowWall()
    {
        meshRenderer.material = wallMat;
    }
}
