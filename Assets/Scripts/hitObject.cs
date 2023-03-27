using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitObject : MonoBehaviour
{

    public float moveDistance = 10f;

    float maximumPosition;
    float minimumPosition;

    public float moveSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        maximumPosition = transform.position.y + moveDistance;
        minimumPosition = transform.position.y - moveDistance;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        if ((newPos.y >= maximumPosition && moveSpeed > 0) || (newPos.y <= minimumPosition && moveSpeed <0))
        {
            moveSpeed *= -1;
        } else
        {
            newPos.y += moveSpeed * Time.deltaTime;
            transform.position = newPos;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("shoot"))
        {
            Destroy(collision.gameObject);
            //Debug.Log(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
