using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    [SerializeField] LayerMask wallLayer;
    List<Wall> walls = new List<Wall>();

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, 10f, wallLayer))
        {
            Debug.Log("Wall");
            Debug.DrawRay(ray.origin, transform.forward * hit.distance, Color.yellow);

            Wall wall = hit.collider.GetComponent<Wall>();
            if (wall)
            {
                walls.Add(wall);
                wall.HideWall();
            }
            
            
        }
        else if (walls.Count > 0)
        {
            foreach (Wall wall in walls)
            {
                wall.ShowWall();
            }
        }
    }


}
