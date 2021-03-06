﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    public event Action onActivate = delegate { };
    public event Action onDeactivate = delegate { };

    [SerializeField] Color inactive;
    [SerializeField] Color active;
    

    [SerializeField] MeshRenderer mesh;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Character") || other.CompareTag("Player"))
        {
            
            mesh.material.SetColor("_BaseColor",active);
            mesh.material.SetColor("_EmissionColor",active);
            transform.Translate(new Vector3(0f, -0.05f, 0f));
            onActivate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Character") || other.CompareTag("Player"))
        {
            mesh.material.SetColor("_BaseColor", inactive);
            mesh.material.SetColor("_EmissionColor", inactive);
            transform.Translate(new Vector3(0f, 0.05f, 0f));
            onDeactivate();
        }
    }



}
