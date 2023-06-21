using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollText : MonoBehaviour
{
    public Transform text;
    private bool isScroll;
    void Start()
    {
        Invoke("StartScroll", 1);
    }

    void Update()
    {
        if (isScroll)
        {

            text.transform.localPosition += new Vector3(0, 1, 0);
        }

        if (text.transform.localPosition.y > 1169)
        {
            isScroll = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void StartScroll()
    {
        isScroll = true;
    }
}
