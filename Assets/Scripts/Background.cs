using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // using negative we are able to scroll our background in the opposite direction
    [Range(-1f,1f)]
    //How fast the background moves
    public float scrollSpeed = 0.5f;
    private float offset;
    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        // Material is populated
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        // This caculates our offset
        // we divided by 10 so we wont have a extremely fast scroll speed.
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        // Every material has a mainrtex
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
