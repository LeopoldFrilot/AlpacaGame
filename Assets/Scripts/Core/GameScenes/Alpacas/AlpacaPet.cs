using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public interface IClickable
// {
//     void HandleClickDown(Vector2 clickLocation);
//     //bool WouldBeClicked(Vector2 clickLocation);
// }

public class AlpacaPet : MonoBehaviour
{
    public Collider2D clickCollider;
    private AlpacaStatsSO alpacaStat;
    
    private void Start()
    {
        //set love stat to 0? idk
    }

    public void HandleClickDown(Vector2 clickLocation)
    {
        // if (WouldBeClicked(clickLocation))
        // {
            //love stat goes up by X
            //when dude is clicked
            alpacaStat.loveStat++;
        //}
    }

    // public bool WouldBeClicked(Vector2 clickLocation)
    // {
    //     return clickCollider.bounds.Contains(clickLocation);
    // }

}
