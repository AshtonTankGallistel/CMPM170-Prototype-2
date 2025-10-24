using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
   
    public void PlayGame()
    {
        SceneManager.LoadScene("Map");
    }

    public void PlayRageGame()
    {
        SceneManager.LoadScene("Map Rage");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
