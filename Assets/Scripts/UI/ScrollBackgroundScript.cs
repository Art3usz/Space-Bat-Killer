using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackgroundScript : MonoBehaviour
{
    public float speedScrolling = 0;
    Renderer renderer2;
    // Start is called before the first frame update
    void Start()
    {
        renderer2 = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(speedScrolling/10f * Time.time, 0f);
        renderer2.material.mainTextureOffset = offset;
    }
}
