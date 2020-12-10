using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    public GameObject[] levelLocks;
    public GameObject[] levelSelectButtons;

    void Start()
    {
        int numOfLevels = GameManager.levels;

        for(int i = 2; i <= numOfLevels; i++)
        {
            Destroy(levelLocks[i-2]);
        }

        for (int i = numOfLevels + 1; i <= GameManager.NUM_OF_LEVELS; i++)
        {
            Destroy(levelSelectButtons[i - 2]);
        }
    }

}
