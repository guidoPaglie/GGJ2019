using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Levels
{
    public class Level3 : LevelController
    {
        public LevelIntro LevelIntro;
        public Item chest_left;
        public Item drawer_left;
        public Item car1_left;
        public Item car2_left;
        public Item library_left;
        public Item tv_left;
        public Item key_left;

        public Item chest_right;
        public Item drawer_right;
        public Item car1_right;
        public Item car2_right;
        public Item library_right;
        public Item tv_right;
        public Item key_right;

        public Item console_right;

        public Item LibraryLeftBlock;
        public Item LibraryRightBlock;

        public Item TvBlockLeft;
        public Item TvBlockRight;

        public List<Item> floors;

        public GameObject tvNoise;
        public GameObject tvSoccer;

        public Animator endingAnimator;
        
        private bool _car1Activated;
        private bool _car2Activated;
        private bool _alreadyDropped;

        protected override void OnStart()
        {
            _gameManager.characterLeft.enabled = false;
            _gameManager.characterRight.enabled = false;
            LevelIntro.gameObject.SetActive(true);
            LevelIntro.StartIntro("But perhaps there was one place where I didn't feel so lonely...", () => {
                _gameManager.characterLeft.enabled = true;
                _gameManager.characterRight.enabled = true;
                GridManager.InsertItemIn(chest_left);
                GridManager.InsertItemIn(drawer_left);
                GridManager.InsertItemIn(car1_left);
                GridManager.InsertItemIn(car2_left);
                GridManager.InsertItemIn(library_left);
                GridManager.InsertItemIn(LibraryLeftBlock);
                GridManager.InsertItemIn(tv_left);

                GridManager.InsertItemIn(chest_right);
                GridManager.InsertItemIn(drawer_right);
                GridManager.InsertItemIn(car1_right);
                GridManager.InsertItemIn(car2_right);
                GridManager.InsertItemIn(library_right);
                GridManager.InsertItemIn(LibraryRightBlock);
                GridManager.InsertItemIn(tv_right);

                GridManager.InsertItemIn(key_right);
                GridManager.InsertItemIn(console_right);

                GridManager.InsertItemIn(TvBlockLeft);
                GridManager.InsertItemIn(TvBlockRight);
            
                floors.ForEach(GridManager.InsertItemIn);
                AudioManager.Instance.OnResumeMusic();
            });           
        }

        public override void OnTriggerEvent(string item)
        {
            switch (item)
            {
                case "car1_right":
                    AudioManager.Instance.PlaySound("toy_car");
                    _car1Activated = true;
                    _gameManager.AnimateItemTo(car1_left, Direction.Up, 4, () =>
                    {
                        if (_car2Activated)
                        {
                            DropKey();
                        }

                        _car1Activated = false;
                        _gameManager.AnimateItemTo(car1_left, Direction.Down, 4, () => { });
                    });                    
                    break;
                case "car2_left":
                    AudioManager.Instance.PlaySound("toy_car");
                    _car2Activated = true;
                    _gameManager.AnimateItemTo(car2_left, Direction.Right, 2, () =>
                    {
                        if (_car1Activated)
                        {
                            DropKey();
                        }

                        _car2Activated = false;
                        _gameManager.AnimateItemTo(car2_left, Direction.Left, 2, () => { });
                    });
                    break;
                case "key_left":
                    drawer_left.id = "drawer_left_key";
                    break;
                case "drawer_left_key":
                    drawer_left.id = "drawer_left";
                    drawer_right.id = "drawer_right_key";
                    _gameManager.ItemDepositLeft(item);
                    break;
                case "drawer_right_key":
                    var cell = GridManager.GetCell(new Vector2(key_right.itemPosition.x, key_right.itemPosition.y));
                    _gameManager.PerformPick(cell, _gameManager.characterRight);
                    chest_right.id = "chest_right_key";
                    break;

                case "chest_right_key":
                    _gameManager.ItemDepositRight(item);
                    chest_right.id = "chest_right";
                    var console =
                        GridManager.GetCell(new Vector2(console_right.itemPosition.x, console_right.itemPosition.y));
                    _gameManager.PerformPick(console, _gameManager.characterRight);
                    _gameManager.HighlightItem("Consola");

                    tv_left.message = "tv_ready_left";
                    TvBlockLeft.message = "tv_ready_left";

                    tv_right.message = "tv_ready_right";
                    tv_right.id = "tv_ready_right";
                    TvBlockRight.message = "tv_ready_right";
                    TvBlockRight.id = "tv_ready_right";
                    
                    break;
                
                case "tv_right":
                    tvNoise.SetActive(true);
                    Invoke("turnOffNoise", 3);
                    break;

                case "tv_ready_right":
                    _gameManager.HideInventory();
                    _gameManager.characterRight.enabled = false;

                    tv_right.message = null;
                    tv_right.id = "tv_ready_right_2";
                    TvBlockRight.message = null;
                    TvBlockRight.id = "tv_ready_right_2";

                    tvSoccer.SetActive(true);

                    StartCoroutine(addBridgeBlocks());
                    break;

                case "tv_ready_right_2":
                    tv_right.id = "";
                    TvBlockRight.id = "";
                    _gameManager.characterLeft.enabled = false;
                    Debug.Log("Ending");
                    Invoke("startEndingAnimation", 2);
                    break;
            }
        }

        private IEnumerator addBridgeBlocks()
        {
            for (int i = 0; i < floors.Count; i++)
            {
                Item block = floors[i];
                block.GetComponent<SpriteRenderer>().enabled = true;
                block.isWalkable = true;

                yield return new WaitForSeconds(0.5f);
            }
        }

        private void turnOffNoise()
        {
            tvNoise.SetActive(false);
        }

        private void startEndingAnimation()
        {
            endingAnimator.gameObject.SetActive(true);
            endingAnimator.SetTrigger("Play");
            Invoke("ChangeToCredits", 9);
        }

        void ChangeToCredits() {
            SceneManager.LoadScene(2);
        }

        private void DropKey()
        {
            if (_alreadyDropped)
                return;

            AudioManager.Instance.PlaySound("key_drop");

            _alreadyDropped = true;
            GridManager.RemoveItemIn(key_left.itemPosition.x, key_left.itemPosition.y);
            key_left.SetPosition(new Vector2(key_left.itemPosition.x, key_left.itemPosition.y - 2));
            GridManager.InsertItemIn(key_left);
        }
    }
}