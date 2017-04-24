# Realease Notes

## New Features:

- Macro system with commands for parking, slewing, and recording.
- Astronomical object search using household names.
- Recording with ability to save to CSV file.
- Advanced user settings including lattitude, longitude, RA rate, and DEC Rate.

## Missing Features:

- Connectivity to any ASCOM telescope should work but is currently untested. 
- The basic mechanism for alignment is there but is not operational due to the lack of telescope for testing.

## Known Bugs

- Always save a Recording Session after you are done if you plan on opening another. There is an unsolved resource allocation problem otherwise.
- There is the back-end for "for-loops" in the parser, so "for" tokens are accepted by the parser but are not interpreted or carried out by the application.
