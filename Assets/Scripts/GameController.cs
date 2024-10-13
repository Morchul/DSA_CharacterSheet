using DSA.Character.Value.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    #region Singleton
    private static GameController instance;

    public static GameController Instance => instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            instance.Init();
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Debug.LogError("There exists a second GameController!");
            Destroy(this.gameObject);
        }
    }
    #endregion

    [Header("Localization")]
    [SerializeField]
    private Localization localization;

    [Header("Program")]
    [SerializeField]
    [Scene]
    private string dmProgram;

    [SerializeField]
    [Scene]
    private string playerProgram;
    
    [Header("Log")]
    [SerializeField]
    private Log.LogLevel logLevel;

    public Role CurrentRole { get; private set; }

    private void Init()
    {
        Log.CurrentLogLevel = logLevel;
        localization.LoadTables();
        CharacterValueDatabase.Init(localization);
    }

#if UNITY_EDITOR
    private void Start()
    {
        if(SceneManager.sceneCount > 1)
        {
            for(int i = 0; i < SceneManager.sceneCount; ++i)
            {
                if(SceneManager.GetSceneAt(i).path == dmProgram)
                {
                    Log.Verbose("Multiscene Start in DM Program");
                    CurrentRole = Role.DM;
                    break;
                }
                if (SceneManager.GetSceneAt(i).path == playerProgram)
                {
                    Log.Verbose("Multiscene Start in Player Program");
                    CurrentRole = Role.Player;
                    break;
                }
            }
        }
    }
#endif

    public void LoadDMProgram()
    {
        Log.Verbose("Load DM Program");
        CurrentRole = Role.DM;
        SceneManager.LoadScene(dmProgram, LoadSceneMode.Additive);
    }

    public void LoadPlayerProgram()
    {
        Log.Verbose("Load Player Program");
        CurrentRole = Role.Player;
        SceneManager.LoadScene(playerProgram, LoadSceneMode.Additive);
    }

    public void Quit()
    {
        Log.Verbose("Quit");
    }
}
