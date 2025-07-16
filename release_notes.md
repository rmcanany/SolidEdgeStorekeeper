<div class="center">
  <p align=center>
  <img src="media/logo.png" width=50%;>
  <p align=center>
  <span class="description">Robert McAnany 2025</span>
</div>

# Release Notes
Solid Edge Storekeeper is a utility to create, organize, and share standard parts.  It is free and open source and you can find it [<ins>**Here**</ins>](https://github.com/rmcanany/SolidEdgeStorekeeper#readme).  

Please note, the program has been tested on thousands of our files, but none of yours.  Do not run it on production work without testing on backups first.

Feel free to report bugs and/or ideas for improvement on the [<ins>**Solid Edge Forum**</ins>](https://community.sw.siemens.com/s/topic/0TO4O000000MihiWAC/solid-edge) or [<ins>**GitHub**</ins>](https://github.com/rmcanany/SolidEdgeStorekeeper/issues).

## V2025.3

### Update Template File in Background

Contributed by **@[Francesco Arfilli]**.  Thank you!

Changed the template updating process for new parts.  The update now occcurs in the background.  This speeds up processing and eliminates the unexplained and confusing presence of a new part file in the interface.

### Bug Fixes

Fixed an issue where the form settings were not being saved in certain conditions. (Thank you **@TeeVar!**)

Fixed an issue where moving the program to a new directory did not allow the user to access the interface to update file locations.   (Thank you again **@TeeVar!**)

Fixed an issue where accessing certain file properties was causing an exception.  (Thank you **@[Francesco Arfilli]!**)

## V2025.2

### Generate Xml File

Fixed an issue where locales with a comma decimal separator were getting invalid Xml headers, keeping the program from functioning.

### Readme

Added a section with things to consider when creating new templates.

Clarified the fact that the supplied templates were created in SE2024 and cannot be used with older versions.

## V2025.1
Initial release.
