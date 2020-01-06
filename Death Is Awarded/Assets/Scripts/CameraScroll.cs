using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    public float scrollSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 cameraPos = transform.position;
        cameraPos.x += scrollSpeed * Time.deltaTime;
        transform.position = cameraPos;
    }
}
