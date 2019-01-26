using UnityEngine;

public class IntroController : MonoBehaviour
{
    public Sprite KidSprite;
    public Sprite ManSprite;

    public SpriteRenderer KidImage;
    public SpriteRenderer ManImage;

    private void Awake()
    {
        KidImage.sprite = KidSprite;
        ManImage.sprite = ManSprite;
    }
}
