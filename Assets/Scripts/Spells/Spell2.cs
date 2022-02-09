using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell2 : MonoBehaviour
{
    Rigidbody rb;
    public float bulletForce;
    bool firstTime = false;
    Vector3 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void SetDirection(Vector3 dir)
    {
        direction = dir;
        firstTime = true;
    }

    void OnCollisionEnter()
    {
        //code for when bullet hits something
    }

    void FixedUpdate()
    {
        if (firstTime)
        {
            rb.AddForce(direction * bulletForce);
            firstTime = false;
        }
    }
}
