using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameManagerScript gameManager;
    public Bullet bulletPrefab;
    //player speed
    public float speed = 10.4f;

    private bool isDead;

    public AudioSource DeathSound;
    public AudioSource BulletSound;

    // Particle System
    public ParticleSystem explosionParticle;




    // Update is called once per frame
    void Update()
    {
        //all our keybinds
        Vector3 pos = transform.position;  
        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;    
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime; 
        }
        transform.position = pos;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            BulletSound.Play();
            Shoot();
        }

    }
    private void Shoot()
    {
        // everytime the player shoots it will instantiate a new bullet
        // we put the object we want to clone in the instantiate 
        // This also says that the bullet will spawn at the same position of the player
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
           
          this.gameObject.SetActive(false);
            DeathSound.Play();
            Destroy(this.gameObject);
            Instantiate(explosionParticle, transform.position, Quaternion.identity);
            gameManager.gameOver();
            isDead = true;
        }
    }
   
}
