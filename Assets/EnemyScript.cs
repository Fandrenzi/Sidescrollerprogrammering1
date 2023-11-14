using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
   

    public float MovmentSpeedPerSecond = 10.0f;
    public float MovmentSign = 1.0f;

    public Rigidbody2D myRigidBody = null;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //copy character velocity from rigidbofy
        Vector3 characterVelocity = myRigidBody.velocity;

        //sett character velocity to 0
        characterVelocity.x = 0;

        //add velocity in character right direktion
        characterVelocity += MovmentSign * MovmentSpeedPerSecond * transform.right.normalized;

        //copy modfied velocity bakc onto rigidbody
        myRigidBody.velocity = characterVelocity;
    }
}