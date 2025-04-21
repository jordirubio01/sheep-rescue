# Sheep Rescue Minigame
In this repository, you will find a mini game called Sheep Rescue, developed from Eric Van de Kerckhove's Introduction to Unity Scripting tutorial. This project is an adaptation of the original tutorial, where new objects, materials, and sound effects have been added to enhance the gameplay experience.


## Description
In this mini game, the player controls a machine, and has to save sheeps from falling, feeding them with hay. In addition to the functionalities and features from the second part of the tutorial, I have added the following changes:

- In the `Sheep.cs` script, I added a `hasDropped` flag, similar to the existing `hitByHay`. I did this to prevent multiple calls to the `Drop()` method, as previously the drops were being counted twice.
- I enabled the Audio Source on the Music GameObject so that the soundtrack plays during the game in loop.

## How to Play
First Way:
1. Clone or download this repository.
2. Open the project in Unity.
3. Run the main scene and start playing!

Second Way:
1. Download the Builds folder.
2. Run sheep-rescue.exe.

How the game should look like:
![image](https://github.com/user-attachments/assets/029abeab-0db6-469c-a08c-5bd9b1238b80)
