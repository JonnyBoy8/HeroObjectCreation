using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    Vector3 pos;
    public bool KeyBoardMode = false;

    [SerializeField]
    public float kHeroSpeed;

    [SerializeField]
    public float kHeroRotateSpeed;

    //egg variables
    public Transform EggSpawn;
    public GameObject EggPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("mouse mode");
    }

    // Update is called once per frame
    void Update()
    {
        //starts off in non keyboard mode
        if(!KeyBoardMode)
        {
            if(Input.GetKey(KeyCode.M))
            {
                KeyBoardMode = true;
                Debug.Log("Switching to Keyboard Mode");
                return;
            }

            //plane follows cursor
            pos = Input.mousePosition;
            pos.z = 1f;
            transform.position = Camera.main.ScreenToWorldPoint(pos);

            //AD rotate
            kHeroRotateSpeed = 45f; //change to per seconds
            float rotateInput = Input.GetAxis("Horizontal");
            float angle = rotateInput * (kHeroRotateSpeed * Time.smoothDeltaTime);

            transform.Rotate(transform.forward, angle);

            if(Input.GetKey(KeyCode.Space))
            {

            }
        }
        else
        {
            if(Input.GetKey(KeyCode.M))
            {
                KeyBoardMode = false;
                Debug.Log("Switching to mouse mode");
                return;
            }

            KeyBoardSettings();
        }
    }

    private void KeyBoardSettings()
    {
        //kHeroSpeed = 20f;
        kHeroRotateSpeed = 45f; 

        transform.position += transform.up * (kHeroSpeed * Time.smoothDeltaTime);
        if(Input.GetKey(KeyCode.W))
        {
            kHeroSpeed += .025f;
        }

        if(Input.GetKey(KeyCode.S))
        {
            kHeroSpeed -= .025f;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position += horizontalInput * transform.right * (kHeroSpeed * Time.smoothDeltaTime);

        float angle = (-1f * horizontalInput) * (kHeroRotateSpeed * Time.smoothDeltaTime);
        //transform.rotate.z = angle;
        transform.Rotate(transform.forward, angle);

        if((Input.GetKey(KeyCode.Space)))
        {
            Debug.Log("Egg Spawn");
        }
    }

    private void BulletSpawn()
    {

    }
}
