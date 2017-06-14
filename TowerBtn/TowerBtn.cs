using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBtn : MonoBehaviour {

    [SerializeField] private int towerPrice;
    [SerializeField] private Tower towerObject;
    [SerializeField] Sprite dragSprite;

    public Tower TowerObject
    {
        get
        {
            return towerObject;
        }
    }


    public Sprite DragSprite
    {
        get
        {
            return dragSprite;
        }
    }

    public int TowerPrice
    {
        get
        {
            return towerPrice;
        }
    }
}
