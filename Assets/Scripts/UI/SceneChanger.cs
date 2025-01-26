using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEditor.SceneManagement;
public class SceneChanger : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("To the main menu");
    }

    public void ToCredits()
    {
        SceneManager.LoadScene("Credits");
        Debug.Log("To the credits");
    }

}
