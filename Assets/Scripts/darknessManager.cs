using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class darknessManager : MonoBehaviour
{
    //List<Vector2> myPoints = new
    List<GameObject> darkSpots = new List<GameObject>();
    [SerializeField] GameObject prefabDarkSpot;
    [SerializeField] Vector2[] myBoundingPoints;
    [SerializeField] Vector2 shapeSize;
    [SerializeField] float shapeScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shapeSize = shapeSize * shapeScale;
        //Debug.Log("I'm here!");
        float columnOffset = 0;
        for(float x = myBoundingPoints[0].x; x <= myBoundingPoints[1].x; x += shapeSize.x)
        {
            //Debug.Log("doing the row!");
            columnOffset = Mathf.Abs(columnOffset - (shapeSize.y/2)); //alternate between 0 and half of the height
            for (float y = myBoundingPoints[0].y + columnOffset; y >= myBoundingPoints[1].y; y -= shapeSize.y)
            {
                //Debug.Log("column time!");
                GameObject mySpot = Instantiate(prefabDarkSpot, new Vector2(x,y), Quaternion.identity,this.transform);
                mySpot.transform.localScale = mySpot.transform.localScale * shapeScale;
                darkSpots.Add(mySpot);
            }
        }
    }

    // Update is called once per frame
    //void Update()
    //{
        //Debug.Log(Time.deltaTime);
        //Painter2D mypainting = new Painter2D();

        //mypainting.
    //}
}
