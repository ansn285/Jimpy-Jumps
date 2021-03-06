using Mirror;
using UnityEngine;

public class PlayerMovementController : NetworkBehaviour
{

    //[SerializeField] private float movementSpeed = 5f;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private PlayerController controller = null;

    private Vector2 previousInput;

    public override void OnStartAuthority()
    {
        enabled = true;

        if (mainCamera != null) { mainCamera.SetActive(true); }

        InputManager.Controls.Player.Move.performed += ctx => SetMovement(ctx.ReadValue<Vector2>());
        InputManager.Controls.Player.Move.canceled += ctx => ResetMovement();
    }

    [ClientCallback]
    private void Update() => Move();

    [Client]
    private void SetMovement(Vector2 movement) => previousInput = movement;

    [Client]
    private void ResetMovement() => previousInput = Vector2.zero;


    [Client]
    private void Move()
    {
        Vector3 right = controller.transform.right;
        Vector3 up = controller.transform.up;
        right.z = 0f;
        up.z = 0f;

        Vector3 movement = right.normalized * previousInput.x + up.normalized * previousInput.y;
        controller.MoveCharacter(movement);
    }
}
