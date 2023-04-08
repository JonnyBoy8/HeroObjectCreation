using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehavior : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (GlobalBehavior.sTheGlobalBehavior.ObjectCollideWorldBound(GetComponent<Renderer>().bounds) == GlobalBehavior.WorldBoundStatus.Outside)
        {
            Destroy(gameObject);  // this.gameObject, this is destroying the game object
            GlobalBehavior.sTheGlobalBehavior.DecreaseEggCountUI();
        }
    }

    private void OnTriggerEnter2D(Collider2D hitinfo)
    {
        if(hitinfo.name == "Plane")
        {
            Destroy(gameObject);
            GlobalBehavior.sTheGlobalBehavior.DecreaseEggCountUI();
        }
    }
}
