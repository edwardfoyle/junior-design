# Sky AutoTrack

Sky AutoTrack is an open sourced solution to electronic telescope alignment and astronomical research. This project was completed over the Fall 2016 and Spring 2017 semesters at Georgia Tech by Nicholas Button, Austin Dill, Edward Foyle, Meera Nathan, and Megan Yang.

## System Requirements

This desktop application has been tested on the following operating systems:

- Windows 10
- Windows 8
- Windows 7

In theory, it should work on any Windows Operating System.

## Telescope Requirements

- Must be an ASCOM compliant electronic telescope

## Hardware Requirements

In order to utilize the full capabilities of this application, you must have the following:

- Webcam
- Cable to connect your telescope and your computer and the corresponding driver

## Installation

Before this application can be installed, you must install the following:

1. [Python 2.7 or better](https://www.python.org/downloads/release/python-2713/) 
2. [ASCOM Platform 6.3 or better](http://ascom-standards.org/Downloads/Index.htm) 

#### If Compiling From Source

If you want to compile this yourself in order to make any custom changes to our application you will need to download [Visual Studio](https://www.visualstudio.com/downloads/).

After making any of your changes in the Visual Studio IDE, you can select publish from under the Build list on the toolbar.

#### If Running Executable

If you would like to run the application as initially designed, you can simply download the zip file from <Insert something here?>

## Features

#### Alignment

Though we have been unable to test with a physical telescope, using a simulator has allowed us to be the infrastructure for automated telescope alignment.

#### Astronomical Object Search

Our application can search for astronomical objects such as stars, galaxies, and constellations based on their common names. Upon returning the search results, the resultant coordinates can be used to direct the telescope towards the desired object.

#### Recording

Application sessions can be recorded and saved into a CSV file containing the datetime and the telescope's right ascension and declination.

#### Macros
Difficult and tedious tasks can be automated with the use of Sky AutoTrack's macro system. This is a simple programming language that allows users to set a sequence of actions for their telescope including record, slew, and park. 

This is the most easily extensible part of our application as it is an interpreted language with a resursive descent parser and a simple lexer. 
