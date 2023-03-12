using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerTroops : Troops
{
    [SerializeField] protected float speed;

    private Rigidbody rb;

    private Vector2 moveDirection;
    private Vector2 lookDirection;
    protected override void Attack()
    {
        throw new System.NotImplementedException();
    }

    protected override void Die()
    {
        throw new System.NotImplementedException();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        Vector3 move = new(moveDirection.x, 0, moveDirection.y);
        rb.MovePosition(rb.position + speed * Time.deltaTime * move);     
    }


    public void OnLookAt(InputAction.CallbackContext context)
    {
        lookDirection = context.ReadValue<Vector2>();
    }

    private void LookAt()
    {
        Vector3 aimDirection = new(lookDirection.x, 0, lookDirection.y);
        if (aimDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(aimDirection), 0.15f);
        }
        
    }




    protected void Start()
    {
        rb=GetComponent<Rigidbody>();
    }
    protected void Update()
    {
        
    }
    protected void FixedUpdate()
    {
        Move();
        LookAt();
    }




}
