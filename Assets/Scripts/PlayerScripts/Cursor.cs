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
        public int borderW;
        public int borderH;
       
        
        [Tooltip("The amount of time that it takes for this to move one tile")]
        public float speed = 0.125f;
        [Tooltip("The time that the movement animation takes as a fraction of the movement time")]
        public float animationTime = 0.5f;
        
        private Material _defaultMaterial;
        private Sprite _defaultSprite;
        private TurretGrid _turretGrid;
        private SelectManager _selectManager;
        private SpriteRenderer _spriteRenderer;
        private float movementCooldown = 0;
        public Vector2 input;
        private Vector2 velocity = Vector2.zero;
        private Vector2 smoothingTarget;
        public bool movementEnabled = true;
        
        private void Start()
        {
            _turretGrid = (TurretGrid) FindObjectOfType(typeof(TurretGrid));
            _selectManager = GetComponentInParent<SelectManager>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _defaultMaterial = _spriteRenderer.material;
            _defaultSprite = _spriteRenderer.sprite;
            smoothingTarget = transform.position;
            
            //determine the borders
            borders = _calculateCameraRect();
            //adjust the borders to the selected side
            SetSide(side);
            //create the ui in the lower left corner of the screen
            Instantiate(uiPrefab, borders.min + offset, quaternion.identity);
            borders.Set(borders.x, borders.y, borders.width + borderW, borders.height + borderH);
        }

        private void FixedUpdate()
        {
            if (movementCooldown > 0)
            {
                movementCooldown -= Time.deltaTime;
            }
            //update the position
            if (movementEnabled)
            {
                Vector2 movement = Vector2.zero;
                if (movementCooldown <= 0)
                {
                    if (Math.Abs(input.x) > Math.Abs(input.y))
                    {
                        if (input.x > 0)
                        {
                            movement.x += _turretGrid.gridSize.x;
                        }
                        else
                        {
                            movement.x -= _turretGrid.gridSize.x;
                        }
                    }
                    else if (Math.Abs(input.y) > Math.Abs(input.x))
                    {
                        if (input.y > 0)
                        {
                            movement.y += _turretGrid.gridSize.y;
                        }
                        else
                        {
                            movement.y -= _turretGrid.gridSize.y;
                        }
                    }
            
                    if(borders.Contains(currentPos + movement))
                    {
                        currentPos += movement;
                        UpdatePosition(true);
                    }

                    movementCooldown = speed;
                }
            }
        }

        private void Update()
        {
            transform.position = Vector2.SmoothDamp(transform.position, smoothingTarget, ref velocity, speed * animationTime);
        }

        public void OnCursor(InputAction.CallbackContext value)
        {
            input = value.ReadValue<Vector2>();
           /* input = val;
            Vector2 movement = Vector2.zero;
            if (movementCooldown <= 0)
            {
                if (Math.Abs(val.x) > Math.Abs(val.y))
                {
                    if (val.x > 0)
                    {
                        movement.x += _turretGrid.gridSize.x;
                    }
                    else
                    {
                        movement.x -= _turretGrid.gridSize.x;
                    }
                }
                else if (Math.Abs(val.y) > Math.Abs(val.x))
                {
                    if (val.y > 0)
                    {
                        movement.y += _turretGrid.gridSize.y;
                    }
                    else
                    {
                        movement.y -= _turretGrid.gridSize.y;
                    }
                }
            
                if(borders.Contains(currentPos + movement))
                {
                    currentPos += movement;
                    UpdatePosition();
                }

                movementCooldown = speed;
            }
            
                
            
            /*if (borders.Contains(currentPos + val * sensitivity))
            {
                val.
                lastPos = currentPos;
                currentPos += val * sensitivity;
                UpdatePosition();
            }*/
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
        public void OnSecondaryClick(InputAction.CallbackContext value)
        {
            _selectManager.disablePurchase();
            _spriteRenderer.material = _defaultMaterial;
            _spriteRenderer.sprite = _defaultSprite;
        }
        
        private void UpdatePosition(bool smooth)
        {
            Vector2 pos = _turretGrid.GetGridPosition(currentPos);
            if (smooth)
            {
                smoothingTarget = pos;
            }
            else
            {
                transform.position = pos;
            }
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
                borders.x += borders.size.x + 1;
            }
            
            //center the cursor in the new rect
            currentPos = borders.center;
            UpdatePosition(false);
        }
    }
}