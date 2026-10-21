using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(LineRenderer))]
public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private float range = 30f;
    [SerializeField] private float shotInterval = 0.3f;
    [SerializeField] private float tracerDuration = 0.06f;
    [SerializeField] private LayerMask hitMask = ~0;

    private LineRenderer tracer;
    private float nextShotTime;
    private float hideTracerTime;

    private void Awake()
    {
        tracer = GetComponent<LineRenderer>();

        tracer.useWorldSpace = true;
        tracer.positionCount = 2;
        tracer.startWidth = 0.04f;
        tracer.endWidth = 0.04f;
        tracer.enabled = false;

        if (firePoint == null)
        {
            Debug.LogError(
                "PlayerShooter: arraste o FirePoint para o campo Fire Point.",
                this
            );

            enabled = false;
        }
    }

    private void Update()
    {
        if (tracer.enabled && Time.time >= hideTracerTime)
        {
            tracer.enabled = false;
        }

        Mouse mouse = Mouse.current;

        if (mouse == null)
        {
            return;
        }

        if (mouse.leftButton.isPressed && Time.time >= nextShotTime)
        {
            Shoot();
            nextShotTime = Time.time + shotInterval;
        }
    }

    private void Shoot()
    {
        Vector3 origin = firePoint.position;
        Vector3 direction = firePoint.forward;
        Vector3 endPoint = origin + direction * range;

        if (Physics.Raycast(
            origin,
            direction,
            out RaycastHit hit,
            range,
            hitMask,
            QueryTriggerInteraction.Ignore))
        {
            endPoint = hit.point;

            IDamageable damageable =hit.collider.GetComponentInParent<IDamageable>();

            if (damageable != null)
            {
                damageable.TakeDamage(1);
            }

            Debug.Log("Tiro acertou: " + hit.collider.name, hit.collider);
        }

        tracer.SetPosition(0, origin);
        tracer.SetPosition(1, endPoint);
        tracer.enabled = true;

        hideTracerTime = Time.time + tracerDuration;
    }

    private void OnDisable()
    {
        if (tracer != null)
        {
            tracer.enabled = false;
        }
    }
}