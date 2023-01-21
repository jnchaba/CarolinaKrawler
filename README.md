written by J. Chaba.

<h1> This project is indefinitely on pause as a relic of the first code I wrote. </h1>

<h3>description</h3>
<ul>
<li>this is a basic text-based RPG game written in C#</li>
<li>this game is a in-progress learning project/exercise</li>
<li>this game began development by following the instructions at https://scottlilly.com/learn-c-by-building-a-simple-rpg-index/</li>
</ul>

<h3>instructions</h3>
<ul>
<li>this is a basic text-based RPG written in C# in a windows form application</li>

<li>the players stats are displayed in the top left corner of the screen</li>
<li>below the stats is the player's inventory. this shows all weapons, medical items, and misc. items and their quantity.</li>
<li>below the inventory is the players quest log. for now, this only shows the quest and whether it is completed or not.</li>
<li>a text box containing the players current location and a description of that location is in the top right corner.</li>
<li>a text box containing messages from the game, such as enemies encountered, damage dealt, damage taken, items used, and items looted.</li>

<li>the game features a movement system based on a compass, and buttons to allow the player to move inside and outside certain buildings.</li>

<li>the game allows a player to interact with his/her inventory by selecting a weapon from a drop down box and hitting the "attack" button (if player has a weapon)</li>

<li>the game allows a player to interact with his/her inventory by selecting a medical item from a drop down box and clicking the "use" button (if player has a medical item)</li>
</ul>

<h1>current version 0.30</h1>

<h2>Initial Release 09/01/2018</h2>
<ul>
<li>version 0.19 release</li>
</ul>
<h2>Changelog 09/02/2018</h2>
<ul>
<li>fixed bug where player would face infinite enemies at locations</li>
<li>fixed bug where game would crash after acquiring keys to a car</li>
<li>changed stats of enemies to decrease initial difficulty</li>
</ul>
<h2>Changelog 09/04/2018</h2>

<h3>added new weapons</h3>
<ul>
<li>makeshift spear</li>
<li>rusty chain whip</li>
<li>baseball bat</li>
<li>baseball bat with nails</li>
</ul>
<h3>added containers</h3>
<ul>
<li>backpack</li>
<li>luggage</li>
<li>broken down cars</li>
</ul>
<h3>added enemies</h3>
<ul>
<li>looter</li>
<li>paranoid gas station employee</li>
<li>removed rural redneck</li>
</ul>
<h3>added locations</h3>
<ul>
<li>town square</li>
<li>town park</li>
<li>church grounds</li>
<li>church interior</li>
</ul>
<h3>version 0.20 released</h3>

<h2>UI changes</h2>
<li>resized compass</li>
	<li>separated compass controls from inside/outside controls, grouped under "world navigation"</li>
<li>resized inside/outside</li>
	<li>separated from compass controls, grouped under "local navigation"</li>
<li>resized weapon/medical item interface, fixed alignment</li>

<h2>Changelog 11/18/2019</h2>
<li>added containers and player interactions with containers</li>
<li>version 0.30 released</li>
<li>general code refactoring and de-spaghettification</li>
</ul>

<h3>Future update:</h3>
<li>fix infinite looting bug</li>
