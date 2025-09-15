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

## V2025.4

### Fastener Stacks

Added the ability to create fastener stacks -- a grouping that consists of a fastener and related components, such as washers and nuts.  

<p align="center">
  <img src="media/fastener_stack.png">
</p>

The stack styles are pre-configured.  There are eight versions that employ nuts, and four each for thru and blind tapped holes.  Note, you only choose the fastener.  The related components are automatically selected based on the fastener diameter and thread.

<p align="center">
  <img src="media/fastener_stack_configuration.png">
</p>

The program automatically finds the correct length fastener, creates temporary subassemblies of the top and bottom components, and adds and disperses them in turn to the main assembly.  Once you position the parts, they are added to an `Assembly Group` and patterned if applicable.



See the [<ins>**Fastener Stack**</ins>](https://github.com/rmcanany/SolidEdgeStorekeeper#fastener-stack) section of the Readme for details.

### Alternate Data and Templates

Contributed by **@TeeVar.**  Thank you!

Added new templates created with SE2019 for users who don't use SE2024 or later.

Included are ISO screws, nuts, washers, and pins; EN structural steel; and DIN parallel keys.  They were created by an ISO native speaker, unlike me, so should be more familiar and useful to all of those in mm-land.

See the [<ins>**Setup**</ins>](https://github.com/rmcanany/SolidEdgeStorekeeper#setup) section of the Readme for details.

### Property Cache

Added an option to store property values of files in the library.  Set it on the `Property Search` options dialog.  It is meant to speed up property searches for large libraries.  Previously all files were searched every time.

### Other

- Added the ability to set standard parts name and location interactively (Thank you **@TeeVar!**).  Previously that option was set in the spreadsheet.

- Added the ability to use subdirectories in file names (Thank you again **@TeeVar!**).  The file names are specified in the spreadsheet.  To include subdirectories, simply preceed the file name with the directory names, eg. `Fasteners\BHCS\bhcs_%{Name}_%{Length}.par`.

- Added an option to keep the Storekeeper window always on top (Thank you one more time **@TeeVar!**).


## V2025.3

### Replace Part

Contributed by **@[Francesco Arfilli].**  Thank you!

Added the ability to replace selected parts in the assembly.

![Replace Part](media/tree_search.png)

- `Replace selected`  Replaces a selected part in the assembly.
- `Replace all`  Replaces all occurrences of a selected part in the assembly.


### Update Template File in Background

Contributed by **@[Francesco Arfilli]**.  Thank you!

Changed the template updating process for new parts.  The update can now occcur in the background.  Set the option on the Tree Search Options dialog.  Running in the background speeds up processing and eliminates the unexplained and confusing presence of a new part file in the interface.

### Pre-populate Library

Added the ability to selectively add items to the library ahead of time. (Thank you **@Seva!**)

![Prepopulate](media/prepopulate_library.png)

To select an item, enable its checkbox.  Checking on a category header selects all items below it.  You can select a category, then de-select any items you don't want included.  Once satisfied with the selection, click `Add to library` to start the process.

See the [<ins>**Pre-Populating the Library**</ins>](https://github.com/rmcanany/SolidEdgeStorekeeper#pre-populating-the-library) section of the Readme for details.

### Other

Fixed an issue where accessing certain file properties was causing an exception.  (Contributed by **@[Francesco Arfilli].**  Thank you!)

The following were all reported by **@TeeVar**.  Thank you!

- Fixed an issue where the form settings were not being saved in certain conditions.

- Fixed an issue where moving the program to a new directory did not allow the user to access the interface to update file locations.  

- Fixed an issue where the program was halting when Solid Edge versions prior to V2020 were being used.

- Fixed an issue where new standard parts were not being saved to the `Library` directory.

- Fixed an issue where commas were replaced with periods in variables and properties.  The fix is somewhat experimental.  Enable the `Allow comma delimiters` on the Tree Search Options dialog to try it.

## V2025.2

### Generate Xml File

Fixed an issue where locales with a comma decimal separator were getting invalid Xml headers, keeping the program from functioning.

### Readme

Added a section with things to consider when creating new templates.

Clarified the fact that the supplied templates were created in SE2024 and cannot be used with older versions.

## V2025.1
Initial release.
