using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float sprinSpeed = 10f;

    private float gravity = -9.81f;
    private float speed = 0f;

    private CharacterController cc;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (cc.isGrounded)
        {
            gravity = -9.81f;
        }
        else
        {
            gravity += Physics.gravity.y * Time.deltaTime;
        }

        float _xMov = Input.GetAxis("Horizontal") * speed;
        float _zMov = Input.GetAxis("Vertical") * speed;

        Vector3 _velocity = new Vector3(_xMov, gravity, _zMov);

        if(Input.GetKey("w") && Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprinSpeed;
        }
        else
        {
            speed = runSpeed;
        }

        cc.Move(_velocity * Time.deltaTime);
    }
}
