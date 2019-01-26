using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject characterLeft;
    public GameObject characterRight;

    public LevelController level1;
    public LevelController level2;
    public LevelController level3;
    
    // Start is called before the first frame update
    void Start()
    {
        loadLevel(level1);
    }

    private void loadLevel(LevelController level)
    {
        characterLeft.transform.position = level.initialCharacter1Position;
        characterRight.transform.position = level.initialCharacter2Position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
