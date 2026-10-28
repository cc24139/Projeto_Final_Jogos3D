using UnityEngine;
using UnityEngine.AI;

/// <summary>Stable scene reference point for player or enemy placement.</summary>
public sealed class SpawnPoint : MonoBehaviour
{
    [SerializeField] private string pointId;

    public string PointId => pointId;
    public Vector3 Position => transform.position;
    public Quaternion Rotation => transform.rotation;

    /// <summary>Projects this point onto the baked NavMesh when a nearby position exists.</summary>
    public bool TryGetNavMeshPosition(float searchRadius, out Vector3 position, int areaMask = NavMesh.AllAreas)
    {
        if (searchRadius <= 0f)
        {
            position = default;
            return false;
        }

        if (NavMesh.SamplePosition(transform.position, out NavMeshHit hit, searchRadius, areaMask))
        {
            position = hit.position;
            return true;
        }

        position = default;
        return false;
    }

    private void OnValidate()
    {
        pointId = pointId?.Trim() ?? string.Empty;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0.55f, 0.1f, 0.9f);
        Gizmos.DrawSphere(transform.position, 0.18f);
        Gizmos.DrawRay(transform.position, transform.forward * 0.75f);
    }
}
