using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public static bool playerOneIsPlaying;
    public static bool playerTwoIsPlaying;
    
    private void Update()
    {
        if (playerOneIsPlaying && playerTwoIsPlaying)
        {
            StartCoroutine(ChangeScene());
        }
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
}
