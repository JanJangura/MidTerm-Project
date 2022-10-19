using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployAsteroids : MonoBehaviour
{
    // The is creating a reference for our Asteroid prefab
    public GameObject asteroidPrefab;
    // This is used to tell our function how often we want to spawn asteroids
    public float respawnTime = 1.0f;
    private Vector2 screenBounds; // ALEX SAVE
    // Start is called before the first frame update
    void Start()
    {
        // Since our object is moving from right to left we have to place our object to the right of the screen meaning we use the same screenbounds from the previous script
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        // This sets up a way for us to call the spawn enemy function
        StartCoroutine(asteroidWave());
    }
    // Use to spawn our asteroids
    private void spawnEnemy()
    {
        // Using Instantiate loads our prefab onto the scene
        //a = our reference
        // asteroidsPefab is our parameter so it will know what to clone
        // We are also cloning this as a gameobject
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        // This modify our asteroids position
        // We used -2 to place the asteroid off the screen towards the right
        // Random Range is for our asteroids to be place at random cordinates on the screen
        a.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));   
    }
    //In order to make ths a quarantine we need to add IEnumerator in front of the function
  IEnumerator asteroidWave()
    {
        // This gets our function to loop every one second
        while (true) {
            // We use our respawn time to let the game know how long we want to wait which is 1 second
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}
