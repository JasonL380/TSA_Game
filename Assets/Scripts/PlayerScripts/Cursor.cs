// Name: Jason Leech
// Date: 01/09/2023
// Desc: Script for the cursor

using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Utils.PlayerScripts
{
    public class Cursor : MonoBehaviour
    {
        public Vector2 currentPos;
        public Vector2 lastPos;
        public float sensitivity;
        public Material previewMaterial;
        public Rect borders;
        public int side;
        public GameObject uiPrefab;
        public Vector2 offset;

        private Material _defaultMaterial;
        private Sprite _defaultSprite;
        private TurretGrid _turretGrid;
        private SelectManager _selectManager;
        private SpriteRenderer _spriteRenderer;


        private void Start()
        {
            _turretGrid = (TurretGrid) FindObjectOfType(typeof(TurretGrid));
            _selectManager = GetComponentInParent<SelectManager>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _defaultMaterial = _spriteRenderer.material;
            _defaultSprite = _spriteRenderer.sprite;
            
            //determine the borders
            borders = _calculateCameraRect();
            //adjust the borders to the selected side
            SetSide(side);
            //create the ui in the lower left corner of the screen
            Instantiate(uiPrefab, borders.min + offset, quaternion.identity);
        }

        public void OnCursor(InputAction.CallbackContext value)
        {
            Vector2 val = value.ReadValue<Vector2>();
            if (borders.Contains(currentPos + val * sensitivity))
            {
                lastPos = currentPos;
                currentPos += val * sensitivity;
                UpdatePosition();
            }
        }

        /*
        public void OnMouse(InputAction.CallbackContext value)
        {
            currentPos = Camera.main.ScreenToWorldPoint(value.ReadValue<Vector2>());
            UpdatePosition();
        }*/

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
            if (_selectManager.purchaseState())
            {
                print("placing tower");
                _turretGrid.PlaceObjectAtPosition(_selectManager.purchaseObject(), transform.position, 0);
            }
        }

        //secondary click, this will unselect the tower
        private void OnSecondaryClick(InputAction.CallbackContext value)
        {
            
        }
        
        private void UpdatePosition()
        {
            Vector2 pos = _turretGrid.GetGridPosition(currentPos);
            transform.position = pos;
        }
        
        //determine the main camera's rect because unity won't do this for me
        private Rect _calculateCameraRect()
        {
            Rect rect = new Rect();
            Camera cam = Camera.main;
            if (cam.orthographic)
            {
                Vector2 max = new Vector2();
                max.y = cam.orthographicSize;
                max.x = cam.aspect * max.y;
                rect.max = max * 2;
                rect.center = (Vector2) cam.transform.position;
            }
            else
            {
                float verticalFov = cam.fieldOfView;
                float horizontalFov = cam.aspect * verticalFov;
                print(verticalFov + ", " + horizontalFov);
                rect.center = cam.transform.position;
                Vector2 max = new Vector2();
                max.x = cam.transform.position.z * Mathf.Sin(horizontalFov / 2) + rect.center.x;
                max.y  = cam.transform.position.z * Mathf.Sin(verticalFov / 2) + rect.center.y;
                print(max);
                rect.max = max;
            }
            rect.x = (int)rect.x;
            rect.y = (int)rect.y;
            rect.width = (int)rect.width;
            rect.height = (int)rect.height;

            return rect;
        }

        //set which side of the screen this cursor is allowed to be on, 0 for left 1 for right
        //centers the cursor on this side of the screen
        private void SetSide(int side)
        {
            //half the width of the rect
            borders.xMax = 0;

            if (side == 1)
            {
                //shift the rect over for the right side
                borders.x += borders.size.x;
            }
            
            //center the cursor in the new rect
            currentPos = borders.center;
            UpdatePosition();
        }
    }
}