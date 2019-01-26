using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public static bool playerOneIsPlaying;
    public static bool playerTwoIsPlaying;
    public TextMeshPro Message;

    public float speed = 0.02f;
    
    private List<string> messages = new List<string>()
    {
        "Mom died last month.\n Or maybe it was the month before.",
        "I decided to sell the old family house,\n a little dwelling in the suburbs.",
        "I haven't been there in years."
    };
    
    private void Awake()
    {
        StartCoroutine(ShowLettersNext(0,messages[0]));
        StartCoroutine(ShowLettersNext(5.5f,messages[1]));
        StartCoroutine(ShowLettersNext(11.5f, messages[1]));
    }
    
    private IEnumerator ShowLettersNext(float timer, string message)
    {
        yield return new WaitForSeconds(timer);
        Message.text = "";
        
        foreach (var letter in message) {
            Message.text += letter;
            yield return new WaitForSeconds(speed);
        }
    }
    private void Update()
    {
        if (playerOneIsPlaying && playerTwoIsPlaying)
        {
            TurnOffAll();
            StartCoroutine(ChangeScene());
        }
    }

    private void TurnOffAll()
    {
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2.0f);
        
    }
}
