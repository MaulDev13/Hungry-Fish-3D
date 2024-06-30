using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    [SerializeField] string gameScene = "Game";

    public void OnBtnGame()
    {
        SceneManager.LoadScene(gameScene);
    }
}
