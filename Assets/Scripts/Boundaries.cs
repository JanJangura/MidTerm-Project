using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    //This helps so that the entire player is in the boundary not half of it
    private float objectWidth;
    private float objectHeight;
    // Start is called before the first frame update
    void Start()
    {
        // This is our screen boundaries in world space
        //This gives us an x and y value that would be half of the screen width and half the screen height
        // Example if the a screen is 8 units wide and 6 units high, x = 4 and y = 3 
        // The screen coordinate system is actually reverse so it would be negative instead of positive
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //The spriterender called bounds.size is use to find the boundaries of our object
        // We divided by negative 2 because we only need to know what half our object dimensions are since our object is being clamp using the center of the player
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x/2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y/2;   
    }

    // Update is called once per frame
    // we rename this to late update because its called directly after our movement 
    void LateUpdate()
    {
        // This is so we can alter our objects x and y coorinates
        Vector3 viewPos = transform.position;
        // Here we are clamping our current x and y position to the screen boundaries x and y position
        // we use the current value a negative number to be used for our minimum value 
        // we reverse the value to make it positive for our maximum value
        // we added our object to our minimum value and substracted it from our maximum
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + objectWidth, screenBounds.x * -1 - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + objectHeight, screenBounds.y * -1 - objectHeight);
        //This equals our new alter position
        transform.position = viewPos;
    }
}
