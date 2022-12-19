# TFT Comp Creator

This is a project that I've been working on for a while. With many tests I decided that it was stable enough to be released.

Bug testing is required !

Note: Project uses Newtonsoft.Json, get it in VS by doing: Tools > NuGet Package Manager > Manage NuGet packages for Solution...

[Example output 1](https://tftactics.gg/team-builder/eyJ0ZWFtIjpbeyJwb3NpdGlvbiI6IjEiLCJpZCI6IjcwM8QLdGVtcyI6W10sImxldmVsIjowfSzNMTLIMTY3ON8xxjHFV8Zi3zHHMTTJYjb~AJPHMTXKYsU83zE6IjbJYjjfYscxN8liMjDfMcYx5QDqxWI2+ACTXSwiY2hvc2VuIjpmYWxzZSwic2V0xTt9)

[Example output 2](https://tftactics.gg/team-builder/eyJ0ZWFtIjpbeyJwb3NpdGlvbiI6IjEiLCJpZCI6IjcwMsQLdGVtcyI6W10sImxldmVsIjowfSzNMcUmxDE2N8U83zE6IjPJMTg13zHGMTTKYjnfMcYxxVfEMTcx32LHMTbKMcVt3zE6IjfJMTD~AJPHMTjIMTY3~wFXxzHFV8UxNtgxXSwiY2hvc2VuIjpmYWxzZSwic2V0xWx9)

[Example output 3](https://tftactics.gg/team-builder/eyJ0ZWFtIjpbeyJwb3NpdGlvbiI6IjEiLCJpZCI6IjY2MsQLdGVtcyI6W10sImxldmVsIjowfSzNMcUmxjEz3zHGMcUmxjE03zHGMcUmxTE3Nd8xxjHFJsYxNt8xxjHFJsYxON8xxjE3yTE4~wD1xzHFV8YxxTzTMV0sImNob3NlbiI6ZmFsc2UsInNldMU7fQ==)

![immagine](https://user-images.githubusercontent.com/8062792/208544584-219a034c-2f2a-4825-84a4-37e2005dd6c7.png)



## Features
* #### Pet algorithm --> Fast hashing

  Hashing is a way to make a unique number, called a "hash," from data. It can be used to quickly compare and find data, which can speed up processes like creating a comp. 
  
  This allows computing all possible comps in about ~10 seconds (may depend on your computer specs.)
  

* #### Exclusion / Inclusion
	
    You can specify any desired or unwanted Traits / Champs

*  #### Nodes
	
    The Pet algo uses a list of nodes that represents the "connection" between a champion and another.
    
    It prioritizes the highest "relativeness" to the lowest and the size can be customized in the GUI.
    
    Higher nodes = better results (but also slightly higher computation time)
    
* #### Filters

	I've added a series of filters that increases customization.
    
    Note: the "Disallow unbalanced traits" checkbox will not allow a trait to have a different amount of champions compared to its breakpoints.
    
    	TL;DR: If Trait == Anima Squad (3/5/7) but Trait has a value of 6 (so it's active)
        the comp is considered unbalanced, therefore filtered out.
        
* #### Brute All Champs
	
    Brute force every possible comp

* #### Convert text comp to a valid tftactics.gg team

## Bugs n' stuff
* Random algorithm does not work, yet.
* ~~Can't specify an initial champion.~~
* Scoring algorithm, not used right now. Will probably add a functionality later that will make use of it.
* ~~A debug tab is there, but actually never used. You can use it as a notepad, lol. (will probably remove it)~~

## Design

It sucks I know, but it has never been my objective.

As long as it's minimalistic, I'm happy with it !

## LICENSE

[LICENSE](https://github.com/dragitz/TFT-Comp-Creator/blob/main/LICENSE)
