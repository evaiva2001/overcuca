using UnityEngine;
using UnityEngine.UI;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            MoveForeware();
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position - (transform.forward * speed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position - (transform.right * speed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + (transform.right * speed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                transform.eulerAngles.y - rotationSpeed * Time.deltaTime, transform.eulerAngles.z);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                transform.eulerAngles.y + rotationSpeed * Time.deltaTime, transform.eulerAngles.z);
        }
    }
    // Funcion que mueve el personaje hacia delante
    public void MoveForeware()
    {
        // cambia la posicion usando la direcccio
        transform.position = transform.position + (transform.forward * speed) * Time.deltaTime;
    }
}
