using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

namespace DroneExplorer
{
    /// <summary>
    /// Project: 
    /// This project enables the exploration of 3D space by way of a quad-copter drone. The intent 
    /// is to provide a quick drop in package to allow a user to explore a scene in the Unity Play 
    /// engine. The code is written to be modular and can incorporate other gameplay elements with 
    /// the addition of more scripts.
    /// 
    /// Author: Wilson Sauders 
    /// Email: HamsterUnity@gmail.com
    /// Date:   03 / 20 / 2022 
    /// 
    /// File:
    /// I contol a single bullet. I fly forward until I hit something. If that something has a HitTaker I will 
    /// add my dammage to the taker's total
    /// </summary>

    public class Bullet : MonoBehaviour
    {
        public TrailRenderer myTrail;   // visual trail of the bullet
        public int shooter;         // loyalty of the shooter so I don't dammage friendly hit takers
        public float speed;         // movement speed
        public float lifeTime;      // until I time out
        public float dammage;       // dammage I apply to target
        public ParticleSystem impact;   // burst animation on impact

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (lifeTime <= 0) return;


            // Timeout bullet
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0)
            {
                return;
            }


            // move bullet until it finds a collider
            if (speed > 0)
            {
                float curSpeed = speed * Time.deltaTime;
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit = new RaycastHit();
                bool isHit = false; // flag of a valid hit

                // check for impact
                if (Physics.Raycast(ray, out hit, curSpeed))
                {
                    // check impact collider for hit taker
                    HitTaker taker = hit.collider.GetComponent<HitTaker>();
                    // trigger impact if hitting a non hitTaker
                    if (taker == null)
                    {   // trigger impact if not a hit taker
                        isHit = true;
                    }
                    else if (taker.team != shooter)
                    {   // trigger impact if hitting a hitTaker that does not match the shooter
                        isHit = true;
                        taker.dammage += dammage;
                    }
                }

                // set end of life state for 
                if (isHit)
                {
                    // stop bullet at impact point
                    transform.position = hit.point;
                    speed = 0;
                    // set time out to when the trail will run out
                    lifeTime = 0;// myTrail.time;
                                 //myTrail.Clear();
                    impact.Play();
                }
                else
                {
                    transform.position += transform.forward * curSpeed;
                }
            }

        }

        //public void Shoot(Transform source, int _shooter, float _speed, float _lifeTime, float _dammage)
        //{
        //    transform.position = source.position;
        //    transform.rotation = source.rotation;
        //    shooter = _shooter;
        //    speed = _speed;
        //    lifeTime = _lifeTime;
        //    dammage = _dammage;

        //    myTrail.Clear();
        //}

        public void Shoot(Transform source, int _shooter, float _speed, float _lifeTime, float _dammage)
        {
            RaycastHit hitInfo;
            LayerMask layerMask = LayerMask.GetMask("Default");
            Physics.Raycast(SFPSC_FPSCamera.cam.transform.position,
                SFPSC_FPSCamera.cam.transform.forward, out hitInfo, 500000.0f);

            //Debug.DrawRay(SFPSC_FPSCamera.cam.transform.position, SFPSC_FPSCamera.cam.transform.forward * 1000,
                //Color.magenta, 20.0f);

            Quaternion RaycastRotation = Quaternion.FromToRotation(source.position, hitInfo.point);
            Quaternion RaycastRotation2 = Quaternion.FromToRotation(SFPSC_FPSCamera.cam.transform.position, hitInfo.point);
            Quaternion RaycastRotation3 = Quaternion.FromToRotation(source.position, SFPSC_FPSCamera.cam.transform.forward);
            //Debug.Log("RaycastRotation: " + RaycastRotation);
            //Debug.Log("RaycastRotation: " + RaycastRotation2);

            //float mouseY = Input.GetAxis("Mouse Y") * 3;
            //Vector3 rot = source.rotation.eulerAngles + (Vector3.right * mouseY);
            //transform.rotation = Quaternion.Euler(rot);

            //transform.rotation = Quaternion.Euler(SFPSC_FPSCamera.cam.transform.forward);
            //Debug.Log("RaycastRotation: " + Quaternion.Euler(SFPSC_FPSCamera.cam.transform.forward));


            //Vector3 projectedA = new Vector3(SFPSC_FPSCamera.cam.transform.forward.x, 0, SFPSC_FPSCamera.cam.transform.forward.z).normalized;
            //Vector3 projectedB = new Vector3(hitInfo.point.x, 0, hitInfo.point.z).normalized;
            //float angleA = Mathf.Atan2(projectedA.z, projectedA.x) * Mathf.Rad2Deg;
            //float angleB = Mathf.Atan2(projectedB.z, projectedB.x) * Mathf.Rad2Deg;
            //float angleBetween = Mathf.DeltaAngle(angleA, angleB);

            ///-----------
            Vector3 actorRot = source.rotation.eulerAngles;

            Vector3 cameraRot = SFPSC_FPSCamera.cam.transform.forward;
            //float cameraXAngle = Mathf.Atan2(SFPSC_FPSCamera.cam.transform.forward.y, SFPSC_FPSCamera.cam.transform.forward.z) * Mathf.Rad2Deg;

            //Vector3 resultRot = new Vector3(cameraRot.y, actorRot.y, 0);
            //Vector3 resultRot = new Vector3(-angleBetween, actorRot.y, 0);
            //Debug.Log("Result rotation: " + resultRot);
            //Quaternion resultRotQuart = Quaternion.Euler(resultRot);
            //transform.rotation = resultRotQuart;

            ///---------
            //float cameraxAngle = Mathf.Atan2(SFPSC_FPSCamera.cam.transform.forward.y, SFPSC_FPSCamera.cam.transform.forward.z) * Mathf.Rad2Deg;
            //Debug.Log("cameraYAngle: " + cameraxAngle);
            //Quaternion cameraYRotation = Quaternion.Euler(cameraxAngle * -1.0f, 0, 0);

            //transform.rotation = cameraYRotation * source.rotation;
            ///---------


            transform.position = source.position;
            transform.rotation = source.rotation;
            shooter = _shooter;
            speed = _speed;
            lifeTime = _lifeTime;
            dammage = _dammage;

            myTrail.Clear();
        }
    }
}