// Name: Jason Leech
// Date: 01/09/2023
// Desc: Script for the cursor

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Utils.PlayerScripts
{
    public class Cursor : MonoBehaviour
    {
        public Vector2 currentPos;
        private TurretGrid turretGrid;
        public float sensitivity;
        private SelectManager selectManager;
        
        
        //public UnityEvent PlaceTower = new Un
        private void Start()
        {
            turretGrid = GameObject.FindObjectOfType<TurretGrid>();
            selectManager = FindObjectOfType<SelectManager>();
        }

        public void OnCursor(InputAction.CallbackContext value)
        {
            Vector2 val = value.ReadValue<Vector2>();
            currentPos += val * sensitivity;
            UpdatePosition();
        }

        public void OnMouse(InputAction.CallbackContext value)
        {
            currentPos = Camera.main.ScreenToWorldPoint(value.ReadValue<Vector2>());
            UpdatePosition();
        }

        public void OnClick(InputAction.CallbackContext value)
        {
            print("click");
            print(selectManager.purchaseState());
            if (selectManager.purchaseState())
            {
                print("placing tower");
                turretGrid.PlaceObjectAtPosition(selectManager.purchaseObject(), currentPos, 0);
            }
        }

        private void UpdatePosition()
        {
            transform.position = turretGrid.GetGridPosition(currentPos);
        }
    }
}