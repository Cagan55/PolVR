using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatTrigger : MonoBehaviour
{
    public MoveShip mB;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == ("Tekne"))
        {
            mB.tekneMove = false;
        }
    }
}
