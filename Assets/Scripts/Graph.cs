using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;
    // Start is called before the first frame update

    [SerializeField, Range(1,500)] 
    int resolution;

    private Transform[] _points;
    void Awake()
    {
        Transform point;
        _points = new Transform[resolution];

        float step = 2f / resolution;
        var scale = Vector3.one * step;
        
        for (int i = 0; i < _points.Length; i++) {
            point = _points[i] = Instantiate(pointPrefab, transform, false);
            var x = (i + 0.5f) * step - 1f;;
            var y = f(x);
            point.localPosition = new Vector3(x,y,0);
            point.localScale = scale;
            
        }
    }

    float f(float x)
    {
        //lol its f(x) see?
        // var result = (Math.Pow(-2 * x, 3) + Math.Pow(-4 * x, 2) + x - 5);
        var result = Math.Sin((x + Time.time)*Math.PI);
        return (float)result;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            var point = _points[i];
            var pos = point.localPosition;

            pos.y = f(pos.x);
            //vector3 is a valuetype not a reference
            point.localPosition = pos;

        }
    }
}
