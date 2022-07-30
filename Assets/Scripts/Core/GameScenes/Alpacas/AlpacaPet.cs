using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlpacaPet : MonoBehaviour, IClickable
{
    public Collider2D clickCollider;
    private int alpacaLove;
    
    private void Start()
    {
        alpacaLove = 0;
    }

    public void HandleClickDown(Vector2 clickLocation)
    {
        if (WouldBeClicked(clickLocation))
        {
            //love stat goes up by X
            //when dude is clicked
            alpacaLove++;
            Debug.Log("Alpaca " + gameObject.name + " love: " + alpacaLove);
        }
    }

    public bool WouldBeClicked(Vector2 clickLocation)
    {
        return clickCollider.bounds.Contains(clickLocation);
    }

    private void OnEnable()
    {
        EventHub.OnClickDown += HandleClickDown;
    }

    private void OnDisable()
    {
        EventHub.OnClickDown -= HandleClickDown;
    }

}
