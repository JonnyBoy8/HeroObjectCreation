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
            kHeroRotateSpeed = 90f;
            float rotateInput = Input.GetAxis("Horizontal");
            float angle = rotateInput * (kHeroRotateSpeed * Time.smoothDeltaTime);

            transform.Rotate(transform.forward, angle);
        }
        else
        {
            if(Input.GetKey(KeyCode.M))
            {
                KeyBoardMode = false;
                Debug.Log("Switching to mouse mode");
                return;
            }

            kHeroRotateSpeed = 360f;
            //either A,D or Left,Right arrows
            //right arrow = 1
            //left arrow = -1
            float horizontalInput = Input.GetAxis("Horizontal");
            if(Input.GetKey(KeyCode.W))
            {
                kHeroSpeed += .03f;
                Debug.Log("increasing speed");
            }

            if(Input.GetKey(KeyCode.S))
            {
                kHeroSpeed -= .03f;
                Debug.Log("decreasing speed");
            }

            //either W,S, or Up,Down arrows
            float verticalInput = Input.GetAxis("Vertical");

            // transform.position += verticalInput * transform.up * (kHeroSpeed * Time.smoothDeltaTime);
            // transform.position += horizontalInput * transform.right * (kHeroSpeed * Time.smoothDeltaTime);

            //direction we want character to move in
            Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);

            //store orginal magnitude in a range of only -1 to 1
            float OGMagnitude = Mathf.Clamp01(moveDirection.magnitude);

            //different inputs can lead to values over or less than 1. normalize so that
            //the input will always be -1 or 1
            moveDirection.Normalize();

            //actually moving the character
            transform.Translate(moveDirection * kHeroSpeed * OGMagnitude * Time.deltaTime, Space.World);

            //check if character is moving
            if(moveDirection != Vector2.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, kHeroRotateSpeed * Time.deltaTime);
            }
        }
    }

    void KeyBoardSettings()
    {

    }
}
