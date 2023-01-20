/* Name: Zak Baydass
 * Date: 9/28/22
 * Desc: making a camera controller that will follow player smoothly and has screenshake avaliable. (add to main camera object)
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Tooltip("will center on this object")]
    public GameObject target;
    [Tooltip("Keep between 0 and 1, the closer to 1 the faster it centers"), Range(0, 1)]
    public float SmoothVal = 0.5f;

    //screenShake Variables
    [SerializeField, Tooltip("time to shake if you want it to start immediatly")]
    private static float shakeDuration = 0;
    [SerializeField, Tooltip(" how violent to shake if shaking initially")]
    private static float shakeMag = 0;

    static float startShakeDuration;


    // Start is called before the first frame update
    void Start()
    {
        startShakeDuration = shakeDuration;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // make sure target exists
        if (target != null)
        {
            //grab the target location
            Vector3 targetPos = target.transform.position;
            //adjust the z value correctly
            targetPos.z = transform.position.z;

            //screenshake effect stuff
            if (shakeDuration > 0)
            {
                shakeDuration -= Time.fixedDeltaTime;
                Vector2 randShake = Random.insideUnitCircle * Mathf.Lerp(shakeMag, 0, 1 - (shakeDuration / startShakeDuration));

                transform.position += new Vector3(randShake.x, randShake.y, 0);
            }
            //move towards that position each FixedUpdate
            transform.position = Vector3.Lerp(transform.position, targetPos, SmoothVal);
        }
    }
    //call this function to start the screen shake
    public static void StartShake(float duration, float magnitude)
    {
        //only set if greater than previous values
        if(duration > shakeDuration)
        {
            shakeDuration = duration;
            startShakeDuration = duration;
        }
        if(magnitude > shakeMag)
        {
            shakeMag = magnitude;
        }
    }
}
