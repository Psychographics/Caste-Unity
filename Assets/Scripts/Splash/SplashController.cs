using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashControllers : MonoBehaviour
{
    public float wait_time = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForIntro());   
    }

    IEnumerator WaitForIntro()
    {
        yield return new WaitForSeconds(wait_time);

        SceneManager.LoadScene(1);
    }
}