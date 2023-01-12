// Name: Jason Leech
// Date: 01/09/2023
// Desc: Script for the cursor

using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Utils.PlayerScripts
{
    public class Cursor : MonoBehaviour
    {
        public Vector2 currentPos;
        public float sensitivity;
        public Material previewMaterial;
        public Bounds borders;
        
        
        private Material _defaultMaterial;
        private Sprite _defaultSprite;
        private TurretGrid _turretGrid;
        private SelectManager _selectManager;
        private SpriteRenderer _spriteRenderer;
        
        //public UnityEvent PlaceTower = new Un
        private void Start()
        {
            _turretGrid = GameObject.FindObjectOfType<TurretGrid>();
            _selectManager = FindObjectOfType<SelectManager>();

            _spriteRenderer = GetComponent<SpriteRenderer>();
            _defaultMaterial = _spriteRenderer.material;
            _defaultSprite = _spriteRenderer.sprite;
        }

        private void Update()
        {
            UpdatePosition();
        }
        
        //public void initialize()

        public void OnCursor(InputAction.CallbackContext value)
        {
            Vector2 val = value.ReadValue<Vector2>();
            if (borders.Contains(currentPos + val * sensitivity))
            {
                currentPos += val * sensitivity;
                UpdatePosition();
            }

        }

        public void OnMouse(InputAction.CallbackContext value)
        {
            currentPos = Camera.main.ScreenToWorldPoint(value.ReadValue<Vector2>());
            UpdatePosition();
        }

        public void OnClick(InputAction.CallbackContext value)
        {
            //check if a purchasable object is selected
            Collider2D collider = Physics2D.OverlapPoint(transform.position);


            if (collider != null)
            {
                PurchasableObject purchasable;
                purchasable = collider.gameObject.GetComponent<PurchasableObject>();
                if (purchasable != null)
                {
                    //do not place an object here, this is a purchasable object
                    _spriteRenderer.material = previewMaterial;
                    _spriteRenderer.sprite = purchasable.previewSprite;
                    _selectManager.enablePurchase(purchasable.objectToPurchase, purchasable.cost);
                    return;
                }
            }

            print("click");
            //print(_selectManager.purchaseState());
            if (_selectManager.purchaseState())
            {
                print("placing tower");
                _turretGrid.PlaceObjectAtPosition(_selectManager.purchaseObject(), transform.position, 0);
            }
        }

        private void UpdatePosition()
        {
            Vector2 pos = _turretGrid.GetGridPosition(currentPos);
            print(pos);
            transform.position = pos;
            print(transform.position);
        }
    }
}