using Mono.Cecil.Cil;
using System.Collections;
using UnityEngine;

public class Entrega : MonoBehaviour
{
    private bool HasPackage { get; set; }
    [field:SerializeField] private float DestroyObjectDelay { get; set; } = 1f;
    [SerializeField] GameObject SpawnSystemObject;
    private SpawnSystem spawnSystem;

    private void Start()
    {
        this.spawnSystem = SpawnSystemObject.GetComponent<SpawnSystem>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log($"Sartu naiz {collider.gameObject.name} objektuaren trigger enemuan.");

        switch (collider.tag)
        {
            case "Paketea":
                this.GetComponent<ParticleSystem>().Play();
                //Destroy(collider.gameObject);
                //collider.gameObject.SetActive(false);
                HasPackage = true;
                spawnSystem.DespawnPackage();


                break;
            case "Bezeroa":
                if (HasPackage)
                {
                    this.GetComponent<ParticleSystem>().Stop();
                    //Destroy(collider.gameObject, DestroyObjectDelay);
                    //collider.gameObject.SetActive(false);
                    HasPackage = false;
                    spawnSystem.DespawnClient();
                    Debug.Log($"Paketea entregatua izan da.");
                }
                break;
            default: break;
        }
    }
}
