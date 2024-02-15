The website and trailer for my game can be found at ashlynmcclendon.com/tanked



Ashlyn McClendon Final Project Proposal (Due 12/1)

For my final project I want to build off of my 05_units assignments. For that project, I created a fish tank with fish that have hunger metrics. I really like the design of this project, but I want to take the current work I’ve done on it and turn it from a demo into a working game.

As the project stands right now, there are five possible fish the player can spawn into the world. In addition to the fish, the player has the opportunity to either sell or feed them. Each fish starts with 100 hunger points. About every half-second this value is decreased by 1. Once a fish has less than 50 hunger points an exclamation point appears above it indicating it needs to be fed. Currently, there isn’t a way for the user to see the actual value of hunger points each fish has. They only get the exclamation point above their head.

To solve this issue, I plan to make each fish selectable. Upon selection their hunger metric, species, level, and worth will be shown in the UI. The tank starts by only allowing 12 fish to be spawned at a given time. There’s currently a “sell” feature that can remove a fish from the tank. I plan to make this a more integral part of the game by giving the user something in exchange for selling the fish. 

This ties into the level feature I want to add. For this, the longer a fish is kept alive and fed, the higher the level it will become. Players can then sell their fish in exchange for more spots in the tank. The higher the level == more spots earned for more fish. The “worth” that is displayed in the UI will indicate how many more fish in the tank a player can receive if they were to sell that particular fish. 

As for current game design, my food spawning code is operational, but flawed. If I spawn one food, and then spawn another before the previous one is eaten, the fish do not recognize the second one as their new target once the first is eaten. I plan to go in and rework this code to fix that bug. Another code issue I would like to fix is I want the fish to rotate towards the food source as they pursue it. Less of an issue, moreso something I think would be interesting would be having fish swim at varying y positions and turning before the reach the end of the tank. Their movements are very fixed right now. I think it would be neat to make them more dynamic.

I would like to add audio to my project. I am debating whether to include background music, opt for more realistic sound effects, or a combination of both. I plan to include bubble sound effects to bring life to the bubble particle emitters around the tank. 

Low Bar:

- Fish turn towards their target
- Multiple fish flakes can be spawned at one time without bugs
- Bubble sound effects
- Menu screen to enter the tank


Expected Target:

- Fish are selectable
- Fish level up based on their time alive
- Player can see fish metrics via the UI when a fish is selected
- Splash sound effect when fish are placed in the tank
- Fish can be sold in exchange for more spawn spots in the tank

High Bar:

- Multiple tanks where the user can select which one they want to play in on the main menu screen.
- Fish have natural looking variation in their y position as they swim

Progress Plan:

By Tuesday, December 5th:
All Low Bar items completed

By Friday, December 8th:
All target items completed -- core mechanics operational

By Friday, December 15th:
High level items completed
