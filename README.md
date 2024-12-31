# Week-8-Collect-And-Avoid

---

**Collect the Fruits**

**Game Description:**

In this game, you play as a basket, and your goal is to collect 10 fruits to win.  
You can control the basket using the W, A, S, D keys.  
Be careful from the bomb ! If you touch them, you lose a life. If you lose all three lives, you will lose, and the game will end.

---

**Game Rules:**

- Collect 10 fruits to win.  
- Avoid bombs – touching them will cause you to lose a life.  
- If you lose all three lives, the game will end in failure.

---

**Class Relationships:**

The game is structured with the following class relationships:

1. **Player**  
   * Responsible for the player's movement on the screen.  
   * Connected to the `Basket`, which represents the main character (the basket).

2. **Basket**  
   * The main character controlled by the player.  
   * Connected to the `GameManager`.

3. **GameManager**  
   * Responsible for managing the game:  
     - Increasing the score every time a fruit is collected.  
     - Checking for victory when the score reaches 10 points.  
     - Decreasing lives when hitting a bomb.  
     - Ending the game if the player loses all their lives.

4. **FoodSpawner**  
   * Responsible for spawning fruits and bombs at random locations within the screen boundaries.

5. **DestroyOffScreen**  
   * Deletes objects that go off-screen, such as uncollected fruits or bombs.

![Workflow](https://github.com/Make-a-game-R-and-E/Week-8-Collect-And-Avoid/blob/main/pictures/Workflow.png)

---

**Game Link:**

[itch](https://ronylevy1.itch.io/week-8-collectavoid)
