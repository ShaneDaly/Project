﻿using UnityEngine;
using System.Collections;

public class chase : MonoBehaviour
{

    public float fireRate;
    private float nextFire;
    public float timer = 6;
    public GameObject Planet;
    public float Speed = 60;
    private int MaxDist = 2000;
    public int range = 30;
    public enum State { ShootState, InvestState, RetreatState }
    public State state;
    private float curTime;
    public GameObject lasershot;
    public Transform shotspawn;
    GameObject[] planets = null;
    Transform Waypoint;
    float closestDist = -2;
    private CharacterController character;
    mover rocketMover;

    void Start()
    {
        character = GetComponent<CharacterController>();
        state = State.InvestState;
        Waypoint = GameObject.FindWithTag("Ship").transform;
        detectClosestEnemy();
    }

    void Update()
    {
        detectClosestEnemy();
        if (Planet != null)
        {
            TargetDistance();
            if (Planet.activeSelf == false)
            {
                state = State.RetreatState;
            }
        }



        switch (state)
        {
            case (State.InvestState):
                {
                    Investigating();
                    break;
                }
            case (State.ShootState):
                {
                    Shooting();
                    break;
                }
            case (State.RetreatState):
                {
                    Retreating();
                    break;
                }

        }
    }

    void Shooting()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            rocketMover = lasershot.GetComponent<mover>();
            rocketMover.target = Planet;
            Instantiate(lasershot, shotspawn.position, shotspawn.rotation);
        }
    }

    void Investigating()
    {
        detectClosestEnemy();
        transform.LookAt(Planet.transform);
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    void Patrolling()
    {
        transform.LookAt(Waypoint);
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    void Retreating()
    {
        transform.LookAt(Waypoint);
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    public void TargetDistance()
    {
        if (Vector3.Distance(transform.position, Planet.transform.position) <= MaxDist && (Vector3.Distance(transform.position, Planet.transform.position) >= range))
        {
            state = State.InvestState;
        }
        else if (Vector3.Distance(transform.position, Planet.transform.position) <= range)
        {
            state = State.ShootState;
        }
        else
        {
            state = State.RetreatState;
        }
    }

    public void detectClosestEnemy()
    {
        planets = GameObject.FindGameObjectsWithTag("Planet");
        float newDist;
        if (planets.Length > 0)
        {
            foreach (GameObject element in planets)
            {
                float dist = Vector3.Distance(element.transform.position, transform.position);
                newDist = dist;
                if (closestDist >= 0)
                {
                    if (newDist < closestDist)
                    {
                        closestDist = dist;
                        Planet = element;
                    }
                }
                else
                {
                    closestDist = dist;
                    Planet = element;
                }

            }
        }
        else
        {
            planets = GameObject.FindGameObjectsWithTag("Satellite");
            if (planets.Length > 0)
            {
                foreach (GameObject element in planets)
                {
                    float dist = Vector3.Distance(element.transform.position, transform.position);
                    newDist = dist;
                    if (closestDist >= 0)
                    {
                        if (newDist < closestDist)
                        {
                            closestDist = dist;
                            Planet = element;
                        }
                    }
                    else
                    {
                        closestDist = dist;
                        Planet = element;
                    }

                }
            }
            else
            {
                planets = GameObject.FindGameObjectsWithTag("Sun");
                if (planets.Length > 0)
                {
                    foreach (GameObject element in planets)
                    {
                        float dist = Vector3.Distance(element.transform.position, transform.position);
                        newDist = dist;
                        if (closestDist >= 0)
                        {
                            if (newDist < closestDist)
                            {
                                closestDist = dist;
                                Planet = element;
                            }
                        }
                        else
                        {
                            closestDist = dist;
                            Planet = element;
                        }

                    }
                }
            }
        }

    }
}