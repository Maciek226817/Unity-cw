using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie2 : MonoBehaviour
{
    public float movementSpeed = 10f;
    private bool isOpening = false;
    private bool isClosing = false;
    private bool isOpen = false;
    private readonly float closedPosition = 0f;
    private readonly float openPosition = 3f;
    private bool playerNearDoor = false;
    private Transform doorTransform;

    void Start()
    {
        doorTransform = transform.Find("Door"); 
        if (doorTransform == null)
        {
            Debug.LogError("Door object not found");
        }
    }

    void Update()
    {
        UpdateDoorState();

        if ((isOpening && doorTransform.position.z >= openPosition) ||
            (isClosing && doorTransform.position.z <= closedPosition))
        {
            isOpen = isOpening;
            isOpening = false;
            isClosing = false;
        }
        else if (isOpening || isClosing)
        {
            MoveDoor();
        }
    }

    void UpdateDoorState()//Sprawdza, czy gracz jest w pobliżu drzwi (playerNearDoor).
    //Jeśli gracz jest w pobliżu i drzwi nie są otwarte (!isOpen), ustawia isOpening na true, rozpoczynając proces otwierania drzwi.
    //Jeśli gracz nie jest w pobliżu i drzwi są otwarte (isOpen), ustawia isClosing na true, rozpoczynając proces zamykania drzwi.
    {
        if (playerNearDoor)
        {
            if (!isOpen)
            {
                isOpening = true;
            }
        }
        else if (isOpen)
        {
            isClosing = true;
        }
    }

    void MoveDoor()//Porusza drzwi zgodnie z kierunkiem i prędkością.
    //Ustawia kierunek ruchu (moveDirection) zgodnie z tym, czy drzwi otwierają się czy zamykają.
    //Przesuwa transformację drzwi (doorTransform) o odpowiednią wartość, zależną od kierunku i prędkości, korzystając z Translate.
    {
        Vector3 moveDirection = isOpening ? transform.forward : -transform.forward;
        Vector3 move = moveDirection * movementSpeed * Time.deltaTime;
        doorTransform.Translate(move);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is near the door.");
            playerNearDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is not near the door.");
            playerNearDoor = false;
        }
    }
}