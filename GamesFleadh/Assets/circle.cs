﻿using UnityEngine;
using System.Collections;

public class circle : MonoBehaviour {

    public Material mat;
    public Vector3 startVertex;
    public Vector3 mousePos;
    void Update()
    {
        
    }
    void OnPostRender()
    {
        if (!mat)
        {
            Debug.LogError("Please Assign a material on the inspector");
            return;
        }
        GL.PushMatrix();
        mat.SetPass(0);
        GL.LoadOrtho();
        GL.Begin(GL.LINES);
        GL.Color(Color.red);
        GL.Vertex(startVertex);
        GL.Vertex(new Vector3(mousePos.x / Screen.width, mousePos.y / Screen.height, 0));
        GL.End();
        GL.PopMatrix();
    }
    void Example()
    {
        startVertex = new Vector3(0, 0, 0);
    }
}
