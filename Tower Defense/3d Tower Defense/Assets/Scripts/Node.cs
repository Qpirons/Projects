using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color NotEnough;

    public GameObject turret;
    public Vector3 offset;

    private Color orignialColor;
    private Renderer rend;
    Build Builder;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        orignialColor = rend.material.color;
        Builder = Build.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!Builder.CanBuild)
        {
            return;
        }
        if(Builder.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = NotEnough;
        }
        
    }

    private void OnMouseExit()
    {
        rend.material.color = orignialColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!Builder.CanBuild)
        {
            return;
        }
        if(turret != null)
        {
            Debug.Log("cant build here");
            return;
        }
        Builder.BuildOn(this);
    }
    public Vector3 BuildPosition()
    {
        return transform.position + offset;
    }
}
