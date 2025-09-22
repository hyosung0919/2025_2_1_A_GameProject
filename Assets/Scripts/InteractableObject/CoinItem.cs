using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : InteractableObject
{
    [Header("µ¿¼± ¼³Á¤")]
    public int coinValue = 10;

    protected override void Start()
    {
        base.Start();
        objectName = "µ¿Àü";
        interactionText = "[E] µ¿Àü È¹µæ";
        interactionType = InteractionType.Item;
    }

    protected override void ColletItem()
    {
        transform.Rotate(Vector3.up * 360f);
        Destroy(gameObject, 0.5f);
    }
}
