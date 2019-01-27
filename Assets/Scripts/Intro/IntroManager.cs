using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public static bool playerOneIsPlaying;
    public static bool playerTwoIsPlaying;
    public TextMeshPro Message;
    public List<GameObject> turnoffGO;
    public float speed = 0.02f;

    private bool showingMessages;

    private List<string> messages = new List<string>()
    {
        "Mom died last month.\n Or maybe it was the month before.",
        "I decided to sell the old family house,\n a little dwelling in the suburbs.",
        "I haven't been there in years."
    };

    private void Update()
    {
        if (showingMessages)
            return;

        if (!playerOneIsPlaying || !playerTwoIsPlaying)
            return;
        
        StartCoroutine(ShowMessages());
        showingMessages = true;
    }

    private IEnumerator ShowMessages()
    {
        yield return new WaitForSeconds(2.5f);
        TurnOffAll();
        yield return new WaitForSeconds(1.0f);
        StartMessages();
    }

    private void TurnOffAll()
    {
        turnoffGO.ForEach(go => go.SetActive(false));
    }

    private void StartMessages()
    {
        StartCoroutine(ShowLettersNext());
    }

    private IEnumerator ShowLettersNext()
    {
        for (int i = 0; i < messages.Count; i++)
        {
            Message.text = "";

            foreach (var letter in messages[i])
            {
                Message.text += letter;
                yield return new WaitForSeconds(speed);
            }

            yield return new WaitForSeconds(2.0f);
        }

        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}