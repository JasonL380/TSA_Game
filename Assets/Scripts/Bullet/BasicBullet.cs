// Name: Jason Leech
// Date: 01/27/2023
// Desc:

using UnityEngine;

namespace Utils.Bullet
{
    public class BasicBullet : MonoBehaviour
    {
        //the turret that shot this bullet
        public Turret turret;
        public LayerMask targetLayers;
        public int damage;
        
        /// <summary>
        /// Runs on collision with an object
        /// </summary>
        /// <param name="collision">The collider that the bullet collided with</param>
        public virtual void OnCollide(Collider2D collision)
        {
            //TODO: add souls to something
            collision.gameObject.GetComponent<Health>().takeDamage(damage, turret);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (((1 << col.gameObject.layer) & targetLayers) != 0)
            {
                OnCollide(col.collider);
            }
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (((1 << col.gameObject.layer) & targetLayers) != 0)
            {
                OnCollide(col);
            }
        }
    }
}