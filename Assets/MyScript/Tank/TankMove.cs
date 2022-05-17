using UnityEngine;

public class TankMove : MonoBehaviour
{
    [SerializeField]
    private CharacterMoveInfo moveInfo;
    private float m_MovementInputValue;
    private float m_TurnInputValue;
    private Rigidbody m_Rigidbody;
    [SerializeField]
    private TurretRotate Rotate;

    // Start is called before the first frame update
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_MovementInputValue = Input.GetAxis("Vertical");
        m_TurnInputValue = Input.GetAxis("Horizontal");
        var moveDir = new Vector3(m_TurnInputValue, 0, m_MovementInputValue);
        if (moveDir != default)
            moveDir = moveDir.normalized;
        var moveForce = Vector3.zero;

        if (moveDir == default)
            moveForce = Vector3.Lerp(moveForce, default, moveInfo.braking * Time.deltaTime);
        else
        {
            moveForce = m_Rigidbody.velocity + moveDir * moveInfo.acceleration * Time.deltaTime;
            moveForce = Vector3.ClampMagnitude(moveForce, moveInfo.maxSpeed);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), moveInfo.rotationSpeed * Time.deltaTime);
        }
        Rotate.DoUpdate();
        moveForce.y = 0;
        m_Rigidbody.velocity = moveForce;
    }

    private void Move()
    {
        // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
        //Vector3 movement = transform.forward * m_MovementInputValue * moveInfo.acceleration * Time.deltaTime;

        //// Apply this movement to the rigidbody's position.
        //m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }


    private void Turn()
    {
        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        //float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        // Make this into a rotation in the y axis.
        //Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        //// Apply this rotation to the rigidbody's rotation.
        //m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }

    private void OnValidate()
    {
        if (!Rotate)
            Rotate = GetComponentInChildren<TurretRotate>();
    }
}

[System.Serializable]
public struct CharacterMoveInfo
{
    public float acceleration;
    public float braking;
    public float maxSpeed;
    public float rotationSpeed;
}
