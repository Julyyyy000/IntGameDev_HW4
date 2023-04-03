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

    AudioSource myAudio;
    public AudioClip congratsAudio;
    public AudioClip gameOverAudio;
    bool playedAudio = false;

    // Start is called before the first frame update
    void Start()
    {
        text = textObject.GetComponent<TextMeshProUGUI>();
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        //Debug.Log(nextScene);
        if (nextScene)
        {
            
            if (scene.name == "Level1")
            {
                if (!myAudio.isPlaying)
                {
                    myAudio.clip = congratsAudio;
                    myAudio.Play();
                } 
                SceneManager.LoadScene("polishLevel2");
            }
            else if (scene.name == "polishLevel2")
            {
                if (!myAudio.isPlaying && !playedAudio)
                {
                    myAudio.clip = congratsAudio;
                    myAudio.Play();
                    playedAudio = true;
                }
                text.text = "Congratulations!";
                textObject.SetActive(true);
            }
        }

        if (player.transform.position.y < -16f)
        {
            //if game over
            if (!myAudio.isPlaying)
            {
                myAudio.clip = gameOverAudio;
                myAudio.Play();
            }
            
            textObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(scene.name);
            }
        }
    }
}
