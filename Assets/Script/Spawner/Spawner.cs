using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;

    [SerializeField] private GameObject blueFighterPrefab;
    [SerializeField] private GameObject redFighterPrefab;
    [SerializeField] private Transform planeTransform;

    public List<GameObject> blueFighterList = new List<GameObject>();
    public List<GameObject> redFighterList = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnBlueFighter();

        }

        if (Input.GetMouseButtonDown(1))
        {
            SpawnRedFighter();
        }

    }

    private void SpawnBlueFighter()
    {
        Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 spawnPosition = GetSpawnPosition(clickPosition);
        GameObject blueFighter = Instantiate(blueFighterPrefab, spawnPosition, Quaternion.identity);
        blueFighterList.Add(blueFighter);
    }

    private void SpawnRedFighter()
    {
        Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 spawnPosition = GetSpawnPosition(clickPosition);
        GameObject redFighter = Instantiate(redFighterPrefab, spawnPosition, Quaternion.identity);
        redFighterList.Add(redFighter);
    }

    private Vector3 GetSpawnPosition(Vector3 clickPosition)
    {
        Plane plane = new Plane(planeTransform.up, planeTransform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float rayDistance;


        if (plane.Raycast(ray, out rayDistance))
        {
            return ray.GetPoint(rayDistance);
        }

        return clickPosition;
    }
}
