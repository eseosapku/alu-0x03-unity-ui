using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Image WinImage;
    public Image LoseImage;
    public Text WinText;
    public Text LoseText;
    public Text healthText;
    public Text scoreText;
    public float speed;
    public int health = 5;
    private int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetScoreText();
        SetHealthText();
        if (WinImage != null)
        {
            WinImage.enabled = false;
        }
        if (WinText != null)
        {
            WinText.enabled = false;
        }
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
        }
        if (other.gameObject.CompareTag("Goal")) 
        {
            SetWinText();
            SetWinImage();
            if (WinImage != null)
            {
                WinImage.enabled = true;
            }
            if (WinText != null)
            {
                WinText.enabled = true;
            }
        }
        
        SetScoreText();
        SetHealthText();
    }

    void SetScoreText() 
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }

    void SetWinText()
    {
        WinText.text = "You Win";
        WinText.color = Color.black;
    }

    void SetLoseText()
    {
        LoseText.text = "You Lose";
        LoseText.color= Color.black;
    }

    void SetLoseImage()
    {
        LoseImage.color = Color.red;
    }

    void SetWinImage()
    {
        WinImage.color = Color.green;
    }

}
