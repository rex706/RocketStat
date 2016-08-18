# RocketStat
Track your Rocket League stats across all games played while this program is running.

This program searches Rocket League's process memory to find the local player's values in a similar way to that of cheat engine or any 32 bit process debugging software.
RockatStat searches for an array of bytes in memory, even if some bytes are unknown or dynamic, and adjusts accordingly to obtain the player's information.
This program is essentially useless as the game tracks all of this information for you already, but was made to prove to myself I could do something like this. 

![alt tag](http://i.imgur.com/ELTN8Os.png)

* Serializes stats when they are saved so they cannot be edited by the user.