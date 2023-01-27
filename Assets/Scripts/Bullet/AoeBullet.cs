// Name: Jason Leech
// Date: 01/27/2023
// Desc:

using UnityEngine;

namespace Utils.Bullet
{
    public class AoeBullet : BasicBullet
    {
        public float aoeRange;
        public override void OnCollide(Collider2D collision)
        {
            //TODO: souls stuff

            Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, aoeRange, targetLayers);
            int len = collider2Ds.Length;
            for (int i = 0; i < len; ++i)
            {
                GameObject hit = collider2Ds[i].gameObject;

                Health health = gameObject.GetComponent<Health>();
                if (health != null)
                {
                    health.takeDamage(damage);
                }
            }
        }
    }
}