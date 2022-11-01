using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    
    // This tells our speed how fast we want the object to move
    public float speed = 10.0f;
    private Rigidbody2D rb;
    // This is for our screenbounds caculation
    private Vector2 screenBounds;

    // Particle System
    public ParticleSystem explosionParticle;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>(); 
        // This will move our object right to left at a constant rate based on our speed value
        // We put y = 0 so the object wont move on the y axis
        rb.velocity = new Vector2 (- speed, 0);
        // Basically this defines the boundaries of our screen on an x and y axis
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
        
    {
        // This is making sure our Object x position is less than screenbounds.x
        // Which is also saying is it to the left of the screen
        if (transform.position.x < screenBounds.x * 2)
        {
            // This removes our game object from the scene
            Destroy(this.gameObject);
            
        }

        

    

    }
    // This is so our Bullets can destroy our asteroids on impact
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // we use tag Bullet so the game will know what object we want to destroy our asteroids
        if (collision.gameObject.tag == ("Bullet"))
        {
            
            Destroy(this.gameObject);
            // We'll instantiate particles by passing in our particile variable, the position of our game object, and then the  
            // current rotation of our game object.
            Instantiate(explosionParticle, transform.position, Quaternion.identity);
            ScoreManager.instance.AddPoint();
            
        }
    }

}
