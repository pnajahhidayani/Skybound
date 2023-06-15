using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float speed = 20;
    private float turnSpeed = 45;
    public float horizontalInput;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI timeText;
    private float timeElapsed;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayEngineSound(gameObject);
        scoreText.gameObject.SetActive(true);
        scoreText.text = "Score: " + score;
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (!gameOver.activeSelf) // Check if game over screen is not active
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Coin")) {
            score++;
            Destroy(other.gameObject);
            scoreText.text = "Score: " + score;
            AudioManager.instance.PlayCoinSound();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameOver.SetActive(true);
            finalScoreText.text = "Score: " + score;
            timeText.text = "Time: " + Mathf.RoundToInt(timeElapsed) + "s";
            scoreText.gameObject.SetActive(false);
            AudioManager.instance.StopEngineSound(gameObject);
            AudioManager.instance.PlayExplosionSound();
        }
    }
}
