using UnityEngine;
using UnityEngine.InputSystem;

public class GameSystem : MonoBehaviour
{
    [SerializeField] GameObject StartGamePanel;
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject SpawnSystemObject;
    [SerializeField] GameObject TimeSystemObject;

    private bool HasStarted = false;
    private bool HasEnded = false;

    private void Update()
    {
        if (!HasStarted && Keyboard.current.anyKey.isPressed)
        {
            HasStarted = true;
            StartGamePanel.SetActive(false);
            var spawnSystem = SpawnSystemObject.GetComponent<SpawnSystem>();
            spawnSystem.SpawnNextQuest();

            var timeSystem = TimeSystemObject.GetComponent<TimeSystem>();
            timeSystem.InitTimer();
        }
    }

    public void EndGame()
    {
        HasEnded = true;
        GameOverPanel.SetActive(true);
    }

    public bool IsGameActive()
    {
        return !HasEnded && HasStarted;
    }
}
