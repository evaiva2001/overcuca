using UnityEngine;

public class Ingredient : MonoBehaviour
{
    bool cooked;
    [SerializeField] Color cookedColor;
    [SerializeField] Color burnedColor;
    MeshRenderer renderer;
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
            renderer.material.color = burnedColor;
        }
    }
    void PickUp()
    {
        
    }

    void DropDown()
    {
        
    }
}
