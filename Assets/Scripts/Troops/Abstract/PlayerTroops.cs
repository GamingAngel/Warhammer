using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerTroops : Troops
{
    private Vector2 moveDirection;
    private Vector2 lookDirection;
    private bool isShooting;

    public void OnAttack(InputAction.CallbackContext context)
    {
        isShooting = context.performed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }
    public void OnLookAt(InputAction.CallbackContext context)
    {
        lookDirection = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        Vector3 move = new(moveDirection.x, 0, moveDirection.y);
        rb.MovePosition(rb.position + speed * Time.deltaTime * move);     
    }

    private void LookAt()
    {
        Vector3 aimDirection = new(lookDirection.x, 0, lookDirection.y);
        if (aimDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(aimDirection), 0.15f);
        }     
    }
    private void FixedUpdate()
    {
        Move();
        LookAt();
        if(isShooting)
        {
            Attack();
        }
    }
}
