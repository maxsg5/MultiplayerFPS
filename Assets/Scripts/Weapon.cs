using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletHolePrefab;

    float elapsedTime = 0f;
    float fireRateTime = 0f;
    float fireRateResetDelay = 0.5f; //The delay it takes for accuracy to be perfect again (first shot accuracy)
    float maxAccuracyVariance = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        fireRateTime += Time.deltaTime;
        elapsedTime += Time.deltaTime;

        if (fireRateTime > 0.5f) fireRateTime = 0.5f;
        //AYO FIX THIS @MAX PLZ
        if (Input.GetMouseButtonDown(0))
        {
            float directionVariance = (fireRateResetDelay - fireRateTime)/maxAccuracyVariance;
            float xVariance = (float)Random.Range(-directionVariance, directionVariance);
            float yVariance = (float)Random.Range(-directionVariance, directionVariance);
            Vector3 direction = new Vector3(xVariance,yVariance,1);
            Debug.Log($"Shot Direction: ({xVariance}, {yVariance}, 1)");

            Shoot(transform.position, direction);
            fireRateTime = 0f;
        }

        //if(elapsedTime > 1f)
        //{
        //    Shoot(transform.position, transform.forward);
        //    elapsedTime = 0f;
        //}
    }

    public void Shoot(Vector3 orgin, Vector3 direction)
    {
        RaycastHit hit;

        if (Physics.Raycast(orgin, direction, out hit, 1000f))
        {
            if(hit.transform.tag == "Player")
            {
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red, 1f);

                Debug.Log("Hit Player");
            }
            else
            {
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow, 1f);
                Instantiate(bulletHolePrefab, hit.point, Quaternion.LookRotation(hit.normal));
                Debug.Log("Did Hit");
            }
            
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white, 1f);
            Debug.Log("Did not Hit");
        }
    }
}
