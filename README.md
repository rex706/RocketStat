# RocketStat
Track your Rocket League stats across all games played while this program is running.

![alt tag](http://i.imgur.com/ELTN8Os.png)

Features

* Searches Rocket League's process memory to find the local player's values in a similar way to that of cheat engine or any 32 bit process debugging software.
 - searches for an array of bytes in memory, even if some bytes are unknown or dynamic, and adjusts accordingly to obtain the player's information.
* Serializes stats when they are saved so they cannot be edited by the user.


This program is essentially useless as the game tracks all of this information for you already, but was made to prove to myself I could do something like this. 


TODO:

* Use timers instead of pausing the application thread.
* Track all players played with and have option to include bots.
* Track total boost used and/or collected.