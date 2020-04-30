using UnityEngine;
using UnityEngine.SceneManagement;

namespace JPT.UI
{
    public class SceneRunner : MonoBehaviour
    {
        public void SceneRun(string sceneId)
        {
            SceneManager.LoadScene(sceneId);
        }
    }
}