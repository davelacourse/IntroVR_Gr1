using UnityEngine;
using UnityEngine.InputSystem;

public class MouvementSphere : MonoBehaviour
{
    [SerializeField] private InputActionReference _move = default(InputActionReference);

    private Vector3 _direction;
    private float _vitesse = 10f;

    private void Start()
    {
        _move.action.performed += BougerSphere;
    }

    private void OnDestroy()
    {
        _move.action.performed -= BougerSphere;
    }

    private void BougerSphere(InputAction.CallbackContext obj)
    {
        Vector2 direction2D = obj.ReadValue<Vector2>();
        _direction = new Vector3(direction2D.x, 0f, direction2D.y);

        transform.Translate(_direction *  _vitesse * Time.fixedDeltaTime);
    }
}
