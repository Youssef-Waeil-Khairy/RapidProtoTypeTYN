using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaurdProximitites : MonoBehaviour
{
    //points where the gaurd will patrol in
    public Transform pA;
    public Transform pB;
    private Transform currentP;

    //properties of the AI
    public float speed = 2f;
    public float waitingTime = 10f;
    public float proximityAngle = 45f;
    public float proximityRadius = 5f;
    private bool isWaiting = false;

    //the player
    public Transform player;
 
    void Start()
    {
        currentP = pA;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isWaiting) 
        {
            CarryOn();
        }
        
        DetectPlayer();
    }

    void CarryOn()
    {
        // gaurd moves to the target
        transform.position = Vector3.MoveTowards(transform.position, currentP.position, speed * Time.deltaTime);

        //check IF the gaurd has REACHED the Points , which ar pA, pB
        if(Vector3.Distance(transform.position, currentP.position) < 0.1f)
        {
            // the gaurd looks at prsion cell and then rotates
            StartCoroutine(WaitandTurn());
        }

    }

    IEnumerator WaitandTurn()
    {
        isWaiting = true;

        //wait the specifeid time given
        yield return new WaitForSeconds(waitingTime);

        //rotate
        transform.Rotate(0, 90, 0);

        // switch points
        currentP = (currentP == pA) ? pB : pA;

        isWaiting = false;
    }

    public void DetectPlayer()
    {
        // get vector from garud to player
        Vector3 playerPosition = player.position - transform.position;

        //is player in proximity? IF yes THEN....
        if(playerPosition.magnitude < proximityRadius) 
        {
            //get the angle
            float playersAngle = Vector3.Angle(transform.forward, playerPosition);

            if(playersAngle <= proximityAngle / 2 ) 
            {
                Debug.Log("u failed");
            }
        }

    }

    private void OnDrawGizmos()
    {
        //helps visualztion for player
        Gizmos.color = Color.red;

        //draws curves
        Vector3 forward = transform.forward * proximityRadius;
        Quaternion leftRotation = Quaternion.Euler(0, -proximityAngle / 2f, 0);
        Quaternion rightRotation = Quaternion.Euler(0, proximityAngle / 2f, 0);
        Vector3 leftSide = leftRotation * forward;
        Vector3 rightSide = rightRotation * forward;

        Gizmos.DrawLine(transform.position, transform.position + leftSide);
        Gizmos.DrawLine(transform.position, transform.position + rightSide);
        Gizmos.DrawWireSphere(transform.position, proximityRadius);


    }

}
