using Mono.Cecil.Cil;
using UnityEngine;

public class TalkaEgin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Talka egin dut {collision.gameObject.name} objektuarekin.");
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log($"Sartu naiz {collider.gameObject.name} objektuaren trigger enemuan.");
    }
}
