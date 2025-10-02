using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gidaria : MonoBehaviour
{
    [SerializeField] float rotazioAbiadura = 1f; 
    [SerializeField] GameObject GameSystemObject; 
    [SerializeField] public float mugiAbiadura = 1f;
    [field: SerializeField] private float abiaduraAzkartu { get; set; } = 20f;
    [field: SerializeField] private float abiaduraMoteldu { get; set; } = 10f;
    [SerializeField] TMP_Text BoostIndicator;

    private GameSystem gameSystem;
    
    private void Start()
    {
        gameSystem = GameSystemObject.GetComponent<GameSystem>();
    }
    void Update()
    {
        if (gameSystem.IsGameActive())
        {
            float rotazio = 0f;
            float mugi = 0f;
            if (Keyboard.current.wKey.isPressed) { mugi = 1f; }
            if (Keyboard.current.sKey.isPressed) { mugi = -1f; }
            if (Keyboard.current.aKey.isPressed) { rotazio = 1f; }
            if (Keyboard.current.dKey.isPressed) { rotazio = -1f; }
            float mugiKopurua = mugi * mugiAbiadura * Time.deltaTime;
            float rotazioKopurua = rotazio * rotazioAbiadura *
            Time.deltaTime;
            transform.Rotate(0, 0, rotazioKopurua);
            transform.Translate(0, mugiKopurua, 0);
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    { 
        switch(collider.tag)
        {
            case "Boost":
                this.mugiAbiadura = abiaduraAzkartu;
                BoostIndicator.gameObject.SetActive(true);
                Destroy(collider.gameObject);
                break;
            
            default:
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BoostIndicator.gameObject.SetActive(false);
        this.mugiAbiadura = abiaduraMoteldu;
    }
}
