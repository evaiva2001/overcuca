using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] Vector3 initPosition;

    Rigidbody rb;

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Respawn();
        }   
    }

    void Respawn()
    {
        transform.position = initPosition;
        transform.eulerAngles = Vector3.zero;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.name == "DeadZone")
        {
            Respawn();
        }
    }
}
