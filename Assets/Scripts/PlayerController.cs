using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEditor.SearchService;

public class PlayerController : MonoBehaviour
{
    public void PlayMaze()
    {
        if (Input.GetKeyUp(KeyCode.Escape))

        {
            SceneManager.LoadScene(0);
        }
    }
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
        if (LoseImage != null)
        {
            LoseImage.enabled = false;
        }
        if (LoseText != null)
        {
            LoseText.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayMaze();
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

        if (health == 0) 
        {
            StartCoroutine(LoadScene(3));
            SetLoseText();
            SetLoseImage();
            if (LoseImage != null)
            {
                LoseImage.enabled = true;
            }
            if (LoseText != null)
            {
                LoseText.enabled = true;
            }

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
            StartCoroutine(LoadScene(3));
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
        WinText.text = "You Win!";
        WinText.color = Color.black;
    }

    void SetLoseText()
    {
        LoseText.text = "Game Over!";
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

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
