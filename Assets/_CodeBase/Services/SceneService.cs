using UnityEngine;
using UnityEngine.SceneManagement;

namespace _CodeBase.Services
{
  public class SceneService : MonoBehaviour
  {
    public void ReloadCurrentScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    
    public void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName);
  }
}