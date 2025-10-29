using UnityEngine;

public class CookingStation : MonoBehaviour
{
    [SerializeField] Ingredient placedIngredient;
    [SerializeField] Transform itemPlacePoint;
    [SerializeField] float multiplyCookingTime;


    bool isCooking;

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
    public void Interact(Texture playerTexture)
    {
        
    }

}
