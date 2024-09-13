using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet Hodlder", menuName ="Bullet Holder")]
public class BulletHolder : ScriptableObject
{
    public Bullet bullet;
    public int num;
    public int maxNum = 10;
    public float shootForce = 15f;

    public void Reload()
    {
        num = maxNum;
    }
}
