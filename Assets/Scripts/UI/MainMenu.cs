using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
#if UNITY_EDITOR
    private void Start()
    {
        //If already a second scene is open don't show main menu
        if(SceneManager.sceneCount > 1)
        {
            this.gameObject.SetActive(false);
        }
    }
#endif

    public void LoadDMProgramButton()
    {
        this.gameObject.SetActive(false);
        GameController.Instance.LoadDMProgram();
    }

    public void LoadPlayerProgramButton()
    {
        this.gameObject.SetActive(false);
        GameController.Instance.LoadPlayerProgram();
    }
}
