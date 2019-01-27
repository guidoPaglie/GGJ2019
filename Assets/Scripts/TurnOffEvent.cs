using UnityEngine;

public class TurnOffEvent : MonoBehaviour
{
    public void PlaySound()
    {
        AudioManager.Instance.PlaySound("tv_off");
        AudioManager.Instance.PauseMusic();
    }
}
