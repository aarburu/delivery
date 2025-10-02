using UnityEngine;

public class TrackingSystem : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] float longitudFlecha = 1f;
    [SerializeField] float espacioFlecha = 1f; 
    GameObject ActiveElement = null;
    LineRenderer lineRenderer;


    private void Start()
    {
        lineRenderer = Player.gameObject.AddComponent<LineRenderer>();

        lineRenderer.positionCount = 2;               
        lineRenderer.startWidth = 0.8f;              
        lineRenderer.endWidth = 0.05f;                
        lineRenderer.material = new Material(Shader.Find("Sprites/Default")); 
    }


    void Update()
    {
        // En principio siempre debería haber un elemento activo, ya sea un paquete o un cliente, pero lo compruebo para asegurar.
        if (ActiveElement != null) {
            Vector3 origen = Player.transform.position;
            Vector3 destino = ActiveElement.transform.position;

            Vector3 direccion = (destino - origen).normalized;


            Vector3 puntoInicio = origen + direccion * espacioFlecha;
            Vector3 puntoFinal = origen + direccion * longitudFlecha;

            lineRenderer.SetPosition(0, puntoInicio);
            lineRenderer.SetPosition(1, puntoFinal);

            float distancia = Vector3.Distance(Player.transform.position, ActiveElement.transform.position);

            if (distancia > 10f)
            {
                lineRenderer.startColor = Color.red;          
                lineRenderer.endColor = Color.red;
            }
            else if (distancia > 5f && distancia <= 10f)
            {
                lineRenderer.startColor = Color.yellow;
                lineRenderer.endColor = Color.yellow;
            }
            else if (distancia < 5f)
            {
                lineRenderer.startColor = Color.green;
                lineRenderer.endColor = Color.green;
            }
        }

    }

    public void UpdateActiveElements(GameObject ActiveElement)
    {
        this.ActiveElement = ActiveElement;
    }
}
