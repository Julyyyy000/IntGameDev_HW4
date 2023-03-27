using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMovement : MonoBehaviour
{
    public Camera camera;
    float halfHeight;
    float halfWidth;
    float oneAndHalfWidth;
    float startPos;

    public int index;

    // Start is called before the first frame update
    void Start()
    {
        halfHeight = camera.orthographicSize;
        halfWidth = camera.aspect * halfHeight;
        oneAndHalfWidth = halfWidth * 2 + halfWidth;

        Vector3 size = GetComponent<Renderer>().bounds.size;
        float width = size.x;

        Vector3 startPos = transform.position;
        startPos.x = camera.transform.position.x + index * (2 * halfWidth);
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 cameraPos = camera.transform.position;

        //pos.y = cameraPos.y;

        if (pos.x <= cameraPos.x - oneAndHalfWidth)
        {
            pos.x = pos.x + oneAndHalfWidth * 2;
        } else if (pos.x >= cameraPos.x + oneAndHalfWidth)
        {
            pos.x = pos.x - oneAndHalfWidth * 2;
        }

        transform.position = pos;
    }
}
