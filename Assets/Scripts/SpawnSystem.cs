using System;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{

    [SerializeField] GameObject trackingSystemObject;
    [SerializeField] GameObject TimeSystemObject;
    [SerializeField] GameObject[] PackageSpawnPoints;
    [SerializeField] GameObject[] ClientSpawnPoints;

    private TrackingSystem trackingSystem;
    private TimeSystem timeSystem;


    private int ActiveClient;
    private int ActivePackage;

    void Start()
    {
        this.trackingSystem = trackingSystemObject.GetComponent<TrackingSystem>();
        this.timeSystem = TimeSystemObject.GetComponent<TimeSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnNextQuest()
    {
        var PackageSpawnPointsCount = PackageSpawnPoints.Length;
        var ClientSpawnPointsCount = ClientSpawnPoints.Length;

        
        this.ActivePackage = UnityEngine.Random.Range(0, PackageSpawnPointsCount);
        this.ActiveClient = UnityEngine.Random.Range(0, ClientSpawnPointsCount);

        PackageSpawnPoints[ActivePackage].gameObject.SetActive(true);
        ClientSpawnPoints[ActiveClient].gameObject.SetActive(true);
        this.trackingSystem.UpdateActiveElements(PackageSpawnPoints[ActivePackage]);

    }

    public void DespawnClient()
    {
        ClientSpawnPoints[ActiveClient].gameObject.SetActive(false);
        this.trackingSystem.UpdateActiveElements(PackageSpawnPoints[ActivePackage]);

        SpawnNextQuest();
        this.timeSystem.AddTime();
    }


    public void DespawnPackage()
    {
        PackageSpawnPoints[ActivePackage].gameObject.SetActive(false);
        this.trackingSystem.UpdateActiveElements(ClientSpawnPoints[ActiveClient]);
    }
}
