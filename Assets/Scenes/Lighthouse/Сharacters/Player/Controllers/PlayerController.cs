using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, 20)] public float rotationSpeed = 10.0f;

    [Range(0, 20)] public float speed = 3.0f;

    private int _healthPoints = 100;

    private int _fearPoints = 0;
    
    private Animator _animator;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movement),
                rotationSpeed * Time.deltaTime);
        }

        _animator.SetFloat("Speed", Vector3.ClampMagnitude(movement, 1).magnitude);
        transform.position += movement * speed * Time.deltaTime;
    }
}
