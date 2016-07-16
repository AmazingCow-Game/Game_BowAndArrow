# Game_BowAndArrow

**Made with <3 by [Amazing Cow](http://www.amazingcow.com).**


<!-- ####################################################################### -->
<!-- ####################################################################### -->

## Description:

```Game_BowAndArrow``` is a small _"quasi"_-remake of the John di Troia's Bow & Arrow.   
You can find more info about the original game in 
[Classic DOS Games](http://www.classicdosgames.com/game/Bow_and_Arrow_-_In_Search_of_the_Greatest_Archer.html)

It was developed in C# using [Monogame](http://www.monogame.net/).

<br>
As usual, you are **very welcomed** to **share** and **hack** it.


<!-- ####################################################################### -->
<!-- ####################################################################### -->

## Dedication

This game is dedicated to 
[Instituto Mario Penna](http://www.mariopenna.org.br/).   

Take a 5 min break, take a look their site and find a way to help them :D

Thanks! 


<!-- ####################################################################### -->
<!-- ####################################################################### -->

## Download & Install:

#### Option 1 - Source packages, _almost_ just download and play.

**Check notes bellow about source install.**


#### Option 2 - Clone / Fork the repo and hack it.

Also you can just ```git clone https://github.com/AmazingCow-Game/Game_BowAndArrow``` 
to grab the latest version of sources.    
You should (and probably will) be good to go!

**Check notes bellow about source install.**


#### Notes:

The **development** libraries for Monogame are required. 

Assuming that you have the libs installed, we made a Makefile 
that installs the game into your system.    

So just type:   
``` bash 
make dev-build    ## To generate the build.
sudo make install ## To install the game.
``` 

With the appropriated privileges and start gaming :D

The ```install``` target will create a ```.desktop``` entry in ```games```
sub-menu. So you can play clicking it or typing ```bow-and-arrow``` in your 
terminal.


<!-- ####################################################################### -->
<!-- ####################################################################### -->

## Dependencies:

```Game_BowAndArrow``` depends on:

* [Monogame](http://www.monogame.net/).

To generate the archives using the Makefile target ```gen-archives```
the [git-archive-all](https://github.com/Kentzo/git-archive-all) is also needed


<!-- ####################################################################### -->
<!-- ####################################################################### -->

## License:

This software is released under GPLv3.



<!-- ####################################################################### -->
<!-- ####################################################################### -->

## TODO:

Check the TODO file for general things.

This projects uses the COWTODO tags.   
So install [cowtodo](http://www.github.com/AmazingCow-Tools/COWTODO) and run:

``` bash
$ cd path/to/the/project
$ cowtodo 
```

That's gonna give you all things to do :D.



<!-- ####################################################################### -->
<!-- ####################################################################### -->

## Others:

Check our repos and take a look at our 
[open source site](http://opensource.amazingcow.com).
