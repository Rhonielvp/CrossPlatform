using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    public int rows = 2;
    public int columns = 5;
    public float tileWidth = 1;
    public float tileHeight = 1;
    public GameObject tileObjectTopLeft;
    public GameObject tileObjectTopMiddle;
    public GameObject tileObjectTopRight;
    public GameObject tileObjectTopMiddleLeft;
    public GameObject tileObjectTopMiddleRight;
    public GameObject tileObjectTopMiddleMiddle;
    public GameObject tileObjectTopbottomLeft;
    public GameObject tileObjectTopbottomRight;
    public GameObject tileObjectTopbottomMiddle;
    GameObject tileObjectToSpawn;

    public float scalingFactor = 1; // Level for map.
    
	// Use this for initialization
	void Start ()
    {
        //generatePlatform();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DestroyExistingTiles()
    {
        foreach (Transform t in this.transform.GetComponentInChildren<Transform>())
        {
            Destroy(t.gameObject);
        }

    }


    public void generatePlatform()
    {
        GenerateCollider();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)

            {
                float x = tileWidth / 2 + j * tileWidth;
                float y = tileHeight / 2 + i * tileHeight;
                Vector3 tilePosition = transform.position + new Vector3(x, y, 0);
                GameObject tileToSpawn;
                if (j == 0)
                {
                    if (i == rows - 1)

                    {
                        tileToSpawn = tileObjectTopLeft;

                    }
                    else if (i == 0)
                    {
                        tileToSpawn = tileObjectTopbottomLeft;

                    }
                    else
                    {
                        tileToSpawn = tileObjectTopMiddleLeft;
                    }
                }
                else if (j == columns - 1)
                {
                    if (i == rows - 1)

                    {
                        tileToSpawn = tileObjectTopRight;

                    }
                    else if (i == 0)
                    {
                        tileToSpawn = tileObjectTopbottomRight;

                    }
                    else
                    {
                        tileToSpawn = tileObjectTopMiddleRight;
                    }
                }

                else
                {
                    if (i == rows - 1)

                    {
                        tileToSpawn = tileObjectTopMiddle;

                    }
                    else if (i == 0)
                    {
                        tileToSpawn = tileObjectTopbottomMiddle;

                    }
                    else
                    {
                        tileToSpawn = tileObjectTopMiddleMiddle;
                    }
                }




                    GameObject InstantiatePlatform = Instantiate(tileToSpawn, tilePosition, Quaternion.identity);
                    InstantiatePlatform.transform.parent = this.transform;



                }
        }

    }

    void GenerateCollider()  // Generating the collider. Easy to generate a level.
    {
        if (!GetComponent<BoxCollider2D>())
        {
            gameObject.AddComponent<BoxCollider2D>();
        }


        BoxCollider2D myCollider = GetComponent<BoxCollider2D>();
        myCollider.size = new Vector2(columns * tileWidth, rows * tileHeight) / scalingFactor;
        myCollider.offset = new Vector2(columns * tileWidth, rows * tileHeight) / 2;


    }







}

