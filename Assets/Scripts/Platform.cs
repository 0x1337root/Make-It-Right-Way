using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    bool isRight = false;

    bool isLeft = false;

    float speed = 0.005f;

    float touchPosDelta;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                touchPosDelta = touch.deltaPosition.x;

                if(touchPosDelta < 0)
                {
                    isLeft = true;
                }

                if(touchPosDelta > 0)
                {
                    isRight = true;
                }
            }

            if(touch.phase == TouchPhase.Stationary)
            {
                isLeft = false;
                isRight = false;
            }

            if(touch.phase == TouchPhase.Ended)
            {
                isLeft = false;
                isRight = false;
            }
        }

        if (Input.GetKey("right"))
        {
            isRight = true;
        }

        if (Input.GetKey("left"))
        {
            isLeft = true;
        }

        if (Input.GetKeyUp("right"))
        {
            isRight = false;
        }

        if (Input.GetKeyUp("left"))
        {
            isLeft = false;
        }
    }

    void FixedUpdate()
    {
        if (isRight)
        {
            transform.Translate(Vector3.right * speed * touchPosDelta);
        }

        if (isLeft)
        {
            transform.Translate(Vector3.left * speed * -touchPosDelta);
        }
    }
}
