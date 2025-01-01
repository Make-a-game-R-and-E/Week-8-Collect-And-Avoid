
## Week-8-Collect-And-Avoid
**Fruit Collector**

---
Game Description:
In this game, you play as a basket, and your goal is to collect 10 fruits to win.
Control the basket using the W, A, S, D keys.
Be careful from the bomb! Touching them will make you lose a life. If you lose all three lives, you'll be dead, and the game will end.

---
Game Rules:

- Collect 10 fruits to win.
- Avoid bombs – hitting them will cost you a life.
- Losing all three lives will result in a game over.

---
Class Relationships:
The game is structured with the following classes:

1.Player
* Responsible for controlling the player’s movement on the screen.
* Connected to Basket, which represents the main character (the basket).

2.Basket
* The main character controlled by the player.
* Connected to GameManager.

3.GameManager
Manages the game:
* Increases the score when a fruit is collected.
* Checks for a win when the score reaches 10 points.
* Decreases lives when a bomb is hit.
* Ends the game if the player loses all lives.

4.FoodSpawner
* Responsible for spawning fruits and bombs in random positions within the screen boundaries.
  
5.DestroyOffScreen
* Removes objects that move out of the screen boundaries, such as uncollected fruits or bombs.

![]()
---
Game Link:
Play on itch.io
