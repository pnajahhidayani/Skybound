using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
  public GameObject aboutPanel;
  public GameObject mainPanel;

  public void StartBtn() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  public void QuitBtn() {
    Application.Quit();
  }

  public void AboutBtn() {
    aboutPanel.SetActive(true);
    mainPanel.SetActive(false);
  }
}
