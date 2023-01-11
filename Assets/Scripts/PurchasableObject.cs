// Name: Jason Leech
// Date: 01/11/2023
// Desc:

using System;
using UnityEngine;

namespace Utils
{
    public class PurchasableObject : MonoBehaviour
    {
        public int cost;
        public Sprite previewSprite;
        public GameObject objectToPurchase;

        private void Start()
        {
            //align this object to the turret grid
            TurretGrid grid = FindObjectOfType<TurretGrid>();

            transform.position = grid.GetGridPosition(transform.position);
        }
    }
}