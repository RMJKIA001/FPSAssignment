﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shootable : MonoBehaviour {

    public int currentHealth = 2;
    public TextMesh ScoreText;
    public GameObject ps;
    public GameObject hit;
    public void Damage(int damageAmount)
    {
        //subtract damage amount when Damage function is called
        currentHealth -= damageAmount;
        

        //hit.SetActive(false);
        //Check if health has fallen below zero
        if (currentHealth <= 0)
        {
            //if health has fallen below zero, deactivate it 
            // = gameObject.GetComponentInChildren<ParticleSystem>().gameObject;
            ps.SetActive(true);
            ps.transform.position = gameObject.transform.position;
            gameObject.SetActive(false);
            CollectableSpawner.NumCollectablesFound++;
            if (ScoreText != null)
            {
                ScoreText.text = "Objects Hit: " + CollectableSpawner.NumCollectablesFound;
                // Debug.Log(CollectableSpawner.NumCollectablesFound);
            }
        }
        else
        {
            ps.SetActive(false);
        }
    }
}
