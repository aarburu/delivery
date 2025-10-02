using TMPro;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    [SerializeField] GameObject GameSystemObject;
    GameSystem gameSystem;

    [SerializeField] float InitialTime = 60f;
    [SerializeField] float SecondsToAdd = 10f;
    [SerializeField] TMP_Text Timer;
    private float reminingTime;
    private bool timerStarted = false;

    void Start()
    {
        reminingTime = InitialTime;
        gameSystem = GameSystemObject.GetComponent<GameSystem>();
    }

    void Update()
    {
        if (timerStarted)
            if (reminingTime > 0)
            {
                reminingTime -= Time.deltaTime;

                int minutos = Mathf.FloorToInt(reminingTime / 60);
                int segundos = Mathf.FloorToInt(reminingTime % 60);

                Timer.text = string.Format("{0:00}:{1:00}", minutos, segundos);
            }
            else
            {
                if (gameSystem.IsGameActive())
                {
                    Timer.text = "00:00";
                    gameSystem.EndGame();
                }
            }
    }

    public void InitTimer()
    {
        this.timerStarted = true;
    }

    public void AddTime()
    {
        this.reminingTime += this.SecondsToAdd;
    }
}
