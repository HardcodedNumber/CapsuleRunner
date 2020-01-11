# Capsule Runner

## Design
Since I only had 5 hours to complete this project. I decided to break this project into a per hour bases.
1. Basic Gameplay
    - Player Controls - Move the player
    - Level - Level design and generate the level
    - Fail Condition - When the player falls off the level
    - Checkpoints
2. Win/Lose State
    - End Game
    - Back to Main Menu
    - Timer
    - Level progression
    - Color Picker
3. Testing
4. Polish
5. Profit

The actual execution of this didn't happen. But it felt good to cross things off my list. The testing happened constantly. As well as some the issues caused me to push into the third hour.

## Project Description
Project is broken into two main folders:
1. Content
2. Source

Content contains all the assets and settings used in the project. This will contain Materials, Scenes, and Textures.

Source contains all the code used to develop this game. Each folder corresponds to a namespace. Source only contains one folder for Runtime, as there are no tools to be created for the editor.

## Code Structure
Here are some of the important classes to denote:

     GameplayService.cs - this contains the gameplay logic and determines what to do when the player falls off the ledge. It also keeps track of the time and resetting the player back to the correct checkpoint.

    MainMenu.cs - Handles all the UI input for the Main Menu scene, and allowing the user to pick any color to be used on their model.

    FailTrigger.cs - Sends an event when the player falls

    CheckpoinSystem.cs - Keeps track of the current checkpoint the user has passed and where the goal/finishline.

This project also uses custom editor, which can be found at: https://github.com/HardcodedNumber/UnityTipsTricks


## Time
I started this project at 11:30am and now its 15:39pm. Thus as I am writing this, the total time is a little over 4 hours

## The parts that were difficult for you and why
The most challenging part was getting the obstacles to move correct with the animation. Then, I realized I need to enable `Animate Physics` on the Animation Component.

## The parts you think you could do better and how
I think the design of the level could be a little better. I just ensured the player couldn't just press move forward and easily win. But add more tricky timing into the level.


## What you would do if you could go a step further on this game
1. Audio - I really wanted to add the Wilhelm scream when you were pushed off the level.
2. Add the player's name
3. Multiplayer
4. All the hardcoded strings for the UI to be localized


## What did you think
What did I think of the test? Well at first when I saw the game I had to make, I thought the first level was easy. Then after the animation issue I had, I was already in hour 2. I laughed and had to get a little more serious. It was fun to design the game and finish in the time.

## Any comment you may have
When adding this to the GitHub, it should be a private repo. Then, I should be able to add whomever as a contributor.