using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehavior : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitinfo)
    {
        Debug.Log(hitinfo.name);
        Destroy(gameObject);
    }
}
