using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField, Scene] string NextLevel;
    [SerializeField, Tag] string PlayerTag;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == PlayerTag)
        {
            TransitToNextLevel();
            Destroy(collision.gameObject);
            //vfx
        }
    }
    public void TransitToNextLevel()
    {
        Debug.Log("Trying to load: " + NextLevel);
        SceneManager.LoadScene(NextLevel,LoadSceneMode.Single);
    }
}
