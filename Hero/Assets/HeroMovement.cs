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
    public Transform eggSpawnPoint;
    public GameObject eggPrefab;
    public float firerate = 0.5f;
    public float nextFire = 0f;

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
            float angle = (-1f * rotateInput) * (kHeroRotateSpeed * Time.smoothDeltaTime);

            transform.Rotate(transform.forward, angle);

            if(Input.GetKey(KeyCode.Space) && Time.time > nextFire)
            {
                EggSpawn();
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

        transform.Rotate(Vector3.forward, -1f * Input.GetAxis("Horizontal") * (kHeroRotateSpeed * Time.smoothDeltaTime));

        if((Input.GetKey(KeyCode.Space)) && Time.time > nextFire)
        {
            //Debug.Log("Egg Spawn");
            EggSpawn();
        }
    }

    private void EggSpawn()
    {
        GameObject eggbullet = Instantiate(eggPrefab, eggSpawnPoint.position, eggSpawnPoint.rotation);
        Rigidbody2D eggrb = eggbullet.GetComponent<Rigidbody2D>();

        eggrb.velocity = 40f * transform.up;
        nextFire = Time.time + firerate;
    }

    private void OnTriggerEnter2D(Collider2D hitinfo)
    {
        Debug.Log("Hero collided");
        if(hitinfo.name == "Plane")
        {
            hitinfo.gameObject.transform.position = Vector3.zero;
        }
    }

    private void OnTriggerStay2D(Collider2D hitinfo)
    {
        Debug.Log("Hero still colliding");
        if(hitinfo.name == "Plane")
        {
            hitinfo.gameObject.transform.position = Vector3.zero;
        }
    }
}
