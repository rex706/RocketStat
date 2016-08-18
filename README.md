# RocketStat
Track your Rocket League stats across all games played while this program is running.

![alt tag](http://i.imgur.com/ELTN8Os.png)

Features

* Searches Rocket League's process memory for an array of bytes to find the local player's values in a similar way to that of cheat engine or any 32 bit process debugging software.
* Serializes stats when they are saved so they cannot be edited by the user.

Latest version: 1.0.2

[Download](https://drive.google.com/file/d/0B2byNRcR0k4vakJ6NGZtMHJzbjQ/view?usp=sharing)

* Updated to work after a game patch removed the previous area that was used entirely. (Working as of 8/18/2016)
* Support for dynamic array masking.
* Check for updates on program start up.

This program is essentially useless as the game tracks all of this information for you already, but was made to demonstrate the AobMemScan class and to prove to myself I could do something like this. 


TODO:

* Use timers instead of pausing the application thread.
* Track all players played with and have option to include bots.
* Track total boost used and/or collected.