# DIG4778Lab9

The Object Pool Pattern was implemented with a bullet pool for player projectiles.

The Builder Pattern was implemented with the creation of meteors. A meteor spawning script has references to three different meteor builder scripts. All three builder scripts inherit from an interface that defines methods for a meteor's size, velocity, and color. The different builder scripts initialize a default meteor, than apply these methods, plus a tag, and destroy the meteor after the time during which it was in camera passed.

The Observer Pattern was implemented with the scoring system when destorying meteors.
