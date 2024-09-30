using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet Hodlder", menuName ="Bullet Holder")]
public class BulletHolder : ScriptableObject
{
    public Bullet bullet;
    public float shootForce = 15f;

}
