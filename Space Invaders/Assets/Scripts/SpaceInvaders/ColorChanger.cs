using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorChanger : MonoBehaviour { /*Script asignado a cada alien, por lo que tiene el renderer de ese gameobject
    Un gameObject no tiene un material, sino un renderer, y puede que a ese renderer tenga un material asignado*/
    /*
    public static ColorChanger instance;

    void awake()
    {
        instance = this;
    }
    */
    public static Material [] materials;
    public static Renderer rend;
    static int i=0;

	void Start () {
        rend = GetComponent<Renderer>(); //Pillo el renderer del gameObject       
        rend.enabled = true;
    }

    public static void changeColor()
    {
        /*
        ColorChanger.instance.i = Random.Range(0, 2);
        ColorChanger.instance.rend.sharedMaterial = ColorChanger.instance.materials[ColorChanger.instance.i];
        */
        //*
        i = Random.Range(0, 2);
        rend.sharedMaterial = materials[i];
        
        //*/
    }
}
