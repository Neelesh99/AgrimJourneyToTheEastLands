using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private string emotion;
    public float playerSpeed;
    public GameObject chiball;
    public float ballFreq;
    private float chiCount = 0;
    private int lives = 3;
    SpriteRenderer m_SpriteRenderer;
    Sprite anger, sad, happy, neutral;
    TextAsset textFile;
    // Use this for initialization
    void Start()
    {
        anger = Resources.Load<Sprite>("Sprites/monk-anger");
        sad = Resources.Load<Sprite>("Sprites/monk-sad");
        happy = Resources.Load<Sprite>("Sprites/monk-happy");
        neutral = Resources.Load<Sprite>("Sprites/monk-neutral");
        textFile = Resources.Load<TextAsset>("Filed");
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //emotion = System.IO.File.ReadAllText("Resources");
        emotion = textFile.text;
        chiCount += Time.deltaTime;
        if (chiCount >= 1 / ballFreq)
        {
            chiCount = 0;
            Instantiate(chiball, transform.position, Quaternion.identity);
        }
        switch (emotion)
        {
            case "Happiness":
                m_SpriteRenderer.sprite = happy;
                break;
            case "Sadness":
                m_SpriteRenderer.sprite = sad;
                break;
            case "Neutral":
                m_SpriteRenderer.sprite = neutral;
                break;
            case "Anger":
                m_SpriteRenderer.sprite = anger;
                break;
        }
    }

    public void moveUp()
    {
        transform.Translate(playerSpeed * Vector2.up * Time.deltaTime);
    }

    public void moveDown()
    {
        transform.Translate(playerSpeed * Vector2.down * Time.deltaTime);
    }
}