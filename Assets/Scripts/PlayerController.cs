using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text scoreText;
    public float speed;
    public int health = 5;
    private int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    //this is the player movement method

    void PlayerMovement()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);        
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S)) 
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A)) 
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D)) 
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        { 
            score = score + 1;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Trap"))
        {
           health = health - 1;
            Debug.Log("Health: " + health); 
        }
        if (other.gameObject.CompareTag("Goal")) 
        {
            Debug.Log("You win!");
        }
        SetScoreText();
    }

    void SetScoreText() 
    {
        scoreText.text = "Score: " + score.ToString();
    }

}
