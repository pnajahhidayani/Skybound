using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

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
    public ContinuousMoveProviderBase continousMoveProvider;
    public bool isGameStart;
    public

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.StopMenuBGM();
        AudioManager.instance.PlayGameBGM();
        Invoke("StartGame", 3);
        continousMoveProvider.enabled = true;
        AudioManager.instance.PlayEngineSound(gameObject);
        scoreText.gameObject.SetActive(true);
        scoreText.text = "Score: " + score;
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (!gameOver.activeSelf && isGameStart) // Check if game over screen is not active
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }
    }

    void StartGame()
    {
        isGameStart = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            score++;
            Destroy(other.gameObject);
            scoreText.text = "Score: " + score;
            AudioManager.instance.PlayCoinSound();
        }
        else if (other.gameObject.CompareTag("Boost"))
        {
            StartCoroutine(BoostCoroutine());
            Destroy(other.gameObject);
            AudioManager.instance.PlayBoostSound();
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
            continousMoveProvider.enabled = false;
        }
    }

    IEnumerator BoostCoroutine()
    {
        speed += 5;
        yield return new WaitForSeconds(3);
        speed -= 5;
    }
}
