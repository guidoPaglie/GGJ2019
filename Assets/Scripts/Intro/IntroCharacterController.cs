using UnityEngine;
using XboxCtrlrInput;

namespace Intro
{
    public class IntroCharacterController : MonoBehaviour
    {
        public Sprite PlayerStartSprite;
        public Sprite PlayerEndSprite;
        public SpriteRenderer PlayerImage;
        public XboxController Controller;
        public GameObject PlayerText;
        
        private bool _pressedStart;
        
        private void Awake()
        {
            PlayerImage.sprite = PlayerStartSprite;
        }

        private void Update()
        {
            if (!_pressedStart && PlayerPressedStart())
            {
                _pressedStart = true;
                PlayerImage.sprite = PlayerEndSprite;
                PlayerText.SetActive(false);
                
                if (Controller == XboxController.First)
                {
                    IntroManager.playerOneIsPlaying = true;
                }
                else
                {
                    IntroManager.playerTwoIsPlaying = true;
                }
            }

            if (_pressedStart)
            {
                MovePlayer();
            }
        }

        private bool PlayerPressedStart()
        {
            KeyCode keyboardKey = Controller == XboxController.First ? KeyCode.E : KeyCode.M;
            return Input.GetKeyDown(keyboardKey) || XCI.GetButtonDown(XboxButton.Start, Controller);
        }

        private void MovePlayer()
        {
            transform.position += Vector3.down * 5 * Time.deltaTime;
        }
    }
}