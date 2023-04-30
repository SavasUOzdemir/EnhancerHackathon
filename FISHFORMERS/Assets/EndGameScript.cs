using UnityEngine.SceneManagement;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    public void OnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
