using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool nextScene = false;

    public GameObject player;
    TextMeshProUGUI text;
    public GameObject textObject;
    // Start is called before the first frame update
    void Start()
    {
        text = textObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(nextScene);
        if (nextScene)
        {
            if (scene.name == "Level1")
            {
                SceneManager.LoadScene("Level2");
            }
            else if (scene.name == "Level2")
            {
                text.text = "Congratulations!";
                textObject.SetActive(true);
            }
        }

        if (player.transform.position.y < -16f)
        {
            //if game over
            textObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(scene.name);
            }
        }
    }
}
