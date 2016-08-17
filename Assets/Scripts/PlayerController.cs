﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    //variables
    public Slider powerbar;
    public float targetspeed;
    public float currentspeed = 0;
    public float acceleration = 0.01f;
    public int terrainimin = 0;
    public GameObject mudeffect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        targetspeed = powerbar.value *10;
        if (currentspeed > 0.3)
        {
            mudeffect.SetActive(true);
        }
        else
        {
            mudeffect.SetActive(false);
        }
    }
    public void Movement()
    {
        if (terrainimin == 0)
        {
            acceleration = 0.015f;
        }
        if (terrainimin == 1)
        {
            if (powerbar.value < 0.2f)
            {
                acceleration = 0.005f;
            }
            else if (powerbar.value >= 0.2f && powerbar.value < 0.4f)
            {
                acceleration = 0.008f;
            }
            else if (powerbar.value >= 0.4f && powerbar.value < 0.6f)
            {
                acceleration = 0.004f;
            }
            else if (powerbar.value >= 0.6f && powerbar.value < 0.8f)
            {
                acceleration = -0.006f;
            }
            else if (powerbar.value >= 0.8f && powerbar.value <= 1f)
            {
                acceleration = -0.012f;
            }
        }
        if (terrainimin == 2)
        {
            if (powerbar.value < 0.2f)
            {
                acceleration = 0.004f;
            }
            else if (powerbar.value >= 0.2f && powerbar.value < 0.4f)
            {
                acceleration = 0.006f;
            }
            else if (powerbar.value >= 0.4f && powerbar.value < 0.6f)
            {
                acceleration = -0.005f;
            }
            else if (powerbar.value >= 0.6f && powerbar.value < 0.8f)
            {
                acceleration = -0.01f;
            }
            else if (powerbar.value >= 0.8f && powerbar.value <= 1f)
            {
                acceleration = -0.018f;
            }
        }
        if (terrainimin == 3)
        {

        }
        if (currentspeed < targetspeed)
        {
            currentspeed += acceleration;
        }
        else
        {
            if (currentspeed > 0)
            {
                currentspeed -= 0.015f;
            }
        }
        transform.position += transform.forward * currentspeed * Time.deltaTime;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "terrain1")
        {
            terrainimin = 1;
        }
        if (other.gameObject.name == "terrain0")
        {
            terrainimin = 0;
        }
    }
}
