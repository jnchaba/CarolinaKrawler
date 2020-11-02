written by J. Chaba.

<h1> This project is no longer being developed </h1>

-- description

*this is a basic text-based RPG game written in C#
*this game is a in-progress learning project/exercise
*this game began development by following the instructions at https://scottlilly.com/learn-c-by-building-a-simple-rpg-index/

*this project began on 08/30/2018

-- instructions

*this is a basic text-based RPG written in C# in a windows form application

*the players stats are displayed in the top left corner of the screen
*below the stats is the player's inventory. this shows all weapons, medical items, and misc. items and their quantity.
*below the inventory is the players quest log. for now, this only shows the quest and whether it is completed or not.
*a text box containing the players current location and a description of that location is in the top right corner.
*a text box containing messages from the game, such as enemies encountered, damage dealt, damage taken, items used, and items looted.

*the game features a movement system based on a compass, and buttons to allow the player to move inside and outside certain buildings.
	!reading the locations textbox is critical to understanding which button leads where!

*the game allows a player to interact with his/her inventory by selecting a weapon from a drop down box and hitting the "attack" button (if player has a weapon)

*the game allows a player to interact with his/her inventory by selecting a medical item from a drop down box and clicking the "use" button (if player has a medical item)

----------------current version 0.30-----------------------

Initial Release 09/01/2018

+ version 0.19 release

Changelog 09/02/2018

-- qualityOfLife updates
*fixed bug where player would face infinite enemies at locations
*fixed bug where game would crash after acquiring keys to a car
*changed stats of enemies to decrease initial difficulty

Changelog 09/04/2018

-- added new weapons
*makeshift spear
*rusty chain whip
*baseball bat
*baseball bat with nails

-- added containers
*backpack
*luggage
*broken down cars

-- added enemies
*looter
*paranoid gas station employee
-removed rural redneck

-- added locations
*town square
*town park
*church grounds
*church interior
+version 0.20 released

-- UI changes
*resized compass
	*separated compass controls from inside/outside controls, grouped under "world navigation"
*resized inside/outside
	*separated from compass controls, grouped under "local navigation"
*resized weapon/medical item interface, fixed alignment

Changelog 11/18/209
-- added containers and player interactions with containers --
+version 0.30 released
-- general code refactoring and de-spaghettification --

Future update:
* fix infinite looting bug
