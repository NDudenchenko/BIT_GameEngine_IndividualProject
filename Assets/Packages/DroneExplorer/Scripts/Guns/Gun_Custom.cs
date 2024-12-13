using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    /// I am the gun class I contain the template for the bullets that will shoot from me. I handel internal
    /// refire rate
    /// </summary>
    public class Gun_Custom : MonoBehaviour
    {
        public BulletPool bulletPool;
        public BulletPool_Custom bulletPoolC;
        public Transform bulletTransform;
        public bool shoot;          // flag to shoot
        public float refire;        // time between shots
        float refireCur = 0;        // current time conuter intil next shot

        public int team = 0;         // loyalty to not shoot self
        public float speed = 100;   // speed of bullet
        public float lifeTime = 5;  // how long the bullet will exist
        public float dammage = 1;   // how much dammge the bullet will do

        public float spray;         // bullet inacuracy 0 means perfect acuracy.
                                    // 1 means maximum aim woggle of one unit at 100 units

        public bool isCustomBulletPool = false;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // decriment refireCur
            if (refireCur >= 0) refireCur -= Time.deltaTime;

            if (Input.GetKeyDown(SFPSC_KeyManager.Shoot))
            {
                // shoot if shoot flag is on and refire timeout
                if (refireCur <= 0)
                {
                    refireCur = refire; // reset refire counter
                                        // tell bullet pool to fire a bullet at this position
                                        //BulletPool pool = BulletPool.instance;

                    if (!isCustomBulletPool)
                    {
                        if (bulletPool != null)
                        {
                            bulletPool.Shoot(bulletTransform, team, speed, lifeTime, dammage, spray);
                        }
                    }
                    else
                    {
                        //Custom
                        if (bulletPoolC != null)
                        {
                            bulletPoolC.Shoot(bulletTransform, team, speed, lifeTime, dammage, spray);
                        }
                    }
                }
            }
        }
    }
}