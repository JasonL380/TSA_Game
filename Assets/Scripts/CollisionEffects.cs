/* Name: Ryan Scheppler
 * date: 10/4/22
 * desc: Add this to run functions that work with events when collision occurs in different ways
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEffects : MonoBehaviour
{
    [Tooltip("Select layers this should interact with. Selecting nothing is pointless")]
    public LayerMask layerMask = int.MaxValue;

    public UnityEvent collisionEnterEvent = new();
    public UnityEvent collisionExitEvent = new();
    public UnityEvent collisionStayEvent = new();
    public UnityEvent collisionTriggerEvent = new();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //left shift a binary 1 over by the layer index number, layermasks have a 1 in each position that is checked, and the single & is a biwise and, so if it isn't 0 then the layer was in the mask
        if (((1 << collision.gameObject.layer) & layerMask) != 0)
        {
            collisionEnterEvent.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & layerMask) != 0)
        {
            collisionExitEvent.Invoke();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & layerMask) != 0)
        {
            collisionStayEvent.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & layerMask) != 0)
        {
            collisionTriggerEvent.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & layerMask) != 0)
        {
            collisionExitEvent.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & layerMask) != 0)
        {
            collisionStayEvent.Invoke();
        }
    }
}
