using System.Collections;
using UnityEngine;
using UnityEngine.Animations;

public class Interactable : MonoBehaviour
{
    [SerializeField] Ingredient placedIngredient;
    [SerializeField] Transform itemPlacePoint;

    Texture initTexture;

    [SerializeField] Texture activeTexture;

    MeshRenderer renderer;

    int focusCount;

    bool isCooking;

    [SerializeField] float multiplyCookingTime;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        renderer = this.GetComponent<MeshRenderer>();
        initTexture = renderer.material.mainTexture;
        focusCount = 0;
        isCooking = false;
    }

    public void Focus(bool newFocus)
    {
        if (newFocus) 
        {
            focusCount = focusCount +1;
        }
        else 
        {
            focusCount = focusCount - 1;
        }
        if (focusCount > 0)
        {
            if (renderer.material.mainTexture == initTexture)
            {
                renderer.material.mainTexture = activeTexture;
            }
        }
        else
        {
            if (renderer.material.mainTexture == activeTexture)
            {
                renderer.material.mainTexture = initTexture; 
            }
        }
    }

    public void Interact(Texture playerTexture)
    {
        bool cooked = placedIngredient.GetCooked();
        bool canBurn = placedIngredient.GetCanBurn();

        if (!cooked)
        {
            if (!isCooking && placedIngredient != null)
            {
                float cookingTime = placedIngredient.GetCookingTime();
                StartCoroutine(Cook(playerTexture, cookingTime));
            }
        }
        else
        {
            if (!isCooking && placedIngredient != null && canBurn)
            {
                float burnTime = placedIngredient.GetBurnTime();
                StartCoroutine(Burn(playerTexture, burnTime));
            }
        }

        

    }

    public bool CanPlace(Ingredient wannaDrop)
    {
        return (placedIngredient == null);
        
    }
    public Ingredient Take()
    {
        if (placedIngredient == null || isCooking)
        {
            return null;
        }
        else
        {
            placedIngredient.gameObject.transform.SetParent(null);
            //define una variable auxiliar
            Ingredient aux;
            aux = placedIngredient;


            placedIngredient = null;

            return aux;
        }
    }
    public void Place(Ingredient dropped)
    {
        placedIngredient = dropped;

        placedIngredient.gameObject.transform.SetParent(itemPlacePoint); 

        placedIngredient.gameObject.transform.localPosition = new Vector3(0, 0, 0);

    }
    IEnumerator Cook(Texture playerTexture, float cookingTime)
    {
        renderer.material.mainTexture = playerTexture;
        isCooking = true;
        if (anim != null)
        {
            anim.SetBool("cooking", true);
        }

        yield return new WaitForSeconds(cookingTime * multiplyCookingTime);

        placedIngredient.Cook();
        isCooking = false;
        if (anim != null)
        {
            anim.SetBool("cooking", false);
        }


        renderer.material.mainTexture = initTexture;

    }
    IEnumerator Burn(Texture playerTexture, float burnTime)
    {
        renderer.material.mainTexture = playerTexture;
        isCooking = true;
        if (anim != null)
        {
            anim.SetBool("cooking", true);
        }


        yield return new WaitForSeconds(burnTime * multiplyCookingTime);

        placedIngredient.Cook();
        isCooking = false;
        if (anim != null)
        {
            anim.SetBool("cooking", false);
        }

        renderer.material.mainTexture = initTexture;

    }

}
