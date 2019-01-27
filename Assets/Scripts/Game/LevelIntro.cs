using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class LevelIntro : MonoBehaviour {
    public TextMeshPro Message;
    public Animator Animator;
    public float charactersSpeed;
    private Action _onEnd;
    
    public void StartIntro(string message, Action onEnd) {
        Message.text = "";
        _onEnd = onEnd;
        StartCoroutine(ShowLettersNext(message));
    }
    
    private IEnumerator ShowLettersNext(string message)
    {
        foreach (var letter in message)
        {
            Message.text += letter;
            yield return new WaitForSeconds(charactersSpeed);
        }

        yield return new WaitForSeconds(3);
        Animator.SetTrigger("Play");        
        Callback();
    }

    void Callback() {
        _onEnd();
    }
}
