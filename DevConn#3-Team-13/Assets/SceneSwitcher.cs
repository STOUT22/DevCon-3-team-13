using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Function to switch scenes
    public void SwitchToSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
