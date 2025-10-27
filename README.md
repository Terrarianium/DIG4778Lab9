# DIG4778Lab9

The Object Pool Pattern was implemented with a bullet pool for player projectiles. There is a bullet pool gameobject with deactivated bullet children. The player, when firing, pulls a bullet from that gameobject, removes its parent, and moves it to its position before activating it. The bullet will travel until it hits a meteor or its lifespan ends. It will then reset its parent to the bulletpool and deactivate again.

The Builder Pattern was implemented with the creation of meteors. A meteor spawning script has references to three different meteor builder scripts. All three builder scripts inherit from an interface that defines methods for a meteor's size, velocity, and color. The different builder scripts initialize a default meteor, than apply these methods, plus a tag, and destroy the meteor after the time during which it was in camera passed.

The Observer Pattern was implemented with the scoring system when destorying meteors. When a meteor is destroyed, a delegate that accepts one integer, the score gain, is called. A script that manages the score has a score update method that subscribes to an event with this delegate at the start of the game. The score update method will then change the score to include the score gained.

The meteors have their location, rotation, and transform saved and loaded using a TransformSaver. The Transform saver saves a key for each of these values plus a save id in a json file. A saving service class is used to actually call the saving and loading. Loading can be done by pressing the 'L' key and saving is done by pressing the 'S' key.

The score of the player gets saved through binary serialization through the 'Enter' key, and loads the relevant data to the script with the 'L' key.
