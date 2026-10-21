using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0f, 6f, -8f);
    [SerializeField] private float smoothTime = 0.15f;
    [SerializeField] private float lookHeight = 0.5f;

    private Vector3 followVelocity;

    private void Start()
    {
        if (target == null)
        {
            Debug.LogError(
                "PlayerCamera: arraste o Player para o campo Target.",
                this
            );

            enabled = false;
            return;
        }

        // Começa na posição correta, sem viajar desde a posição do editor.
        transform.position = target.position + offset;
        UpdateRotation();
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;

        transform.position = Vector3.SmoothDamp(
            transform.position,
            desiredPosition,
            ref followVelocity,
            smoothTime
        );

        UpdateRotation();
    }

    private void UpdateRotation()
    {
        // Mantém o ângulo fixo, independente da rotação do jogador.
        Vector3 viewDirection = Vector3.up * lookHeight - offset;

        if (viewDirection.sqrMagnitude > 0.001f)
        {
            transform.rotation = Quaternion.LookRotation(viewDirection);
        }
    }
}