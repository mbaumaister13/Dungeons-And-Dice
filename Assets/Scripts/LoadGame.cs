using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    public void loadGame(){
        SceneManager.LoadScene("BoardScene");
    }
}
