using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    bool rightwall;
    public static int number = 10;
    int score;
    int highscore;
    public Text scoretext;
    public Text youscored;
    public Text texthighscore;
    public GameObject youlosecanvas;
    public GameObject gamecanvas;
    public GameObject playcanvas;
    public Collider2D birdcollider;
    public GameObject coliders;
    bool dead;
    bool ok;
    public GameObject congrats;
    public Animator anime;
    int continuethescore;

    void Awake()
    {
        texthighscore.text = PlayerPrefs.GetInt("HS", 0).ToString();
    }
    void Start()
    {
        score = 0;
        dead = false;
        rb.gravityScale = 0;
    }
    void Update()
    {
        scoretext.text = score.ToString();
        youscored.text = score.ToString();
        //highscore
        if (score > PlayerPrefs.GetInt("HS", 0))
        {
            anime.Play("newscore");
            PlayerPrefs.SetInt("HS", score);
            texthighscore.text = score.ToString();
        }
        //movement
        if (rightwall == true)
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (rightwall == false)
            transform.Translate(Vector2.right * speed * Time.deltaTime);

        //jump
        if (!dead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                coliders.SetActive(false);
                rb.gravityScale = 2;
                playcanvas.SetActive(false);
                rb.velocity = new Vector2(0, 8);
                gamecanvas.SetActive(true);             
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //rightwall
        if (other.tag == "rRight")
        {
            score++;
            rightwall = true;
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }
        //leftwall
        if (other.tag == "lLeft")
        {
            score++;
            rightwall = false;
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        //rightcolliderofanimation
        if (other.tag == "cRight")
        {
            rightwall = true;
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }
        //leftcolliderofanimation
        if (other.tag == "cLeft")
        {
            rightwall = false;
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        //obstacle
        if (other.tag == "obstacle")
        {
            birdcollider.enabled = !birdcollider.enabled;
            rb.gravityScale = 5f;
            speed = 0f;
            dead = true;
            gamecanvas.SetActive(false);
            youlosecanvas.SetActive(true);
        }
    }

}
