using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    public Transform Waypoint1;
    public Transform Waypoint2;
    public Transform Waypoint3;
    public Transform Waypoint4;
    public Transform Waypoint5;
    public float Timer = 0f;

    public float Velocity;
    private Vector3 Mover;
    public bool movimiento = false;

    void Start()
    {
        transform.position = Waypoint1.position;
        Mover = Waypoint2.position;

    }


    void Update()
    {
        //Coche 1

        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Mover, Velocity * Time.deltaTime);

        if (gameObject.transform.position == Waypoint1.position && movimiento == true)
        {
            Timer = Timer + Time.deltaTime;
            if (Timer > 3f)
            {
                movimiento = false;
                Mover = Waypoint2.position;
                Timer = 0f;
            }


        }

        if (gameObject.transform.position == Waypoint2.position && movimiento == false)
        {

            Timer = Timer + Time.deltaTime;
            if (Timer > 2f)
            {
                movimiento = true;
                Mover = Waypoint1.position;
                Timer = 0f;
            }

        }
    }

}

