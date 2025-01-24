using UnityEngine;
using UnityEditor.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public void StartGame()
    {
        EditorSceneManager.LoadScene("SampleScene");
    }
    
}
