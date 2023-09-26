using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactermover : MonoBehaviour
{
   
    void Start()
    {
        
    }
    public float Gravitypersecond = 160.0f;
    public float Groundlevel = 0.0f;

    public float MovementSpeedpersecond = 10.0f;
    void Update()
    {
        Vector3 Gravityposition = transform.position;
        Gravityposition.y -= Gravitypersecond * Time.deltaTime;
        if (Gravityposition.y < Groundlevel) { Gravityposition.y = Groundlevel; }
        transform.position = Gravityposition;

        //up
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 characterposition = transform.position;
            characterposition.y += MovementSpeedpersecond * Time.deltaTime;
            transform.position = characterposition;
        }

        //left
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 characterposition = transform.position;
            characterposition.x -= MovementSpeedpersecond * Time.deltaTime;
            transform.position = characterposition;
        }

        //down
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 characterposition = transform.position;
            characterposition.y -= MovementSpeedpersecond * Time.deltaTime;
            transform.position = characterposition;
        }

        //right
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 characterposition = transform.position;
            characterposition.x += MovementSpeedpersecond * Time.deltaTime;
            transform.position = characterposition;
        }

    }
}