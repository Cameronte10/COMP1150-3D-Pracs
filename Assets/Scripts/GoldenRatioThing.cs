using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoldenRatioThing : MonoBehaviour
{
   public  GameObject obj;
    public int numPoints;
    public float turnFraction;
    GameObject[] points;
    public float pow;

    // Start is called before the first frame update
    void Start()
    {
        points = new GameObject[numPoints];
        for (int i = 0; i < numPoints; i++)
        {
            points[i] = Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity);
        }
            //for (int i = 0; i < BoidHelper.directions.Length; i++)
            //{
            //    Instantiate(obj, BoidHelper.directions[i], Quaternion.identity);
            //}
        }

    // Update is called once per frame
    void Update()
    {

        turnFraction -= 0.001f * Time.deltaTime;
        
        for (int i = 0; i < numPoints; i++)
        {
            float dst = Mathf.Pow(i / (numPoints - 1f), pow);
            float angle = 2 * Mathf.PI * turnFraction * i;

            float x = dst * Mathf.Cos(angle);
            float y = dst * Mathf.Sin(angle);

            points[i].transform.position = new Vector3(x, y, 0);
            
        }

    }

    private void OnValidate()
    {
       
    }
}
