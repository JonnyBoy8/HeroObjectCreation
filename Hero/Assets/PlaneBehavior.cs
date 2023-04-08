using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D hitinfo)
    {
        Debug.Log(hitinfo.name);
        if(hitinfo.name == "Hero")
        {
            Destroy(gameObject);
            GlobalBehavior.sTheGlobalBehavior.UpdateEnemyDestroyUI();
            GlobalBehavior.sTheGlobalBehavior.UpdateHeroCollideUI();
            GlobalBehavior.sTheGlobalBehavior.ReduceEnemyCountUI();
            GlobalBehavior.sTheGlobalBehavior.CreatePlane();
        }
        else
        {
            UpdateColor();
        }
    }

    private void OnTriggerStay2D(Collider2D hitinfo)
    {
        if(hitinfo.name == "Hero")
        {
            Destroy(gameObject);
        }
    }

    private void UpdateColor()
    {
        Debug.Log("UPDATE COLOR CALLED");
        SpriteRenderer enemy = GetComponent<SpriteRenderer>();
        Color current_color = enemy.color;

        current_color.a -= 0.2f;
        enemy.color = current_color;

        if(current_color.a <= 0.0f)
        {
            GlobalBehavior.sTheGlobalBehavior.UpdateEnemyDestroyUI();
            GlobalBehavior.sTheGlobalBehavior.ReduceEnemyCountUI();
            Destroy(gameObject);
            GlobalBehavior.sTheGlobalBehavior.CreatePlane();
        }
    }
}
