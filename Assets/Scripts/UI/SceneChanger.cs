using UnityEngine;
using UnityEditor.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public void StartGame()
    {
        EditorSceneManager.LoadScene("SampleScene");
    }

    public void RestartGame()
    {
        EditorSceneManager.LoadScene("SampleScene");
    }

    public void BackToMain()
    {
        EditorSceneManager.LoadScene("Menu");
        Debug.Log("To the main menu");
    }

    public void ToCredits()
    {
        EditorSceneManager.LoadScene("Credits");
        Debug.Log("To the credits");
    }
}
