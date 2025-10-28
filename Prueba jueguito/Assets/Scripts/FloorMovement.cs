using UnityEngine;

public class FloorMovement : MonoBehaviour
{

    [SerializeField] float rotationSpeed;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                            transform.eulerAngles.y, transform.eulerAngles.z + rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                            transform.eulerAngles.y, transform.eulerAngles.z - rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x - rotationSpeed * Time.deltaTime,
                            transform.eulerAngles.y, transform.eulerAngles.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x + rotationSpeed * Time.deltaTime,
                            transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
