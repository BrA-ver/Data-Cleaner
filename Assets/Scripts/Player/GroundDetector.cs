using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float detectRadius;
    // Start is called before the first frame update
    
    public bool GroundCheck()
    {
        // Check for overlap with the ground layer
        bool onGround = Physics.CheckSphere(transform.position, detectRadius, groundLayer);
        return onGround;
    }

    private void OnDrawGizmos()
    {
        if (GroundCheck())
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.white;
        }
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}
