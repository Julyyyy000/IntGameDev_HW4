using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    public string direction = "left";
    public float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        if (direction == "left")
        {
            newPos.x -= speed * Time.deltaTime;
            transform.position = newPos;
        }

        if (direction == "right")
        {
            newPos.x += speed * Time.deltaTime;
            transform.position = newPos;
        }

        if (newPos.x > 13f || newPos.x < -18f)
        {
            gameObject.SetActive(false);
        }
    }

}
