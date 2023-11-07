using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    // ruch wokół osi Y będzie wykonywany na obiekcie gracza, więc
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;
    private float rotationX = 0f; // aktualny
    public float sensitivity = 200f;
    public float minRotation = -90f;//minimalny kąt
    public float maxRotation = 90f;//maksymalny kkąt

    void Start()
    {
        // zablokowanie kursora na środku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // pobieramy wartości dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // wykonujemy rotację wokół osi Y
        player.Rotate(Vector3.up * mouseXMove);

         // Ograniczenie ruchu myszy dla osi X
        rotationX -= mouseYMove;
        rotationX = Mathf.Clamp(rotationX, minRotation, maxRotation);
        // Obrót kamery dla lokalnych koordynatów
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

    }
}