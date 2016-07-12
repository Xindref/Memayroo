using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemCountGraphic : MonoBehaviour {

    public Item item;
    public Sprite sprite;
    public Image myImageComponent;

    void Update()
    {
        myImageComponent = GetComponent<Image>();
        if (item != null)
        {
            myImageComponent.sprite = Resources.Load<Sprite>("Sprites/Items/Gold_Coin5");
        }
    }
}
