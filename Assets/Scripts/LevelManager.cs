using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int lvlNum = 1;
    GameObject[] lvlButtons;

    void Awake()
    {

    }

    void Start()
    {
        lvlButtons = GameObject.FindGameObjectsWithTag("ButtonLvl");
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            lvlButtons[i].SetActive(false);
        }

        //Read Save file and Open up finished levels
        //

        for (int i=0; i<lvlNum; i++)
        {
            lvlButtons[i].SetActive(true);
        }
    }

    void Update()
    {
        
    }

    public void OnLevelSelected(int i_lvlNum)
    {
        SceneManager.LoadScene("ScLevel1");
        Debug.Log("clicked");
    }
}
