using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Camera cam;
    [Range(0,1)]
    public float parallaxEffect;
    float xpos, ypos, zpos;

    void Start()
    {
        xpos = transform.position.x;
        ypos = transform.position.y;
        zpos = transform.position.z;
    }

    void Update()
    {
        float xDiff = parallaxEffect * cam.transform.position.x;
        transform.position = new Vector3(xpos + xDiff, ypos, zpos);
    }
}
