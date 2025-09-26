using UnityEngine;
using UnityEngine.InputSystem;

public class Gidaria : MonoBehaviour
{
    [SerializeField] float rotazioAbiadura = 1f; 
    [SerializeField] float mugiAbiadura = 1f; 


    void Update()
    {
        float rotazio = 0f;
        float mugi = 0f;
        if (Keyboard.current.wKey.isPressed) { mugi = 1f; }
        else if (Keyboard.current.sKey.isPressed) { mugi = -1f; }
        else if (Keyboard.current.aKey.isPressed) { rotazio = 1f; }
        else if (Keyboard.current.dKey.isPressed) { rotazio = -1f; }
        float mugiKopurua = mugi * mugiAbiadura * Time.deltaTime;
        float rotazioKopurua = rotazio * rotazioAbiadura *
        Time.deltaTime;
        transform.Rotate(0, 0, rotazioKopurua);
        transform.Translate(0, mugiKopurua, 0);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Sartu naiz {other.gameObject.name} objektuaren trigger eremuan.");
    }
}
