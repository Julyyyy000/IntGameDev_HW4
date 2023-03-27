using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectBehavior : MonoBehaviour
{

    public GameObject player;
    SpriteRenderer renderer;
    Color newColor;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        newColor = renderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerControl>().canShoot)
        {
            newColor.a = 0.4f;
        } else
        {
            newColor.a = 1f;
        }
        renderer.color = newColor;
    }
}
