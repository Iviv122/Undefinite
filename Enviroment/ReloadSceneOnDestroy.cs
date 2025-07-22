using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadSceneOnDestroy : MonoBehaviour
{
    private void OnDestroy()
    {
        Reload();
    }
    private void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Single);
    }
}