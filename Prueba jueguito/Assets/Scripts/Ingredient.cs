using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] bool cooked;
    [SerializeField] Color cookedColor;
    [SerializeField] Color burnedColor;
    MeshRenderer renderer;
    [SerializeField] bool canBurn;
    [SerializeField] float cookingTime;
    [SerializeField] float burnTime;

    public float GetCookingTime()
    {
        return cookingTime;
    }
    public float GetBurnTime()
    {
        return burnTime;
    }
    public bool GetCooked()
    {
        return cooked;
    }
    public bool GetCanBurn()
    {
        return canBurn;
    }
    void Start()
    {
        cooked = false;
        renderer = GetComponent<MeshRenderer>();
    }
    public void Cook()
    {
        if (!cooked)
        {
            cooked = true;
            renderer.GetComponent<Renderer>().material.color = cookedColor;
        }
        else
        {
            if (canBurn)
            {
                renderer.material.color = burnedColor;
            }
        }
    }
    void PickUp()
    {
        
    }

    void DropDown()
    {
        
    }
}
