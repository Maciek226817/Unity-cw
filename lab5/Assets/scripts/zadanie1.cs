using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie1 : MonoBehaviour
{
    public float speed = 1.8f;
    private bool isMoving = false;
    private bool movingForward = true;
    private bool movingBackward = false;
    private float startLocation = 4f;
    private float endLocation = 10f;
    private bool playerOnBoard = false;

    void Update()
    {
        HandleMovement();
        CheckBoundaries();
    }

    void HandleMovement()//Jeśli isMoving jest ustawione na true, platforma porusza się w prawo lub w lewo, w zależności od wartości movingForward.
    {
        if (isMoving)
        {
            float direction = movingForward ? 1f : -1f;
            Vector3 move = Vector3.right * direction * speed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    void CheckBoundaries()//Sprawdza, czy platforma osiągnęła końcową pozycję (endLocation). Jeśli tak, odwraca kierunek ruchu.
    //Jeśli platforma porusza się wstecz (!movingForward) i osiągnęła początkową pozycję (startLocation) oraz gracz jest na platformie, również odwraca kierunek ruchu.
    {
        if (movingForward && transform.position.x >= endLocation)
        {
            ReverseMovement();
        }
        else if (!movingForward && transform.position.x <= startLocation && playerOnBoard)
        {
            ReverseMovement();
        }
    }

    void ReverseMovement()
    {
        movingForward = !movingForward;
        isMoving = playerOnBoard || !movingForward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered the platform.");
            playerOnBoard = true;

            if (transform.position.x <= startLocation)
            {
                movingForward = true;
                movingBackward = false;
            }
            isMoving = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exited the platform.");
            playerOnBoard = false;
            isMoving = movingForward;
        }
    }
}
