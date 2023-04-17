using UnityEngine;
using UnityEngine.SceneManagement;

namespace FloppyBird.Core
{
    public class SceneLoader : MonoBehaviour
    {
        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
