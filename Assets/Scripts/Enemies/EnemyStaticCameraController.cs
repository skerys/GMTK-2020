﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStaticCameraController : MonoBehaviour
{
    [SerializeField]
    [Header("Turning settings")]
    [Range(0, 360)]
    float angle = 90f;
    float angleR;
    float angleL;
    float angleStep;

    private float currentRotation = 0f;
    [SerializeField] float speed = 2f;
    [SerializeField] bool startRotatingToRight = true;
    //[SerializeField] float spottedPauseTime = 0f;
    [SerializeField] float changeDirectionPauseTime = 3f;
    //[SerializeField] Vector3 eulerAnglesDEBUG;
    [SerializeField] bool notAlternatingDirection;
    public bool pauseRotation = false;
    // Start is called before the first frame update
    void Start()
    {
        currentRotation = transform.eulerAngles.y;
        angle = notAlternatingDirection ? angle : angle / 2;
        angleStep = angle;
        angleR = angle + currentRotation;
        angleL = angle - currentRotation;


        if (startRotatingToRight)
            speed = Mathf.Abs(speed);
        else
            speed = Mathf.Abs(speed) * -1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // eulerAnglesDEBUG = gameObject.transform.eulerAngles;
        // direction
        if (!pauseRotation)
        {
            if (true)
            {

                gameObject.transform.Rotate(new Vector3(0f, speed, 0f));

                if (currentRotation >= angleR && speed > 0)
                {
                    
                    if (changeDirectionPauseTime > 0f)
                    {
                        StartCoroutine(Pause(changeDirectionPauseTime));
                    }
                    else
                        speed *= notAlternatingDirection ? 1f : -1f; // toggle direction


                }
                if (currentRotation <= -angleL && speed < 0)
                {
                    
                    if (changeDirectionPauseTime > 0f)
                    {
                        StartCoroutine(Pause(changeDirectionPauseTime));
                    }
                    else
                        speed *= notAlternatingDirection ? 1f : -1f; // toggle direction
                }
                currentRotation += speed;
            }
        }     
    }

    IEnumerator Pause(float time)
    {
        var temp = speed;
        speed = 0f;
        yield return new WaitForSeconds(time);
        if (notAlternatingDirection)
        {
            angleR += angleStep;
            angleL += angleStep;
            speed = temp;
        }
        else
        {
            speed = temp * -1f;
        }
    }

    public void TogglePauseRotation()
    {
        if (pauseRotation)
            pauseRotation = false;
        else
            pauseRotation = true;
    }
}
