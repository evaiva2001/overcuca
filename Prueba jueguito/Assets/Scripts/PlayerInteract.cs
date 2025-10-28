using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    Texture playerColor;
    Interactable activeAppliance;
    [SerializeField] Key interactKey;
    [SerializeField] Key pickDropKey;
    Ingredient carriedIngredient;

    [SerializeField] Transform itemPlacePoint;

    private void Start()
    {
        playerColor = this.gameObject.GetComponent<MeshRenderer>().material.mainTexture;
    }
    private void Update()
    {
        if (activeAppliance != null)
        {
            if (Keyboard.current[interactKey].wasPressedThisFrame)
            {
                activeAppliance.Interact(playerColor);
            }
            if (Keyboard.current[pickDropKey].wasPressedThisFrame)
            {
                PickOrDrop();
            }
        }
    }
    void PickOrDrop()
    {
        if (carriedIngredient != null)
        {
            if (activeAppliance.CanPlace(carriedIngredient))
            {
                DropDown();
            }
        }
        else
        {
            PickUp(activeAppliance.Take());
        }

    }
    void PickUp(Ingredient picked)
    {
        carriedIngredient = picked;
        if (carriedIngredient != null)
        {
            carriedIngredient.gameObject.transform.SetParent(itemPlacePoint);
            carriedIngredient.gameObject.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
    void DropDown()
    {
        carriedIngredient.gameObject.transform.SetParent(null);

        activeAppliance.Place(carriedIngredient);

        carriedIngredient = null;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Interactable interactuable;
        interactuable = collision.gameObject.GetComponent<Interactable>();

        if (interactuable != null)
        {
            if (activeAppliance != null)
            {
                activeAppliance.Focus(false);
            }

            activeAppliance = interactuable;
            activeAppliance.Focus(true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Interactable interactuable;
        interactuable = collision.gameObject.GetComponent<Interactable>();

        if (interactuable != null)
        {
            if (activeAppliance == interactuable)
            {
                activeAppliance.Focus(false);
                activeAppliance = null;
            }
        }
    }

    
}
