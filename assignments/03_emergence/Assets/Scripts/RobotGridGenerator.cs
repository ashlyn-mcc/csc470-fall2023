using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotGridGenerator : MonoBehaviour{

// sets number of columns in grid
int columns = 35;

// sets number of rows in grid
int rows = 10;

int counter = 0;

//public GameObject dronePrefab;


// Prefabs used to generate grid of robots 
public GameObject robotPrefab;
public GameObject boxPrefab;

// Placeholders used to store new neighborhood data
public GameObject RobotPlaceholder;
private GameObject[] MyPlaceholders;

// 2D arrays used to store neighborhood status
RobotScript[,] robots;
RobotScript[,] updated;

    // Start is called before the first frame update
    void Start()
    {

    robots = new RobotScript[columns,rows];

     for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                float robotHeight = 2.2f;
                float robotWidth = 1.5f;
                float spacingX = 1f;
                float spacingY = 2.8f;

                float boxHeight = 5f;
                float boxWidth = 1.5f;
                float boxSpacing = 1f;

                Vector3 pos = transform.position;
                pos.x = pos.x + x * (robotWidth + spacingX);
                pos.y = pos.y + y * (robotHeight + spacingY);

                Vector3 pos2 = transform.position;
                pos2.x = pos2.x + x * (boxWidth + boxSpacing);
                pos2.y = pos2.y + y * (boxHeight);

                Quaternion newRotation = Quaternion.Euler(0, 90, 0);
                Quaternion newRotation2 = Quaternion.Euler(0, 90, 0);

                GameObject boxObj = Instantiate(boxPrefab, pos2, newRotation);
                GameObject robotObj = Instantiate(robotPrefab, pos, newRotation2);
                robots[x,y] = robotObj.GetComponent<RobotScript>();
            }
        }   
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        if (counter%400 == 0){
        updated =  new RobotScript[columns,rows];
        
        // Goes through each element in the 2D array
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                // Used in neighborhood calculations
                float numNeighbors = 0f;
                float neighborSum = 0f;

                // Empty game object created to store updated data in new Robot script
                GameObject placeholder = Instantiate(RobotPlaceholder, transform.position, transform.rotation);
                updated[x,y] = placeholder.GetComponent<RobotScript>();

                //Conditionals depending on location of the robot in the grid
                if ((x == 0) && (y == 0))
                {
                    numNeighbors = topLeftCorner(x, y, neighborSum);
                }

                else if ((x == 0) && (y == rows - 1))
                {
                    numNeighbors = bottomLeftCorner(x, y, neighborSum);
                }

                else if ((x == columns - 1) && (y == rows - 1))
                {
                    numNeighbors = bottomRightCorner(x, y, neighborSum);
                }

                else if ((x == columns - 1) && (y == 0))
                {
                    numNeighbors = topRightCorner(x, y, neighborSum);
                }

                else if (x == 0)
                {
                    numNeighbors = leftEdge(x, y, neighborSum);
                }

                else if (y == 0)
                {
                    numNeighbors = topEdge(x, y, neighborSum);
                }

                else if (x == (columns - 1))
                {
                    numNeighbors = rightEdge(x, y, neighborSum);
                }

                else if (y ==(rows - 1))
                {
                    numNeighbors = bottomEdge(x, y, neighborSum);
                }

                else
                {
                    numNeighbors = Central(x, y, neighborSum);
                }
            
                // Game of life rules implemented
                if ((robots[x, y].alive == false) && (numNeighbors == 3))
                {
                    updated[x, y].alive = true;
                    
                }
                else if ((robots[x, y].alive == true) && ((numNeighbors < 2) || (numNeighbors > 3)))
                {
                    updated[x,y].alive = false;
                }
                else
                {
                    updated[x,y].alive = robots[x, y].alive;

                }
            }
            
        }

        // Transfer updated neighborhood to original 2D array
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                robots[x, y].alive = updated[x, y].alive;
                    
                    if (robots[x, y].alive)
                    {
                        robots[x, y].spawn = true;
                    }
            }
        }


        // Finds and destroys the placeholder game objects 
        MyPlaceholders = GameObject.FindGameObjectsWithTag("Placeholder");
        foreach (GameObject empty in MyPlaceholders)
        {
            GameObject.Destroy(empty);
        }
        }
    }

// Neighborhood analysis of central robots
    float Central(int x, int y, float Sum1)
    {

        for (int x2 = -1; x2 < 2; x2++)
        {
            for (int y2 = -1; y2 < 2; y2++)
            {
                if (robots[x + x2, y + y2].alive)
                {
                    Sum1++;
                }
            }
        }
        if (robots[x, y].alive){
            Sum1 = Sum1 - 1;
        }
         return Sum1;
    }

// Neighborhood analysis of robots on left edge
    float leftEdge(int x, int y, float Sum2)
    {
        for (int x2 = 0; x2 < 2; x2++)
        {
            for (int y2 = -1; y2 < 2; y2++)
            {
                if (robots[x + x2, y + y2].alive)
                {
                    Sum2++;
                }
            }
        }
        if (robots[x, y].alive){
            Sum2 = Sum2 - 1;
        }
         return Sum2;
    }

// Neighborhood analysis of robots on top edge
     float topEdge(int x, int y, float Sum3)
     {
            if (robots[x - 1, y].alive) 
            {
                Sum3++;
            }
            if (robots[x - 1, y + 1].alive)
            {
                Sum3++;
            }
            if (robots[x, y + 1].alive)
            {
                Sum3++;
            }
            if (robots[x + 1, y + 1].alive)
            {
                Sum3++;
            }
            if (robots[x + 1, y].alive)
            {
                Sum3++;
            }
            return Sum3;
     }

// Neighborhood analysis of robots on right edge
    float rightEdge(int x, int y, float Sum4)
    {
        for (int x2 = -1; x2 < 1; x2++)
        {
            for (int y2 = -1; y2 < 2; y2++)
            {
                if (robots[x + x2, y + y2].alive)
                {
                    Sum4++;
                }
            }
        }
        if (robots[x, y].alive){
            Sum4 = Sum4 - 1;
        }
         return Sum4;
    }

// Neighborhood analysis of robots on bottom edge
     float bottomEdge(int x, int y, float Sum5)
     {
        for (int x2 = -1; x2 < 2; x2++)
        {
            for (int y2 = -1; y2 < 1; y2++)
            {
                if (robots[x + x2, y + y2].alive)
                {
                    Sum5++;
                }
            }
        }
        if (robots[x, y].alive){
            Sum5 = Sum5 - 1;
        }
         return Sum5;
     }

// Neighborhood analysis of robot at top left corner
    float topLeftCorner(int x, int y, float Sum6)
    {  
        if (robots[x + 1, y].alive)
            {
                Sum6++;
            }
        if (robots[x + 1, y + 1].alive)
            {
                Sum6++;
            }
        if (robots[x, y + 1].alive)
            {
                Sum6++;
            }
        
        return Sum6;

    }

// Neighborhood analysis of robot at bottom right corner
    float bottomRightCorner(int x, int y, float Sum7)
    {  
        if (robots[x, y - 1].alive)
            {
                Sum7++;
            }
        if (robots[x - 1, y - 1].alive)
            {
                Sum7++;
            }
        if (robots[x - 1, y].alive)
            {
                Sum7++;
            }
        
        return Sum7;

    }

// Neighborhood analysis of robot at bottom left corner
    float bottomLeftCorner(int x, int y, float Sum8)
    {  
        if (robots[x, y - 1].alive)
            {
                Sum8++;
            }
        if (robots[x + 1, y - 1].alive)
            {
                Sum8++;
            }
        if (robots[x + 1, y].alive)
            {
                Sum8++;
            }
        
        return Sum8;

    }

// Neighborhood analysis of robot at top right corner
    float topRightCorner(int x, int y, float Sum9)
    {  
        if (robots[x - 1, y].alive)
            {
                Sum9++;
            }
        if (robots[x - 1, y + 1].alive)
            {
                Sum9++;
            }
        if (robots[x, y + 1].alive)
            {
                Sum9++;
            }
        
        return Sum9;

    }
}
