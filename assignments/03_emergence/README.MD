Assignment 3: Emergence
Ashlyn McClendon CSC-470
Game of life integration with robot/drone game demo
   
##Scripts: 

###CameraMovement
Placed on scene's main camera. Gets the player's mouse coordinates and alters the first person perspective (aka rotation) based on that mouse x and y and a sensitivity factor.

###DroneFlyingScript
Placed on drones that are instantiated into the scene. Uses Vector3.MoveTowards to cause drones to fly towards the main camera. If the drones collide with a laser shot by the player they are destroyed.

###LaserLaunch
Placed on empty game object at the end of player's blaster. When space is pressed a laser is instantiated in front of the barrel of the blaster and a force is added to its rigidbody launching it in the direction the player's mouse is facing.

###LaserScript
Placed on the instantiated lasers. If a laser collides with a drone the laser is destoryed.

###RobotGridGenerator
Placed on an empty game object that is on the ground of the scene. At the start of the game it creates a grid of boxes with robots inside. The robots function as the cells in the game of life integration. The scripts of these robots are placed into a 2D array. Every 100 times update is called the game of life rules are evaluated. The new cell states are stored in a secondary 2D array. After every cell in the grid has been evaluated the updated array is stored back in the original. The process of evaluation repeats.

###RobotScript
Placed on the instantiated robots in the game of life grid. Hold a boolean value "alive". On start, each robot is randomly chosen to be alive or dead. If alive, they are red and a drone is instantiated in front of them. Otherwise, they are black and nothing happens that cycle.