using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

/// <summary>Scene-level references shared by arena setup and gameplay integration.</summary>
public sealed class ArenaConfiguration : MonoBehaviour
{
    [SerializeField] private Transform playerStart;
    [SerializeField] private SpawnPoint[] enemySpawnPoints = new SpawnPoint[0];
    [SerializeField] private NavMeshSurface navigationSurface;

    public Transform PlayerStart => playerStart;
    public NavMeshSurface NavigationSurface => navigationSurface;
    public IReadOnlyList<SpawnPoint> EnemySpawnPoints => enemySpawnPoints;

    public bool TryGetSpawnPoint(string pointId, out SpawnPoint spawnPoint)
    {
        if (!string.IsNullOrWhiteSpace(pointId))
        {
            foreach (SpawnPoint candidate in enemySpawnPoints)
            {
                if (candidate != null && candidate.PointId == pointId)
                {
                    spawnPoint = candidate;
                    return true;
                }
            }
        }

        spawnPoint = null;
        return false;
    }

    private void OnValidate()
    {
        if (enemySpawnPoints == null)
        {
            enemySpawnPoints = new SpawnPoint[0];
            return;
        }

        var identifiers = new HashSet<string>();
        foreach (SpawnPoint point in enemySpawnPoints)
        {
            if (point == null)
            {
                continue;
            }

            if (string.IsNullOrWhiteSpace(point.PointId))
            {
                Debug.LogWarning($"Arena '{name}' has a spawn point without an ID.", point);
            }
            else if (!identifiers.Add(point.PointId))
            {
                Debug.LogWarning($"Arena '{name}' has duplicate spawn point ID '{point.PointId}'.", point);
            }
        }
    }
}


