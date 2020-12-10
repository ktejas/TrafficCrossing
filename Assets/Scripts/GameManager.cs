using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public const int NUM_OF_LEVELS = 20;
    public static string levelName = "Level01";
    public static int levelIndex = 1;

    //PlayerPrefs
    public static int levels = 1;

    //UI
    public static GameObject UIWinPanel;
    public static GameObject UILosePanel;

    //Borders
    public static GameObject leftBorder;
    public static GameObject rightBorder;

    public static AudioSourceManager thisAudioSourceManager;

    //public static GameObject adObject;
    //public static bool bAdCreated = false;

    private void Awake()
    {
        //Singleton Pattern replication in Unity Scripting
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        thisAudioSourceManager = GetComponent<AudioSourceManager>();

        //Below code happens only once at the start of the game
#if false 
        //UNITY_EDITOR
        //Reset PlayerPrefs to zero
        PlayerPrefs.SetInt("levels", 1);
        Debug.Log("UNITY_EDITOR: PlayerPrefs Reset");
#else
        //Get PlayerPrefs
        levels = PlayerPrefs.GetInt("levels", 1);
#endif
        //Rather than being called directly this script code shows use of a delegate. This means the sceneLoaded value is added into a list of delegates.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //Custom Method
    //The SceneManager.sceneLoaded delegate can have any method hooked into it and it is OnSceneLoaded () here. 
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        levelName = scene.name;

        if (levelName.StartsWith("Level"))
        {
            levelIndex = int.Parse(levelName.TrimStart("Level".ToCharArray()));

            UIWinPanel = GameObject.FindGameObjectWithTag("UIWin");
            UILosePanel = GameObject.FindGameObjectWithTag("UILose");

            leftBorder = GameObject.FindGameObjectWithTag("LeftBorder");
            rightBorder = GameObject.FindGameObjectWithTag("RightBorder");
            Vector3 screenToWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f));
            if (leftBorder != null)
            {
                leftBorder.transform.position = new Vector3(-screenToWorldPosition.x, 0.0f, 0.0f);
                rightBorder.transform.position = new Vector3(screenToWorldPosition.x, 0.0f, 0.0f);
            }
        }
    }

    //Finally, OnDisable() is used to remove OnSceneLoaded () from SceneManager.sceneLoaded.
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "SelectLevel")
            {
                GameManager.thisAudioSourceManager.PlayClickSound();
                SceneManager.LoadScene("Menu");
            }
            else if (SceneManager.GetActiveScene().name != "Menu" && SceneManager.GetActiveScene().name != "SelectLevel")
            {
                GameManager.thisAudioSourceManager.PlayClickSound();
                SceneManager.LoadScene("SelectLevel");
            }
        }
    }


    public static void ManageUI(string i_mode)
    {
        if (i_mode == "Win")
        {
            UIWinPanel.GetComponent<RectTransform>().localPosition = Vector3.zero;
            thisAudioSourceManager.PlayAudioClip("SoundLevelComplete");

            if (levelIndex >= NUM_OF_LEVELS)
            {
                PlayerPrefs.SetInt("levels", levelIndex + 1);
                levels = levelIndex + 1;
            }
        }
        else
        {
            UILosePanel.GetComponent<RectTransform>().localPosition = Vector3.zero;
            thisAudioSourceManager.PlayAudioClip("SoundLevelFailed");
        }
    }


    public void ChangeScene(string i_sceneName)
    {
        thisAudioSourceManager.PlayClickSound();
        SceneManager.LoadScene(i_sceneName);
    }

    public void NextScene()
    {
        thisAudioSourceManager.PlayClickSound();
        Scene currentScene = new Scene();
        currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }

    public void ReloadScene()
    {
        thisAudioSourceManager.PlayClickSound();
        Scene currentScene = new Scene();
        currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public static void ShowBanner()
    {
        //adObject.GetComponent<admobdemo>().AdmobShowBanner();
    }

    public static void ShowInterstial()
    {
        //adObject.GetComponent<admobdemo>().AdmobShowInterstitial();
    }

    public static void ShowVideo()
    {
        //adObject.GetComponent<admobdemo>().AdmobShowVideo();
    }

    public void OpenURL()
    {
#if UNITY_IOS
        //Application.OpenURL("");
        Debug.Log("Publish to iOS App Store");
#else
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.madlogicgames.trafficcrossing");
#endif
    }
}