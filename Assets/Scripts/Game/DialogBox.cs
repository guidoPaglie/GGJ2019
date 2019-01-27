using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class DialogBox : MonoBehaviour {
    public Animator animator;
    public TextMeshPro text;
    public float dialogEnableTime;
    private bool _dialogEnabled;
    private float _timer;
    
    public void ShowMessage(string message) {
        StopAllCoroutines();
        dialogEnableTime = Math.Max(message.Length * 0.1f, 4.0f);
        animator.SetTrigger("In");
        _timer = 0;
        text.text = "";
        _dialogEnabled = true;
        StartCoroutine(ShowLetters(message));
    }

    private IEnumerator ShowLetters(string message) {
        yield return new WaitForSeconds(0.33f);
                
        foreach (var letter in message) {
            text.text += letter;
            yield return null;
        }
    }

    private void Start() {
        transform.localScale = new Vector3(0,0,0);
    }

    void Update() {
        if (_dialogEnabled) {
            if (_timer < dialogEnableTime) {
                _timer += Time.deltaTime;
            }
            else {
                _timer = 0;
                _dialogEnabled = false;
                HideDialog();
            }
        }
    }

    private void HideDialog() {
        animator.SetTrigger("Out");    
    }
}
