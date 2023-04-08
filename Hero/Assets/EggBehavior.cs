using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehavior : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitinfo)
    {
        if(hitinfo.name == "Plane")
        {
            Destroy(gameObject);
        }
    }
}
