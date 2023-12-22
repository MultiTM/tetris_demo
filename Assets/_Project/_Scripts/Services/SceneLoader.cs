using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project._Scripts.Services
{
    public class SceneLoader
    {
        private const string GameplayScene = "Gameplay";

        public void LoadGameplayScene()
        {
            LoadScene(GameplayScene);
        }

        private void LoadScene(string sceneName)
        {
            Debug.Log("Loading scene: " + sceneName);
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }
}