using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //bullet speed
    public float speed = 500.0f;
    //when the bullet disappear if missed an object
    public float maxLifetime = 10.0f;
    //reference to our rigbody
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();   
    }
   
    public void Project(Vector2 direction)
    {
        //Making sure the collision are able to work for the bullet and what we want it to do 
        _rigidbody.AddForce(direction * this.speed);
        // when the bullet is fired its gong to add the force to start moving it and also tell it to destroy the bullet after
        Destroy(this.gameObject, this.maxLifetime);
    }
   // this is so the bullet can get detroyed on impact
    private void OnCollisionEnter2D(Collision2D collision)
    {
       Destroy(this.gameObject);
    }
}
