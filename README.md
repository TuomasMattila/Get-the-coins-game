# Get the coins game
 My first 3D game, created using Unity, Blender and Audacity.

**3D Virtual Environments and Applications
 Course work document**

**Tuomas Mattila**

**Introduction**
 I made a game called &quot;Get the coins!&quot; where you control a character, collect coins, and avoid ball shaped enemies. The game also includes two doors that must be opened to be able to collect all the coins. The doors are opened by stepping on buttons that are on the ground. The game has also a higher spot where the enemies cannot reach the player. The perspective from which the player plays the game is an aerial or bird&#39;s eye perspective. The objective of the game is to collect the coins as fast as possible. The software I used in the project were Unity, Blender and Audacity.

**Environment**

I modeled the whole environment [Figure 1] in Unity, except for the coins, which I made in Blender. The environment consists of a plane, cubes as walls and doors, buttons made from cylinders, and a capsule as an object to jump on. The only light in the environment itself is the Directional Light, but the coins and the enemies are equipped with lights that create dynamic lighting to the environment. The environment has invisible borders on all four sides to prevent the player from jumping off the map.

![](/README images/Picture1.png)

_Figure 1: The environment of the game._

**Player character**

The player character is a random 3rd person character I modeled in blender. I made an armature for character in Blender, which I used to create an idle animation and a running animation.

**Materials/shaders**

I used several PBR materials from cc0textures.com. All the PBR materials had at least albedo, metalness, roughness, normal and height maps. The capsule, walls, floor, doors, enemies, and coins have a PBR material assigned to them [Figure 2, materials 1-7].

![](/README images/Picture2.png)

_Figure 2: Materials used in the project. Materials 1-7 consist of textures downloaded from cc0textures.com. Materials 8-11 were made by me in Unity._

I had to make some changes to the height map intensity and tiling values in some cases. For example, I lowered the tiling of the PBR material applied to the enemies to make the details of the material more visible and increased the height map intensity of the material applied to the walls to give the walls a little more depth.

The materials I made myself were some simple one-color materials [Figure 2, materials 8-11]. The buttons have a grey metallic material for the base and either green or red color for the actual button. The player is covered by a blue metallic material.

Additionally, I used a shader that creates a white outline for the player character whenever it is behind something [Figure 3]. This was done using a free asset from the Unity&#39;s Asset Store called &quot;Quick Outline&quot;. The shader allows the player to always see where the player is.

![](/README images/Picture3.png)

_Figure 3: The white outline of the character seen through a wall._

**Animations**

The player, enemies and coins have animations. The player has an idle and a running animation, which I made in Blender using an armature I made for the character. The enemies are animated through the Nav Mesh Agent component, which makes them move and turn. I also animated the enemies&#39; material with a script to move, to make the movement of the enemies seem more &quot;realistic&quot;. The coins have a spinning animation, which I implemented using a script.

**Mesh models**

I created two mesh models using Blender: the player character [Figure 4] and the coin [Figure 5]. The game character is a simple low-poly model of a random character wearing a cap. The coin is quite self-explanatory: it is a mesh shaped like a cylinder, with a slightly indented circular areas in the middle of the top and the bottom.

![](/README images/Picture4.png)

_Figure 4: Mesh model of the player character._

![](/README images/Picture5.png)

_Figure 5: Mesh model of the coin._

The buttons [Figure 6] were made directly in Unity, using two cylinders. The other mesh models in the game are Unity&#39;s default 3D objects that I scaled and rotated.

![](/README images/Picture6.png)

_Figure 6: Mesh model of the button._

**NPCs**

The game has three ball shaped enemies as NPCs. The ball shape is the default sphere 3D object in Unity. The NPCs have a point light inside them, which gives the environment some dynamic lighting. The NPCs have an Nav Mesh Agent component attached to them, which makes them able to navigate the labyrinth using a navigation mesh. The NPCs are scripted to follow the player.

**Interactions**

The interaction techniques in the game include the buttons with which the player can move the character and the main menu point and click interaction using mouse. The player can move the character using either WASD or the arrow keys. The player can also jump by pressing space, restart the game with R and return to the main menu by pressing escape. There are three buttons in the menu, which the player can press by clicking them. The game can also be player with a controller, using the left stick to move and Y-button to jump. However, these are the only actions that are possible when playing with a controller, and therefore it is not recommended.

There are three main interaction mechanisms in the game: collecting a coin, pressing a button, and losing the game by touching an enemy. Every time the player touches a coin, a counter in the upper left corner of the screen is updated accordingly. The counter shows how many coins the player has collected and the total number of coins in the game. There are two doors in the game, which the player can open by stepping on buttons that are on the ground. The button also changes color when the player steps on it, giving the player a clear indication of the fact that the button has been pressed. If an enemy touches the player, the game is lost, and the player can either restart the game or return to the main menu.

There are also some hidden mechanisms in the game. The fastest way for the player to move around, is to press two buttons at the same time. This means that the player character moves faster diagonally than straight. This mechanism does not work on a controller, which is another reason why this game should be played with keyboard and mouse. Another hidden mechanism is the fact that the player can walk on walls by jumping on a wall from the capsule object. This also means that the player does not need to open both doors to win the game. These mechanisms could be considered bugs in the game, but they are not since I have left them there intentionally to make the game more interesting.

**Audio**

I intended to make the atmosphere of the game mystic through audio. All the audio clips used in the game are from freesound.org. I controlled the volume levels of individual sounds by making an audio mixer in Unity with a group for each sound. I had to cut some of the audio clips using Audacity. For example, I cut the footstep audio clip to make it loop better. Another example would be the button audio clip, from which I had to delete a bit of the audio clip from the start to make the sound more instant. Here is a table that includes the descriptions of the sounds in the game and the categories to which they belong to:

| **Sound** | **Description** | **Category** |
| --- | --- | --- |
| Footsteps | The player creates footstep sounds while running. | Diegetic, Interactive |
| Enemy | The enemies make a low rumbling sound, which creates a tense atmosphere in the game every time an enemy is close to the player. | Diegetic, Adaptive |
| Button | When the player presses a button, there is an echoing sound of a heavy button being pressed. The sound tells the player that the button was pressed and the echo in the sound indicates that the door is somewhere else in the environment. | Diegetic, Interactive |
| Coin | When a player collects a coin, there is a classic &quot;coin collected&quot; -sound. | Non-diegetic, Interactive |
| Ambient | There is always an ambient soundtrack in the background creating the mystic atmosphere for the game. | Non-diegetic, Nondynamic |
| Win | If the player wins the game, a cheerful congratulating sound comes up. | Non-diegetic, Adaptive |
| Lose | If the player loses, there is a short but sad sound with a pitch that goes does down rapidly. | Non-diegetic, Adaptive |

**Post-processing**

I used Unity&#39;s default post-processing package to finalize the look of the game. The post-processing effects the game utilizes are ambient occlusion, bloom, color grading, vignette and chromatic aberration.

**Performance optimization**

To optimize the game for better performance, I kept the models and lighting simple. The player character is a good example of the simple modeling: although it is the most complex mesh model in the game, it is still very low poly. I also made sure that I wrote the scripts to be as efficient as I could.
