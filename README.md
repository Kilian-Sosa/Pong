# Pong
 Pong game made in Unity

## Description

Pong is a classic video game considered one of the first, most successful, and popular ones. It was created by Atari and released in 1972 as one of the first arcade video game machines, "based" on the Magnavox Odyssey's Table Tennis game. In Pong, players control two paddles on opposite sides of the screen, using them to hit a ball back and forth. The goal is to make the ball pass to the opposite side of the screen and score points when the opponent fails to return it.

## Minimum Requirements

1. Add two GameObjects representing the player's paddles (PlayerPaddle) and the opponent's (CPUPaddle), adjusting their sizes and positions.
2. Add a GameObject representing the ball (Ball) and place it in the center of the scene.
3. Use additional GameObjects to draw the game field. Define the top line (TopLine), bottom line (BottomLine), and middle line (MiddleLine). All lines representing the game field should be children of a parent object named Field.
4. Ensure colliders for the objects that require them are correctly configured.
5. Ensure RigidBody2D for objects that require them are correctly configured.
6. The ball must have a correctly configured 2D Physics Material to bounce around the stage indefinitely.
7. The ball must have an associated script applying a physical force at a 45º angle (random) when first loaded. This way, the ball will start moving towards any of the four corners of the screen.
8. The player's paddle must have an associated script allowing exclusive movement up or down by applying a physical force.
9. The CPU paddle must have an associated script positioning it based on the vertical coordinate of the ball (applying a physical force). This way, something similar to "artificial intelligence" will be implemented for playing against the machine.
10. The ball script must consider that when it goes off-screen (escaped from either player), it should reposition itself in the center and restart its random movement towards one of the four corners.

## Extra Features

- Introduce the necessary improvements to keep track of points scored by each opponent, displayed on the screen through a TextMeshPro object.
- Research and implement a new ball hitting mechanic, making the paddle rotate by pressing a key.
- Add any other ideas that come to mind.
