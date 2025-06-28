<div class="center">
  <p align=center>
  <img src="media/logo.png" width=50%;>
  <p align=center>
  <span class="description">Robert McAnany 2025</span>
</div>

## INTRODUCTION

Solid Edge Storekeeper is a utility for creating and organizing standard parts.  It is free and open source.  To try it out, see the [<ins>**Installation**</ins>](#installation) and [<ins>**Setup**</ins>](#setup) sections below.  Before you do, please take a moment to review the following section to learn what it does and how to use it.

## DESCRIPTION

The program handles two types of standard parts.  One consists of items like fasteners.  These are defined in dimension tables, accessed using a tree search, and created as needed.  The other consists of vendor-type items like pneumatic fittings.  Each of these has its own model file and is accessed by property search.

<p align="center">
  <img src="media/tree_search.png">
</p>

For items like fasteners, use **Tree Search**.  Navigate to the desired item, right-click and select `Add to assembly`.  If the item is already in your library, it is added to the assembly and the `Place Part` command is activated.  If not, it creates the new part, saves it to the library, then proceeds as above. 

<p align="center">
  <img src="media/property_search.png">
</p>

For vendor-type parts, use **Property Search**.  Enter the search terms, then click ![Search Button](media/icons8-search-16.png).  Locate the desired item on the list, then right-click and select `Add to assembly`.  Note, the program does not come with any of these; you're on you own for that.  Simply add what you need to the library, in a subdirectory if you prefer.  

That's pretty much all there is to know about vendor type parts.  For the others, a bit more information follows.

Fasteners, retainers and common structural shapes in both ANSI and ISO formats are included.  You can customize the contents and organization of the list to fit your needs.  You can even add new categories -- see the Custom Demo example to get started.

You can set the file names according to your preference.  You can specify the material or any other SE file property.  File names and properties can accept formulas as input.  So you can do stuff like:

![Filename Formula](media/filename_formula.png)

Regarding file names, structural shapes are handled differently.  While the cross section is standard, the length typically is not.  Also, they often are further modified with holes, slots, etc.  Rather than assuming a name and location, you are prompted for both.

Unlike Family of Parts, the files are only created as needed.  Also, each part is stand-alone, not tied back to a master file.

Unlike web-based offerings, the program is integrated with your parts library and works directly with Solid Edge.  It updates the properties you specify, using the naming conventions you define.  If you want adjustable parts (see the provided springs example), or any other SE-specific functionality, the program handles it like the native file that it is.

There is no database.  Everything is done in Excel.  Adding new parts or categories is straightforward.  If you upgrade Solid Edge to a new version, no changes to the program or its data are required.

The program will never have every possible stardard part in existence, but it can be improved.  That's where you come in!  Contributions are welcome.  Please message me on the Forum, or raise an Issue on GitHub, for guidance on how to get started.

## INSTALLATION

The preferred method is to clone the project and compile it yourself.  (If you clone, you'll still need a Release to get the data and templates.)  The other option is to use the [<ins>**Latest Release**</ins>](https://github.com/rmcanany/SolidEdgeStorekeeper/releases). It will be the top entry on the page. 

<p align="center">
  <img src="media/release_page.png">
</p>

Click the file `SolidEdgeStorekeeper-VYYYY.N.zip`.  You may have to expand the Assets dropdown to see it.  Your browser should prompt you to save it. 

Choose a convenient location on your machine. Extract the zip file (right-click > Extract All).  Verify the directory is not read-only (right-click > Properties).  The program needs write access to function properly.  

Double-click `Storekeeper.exe` to run.  The first time you do, you may get a `Windows Protected Your PC` message.  You can click `More Info` followed by `Run Anyway` to launch the program. 

## SETTINGS

The program needs to know where to store the standard parts, and, for fastener-like parts, where to find the files defining their shape and spreadsheet containing the dimensions.

The storage location of the standard parts is called the library.  The default is in the `Preferences\Library` directory under the Storekeeper main directory.  Note it is created the first time you run the program; it won't be there before that.  To change the library location, click ![Options](media/icons8_Folder_16.png) on the **Tree Search** toolbar.  If you want to access your vendor-specific standard parts, they must be in the library.  You can place them in subdirectories if desired.

The other settings for tree search are accessed on the Options dialog.  Click ![Options](media/Support_16.png) on the toolbar to open it.  These are described next.

<p align="center">
  <img src="media/tree_search_options.png">
</p>

- **TEMPLATE DIRECTORY** The templates are SE part files that have variable-table-driven geometry to create new parts of a given type.  By default they are stored in the `Preferences\Templates` folder.  Note, the templates were created in SE2024.  They will only work if you're using that version or newer.
- **DATA DIRECTORY** The spreadsheet contains the variables required for each size of each type of part.  By default, it is stored in the `Preferences\Data` directory.  
- **MATERIAL TABLE** The material table is usually your normal SE material table.  However, for a quick test of the program, an alternative is to use `Storekeeper.mtl` from `Preferences\Templates`.  Copy it to your Solid Edge `Preferences\Materials` directory to make it available.  If you decide to continue using the program, you would eventually want to reconcile material names, face styles, etc. with your own standards. 
- **OPTIONS**
  - `Read the Excel file each time the program is launched`  Internally, the Excel file is parsed and saved in `*.xml` format.  If you haven't changed the Excel file, this is an unnecessary step.  Clearing this option tells the program to use the `*.xml` file it created previously.
  - `Automatically pattern a part assembled to a patterned feature`  Standard parts, especially fasteners, are often patterned after placement.  The program can detect if a face used to assemble the item is part of a pattern.  This currently works with smart patterns, user-defined patterns, and patterns along curve.  It does not currently work with fast patterns, unless the added item was mated to the parent feature of the pattern.
  - `Add any property not already in file`  As mentioned above, besides creating geometry, the program can also update file properties.  Enabling this option tells the program to add any (custom) property that does not already exist in the file.
  - `Disable fine thread warning`  The program is currently unable to properly set the thread size for UNF external threads.  It warns you if that condition arises and provide instructions how to fix it.  Enabling this option suppresses that warning.
  - `Check for new version at startup`  If you don't need a reminder about new versions, disable the check here.

Additional settings for **Property Search** are accessed from that tab's toolbar.  Click the options button ![Options](media/Support_16.png) to display the form.

<p align="center">
  <img src="media/property_search_options.png">
</p>

**Properties to Search**

This is where you enter the names of the properties that hold the values you want to match.  You must also specify if the property is System or Custom.  System properties are in every Solid Edge file.  Custom properties are ones you define, probably in a template.

**Solid Edge Template Files**

These are your normal template files.  They are read to populate the available properties, and to determine what language is in use.

## DATA

This section is for those who want to customize the program.  It is not required knowledge to simply use it.

### Organization

Earlier I referred to "a spreadsheet."  In reality there are multiple spreadsheets.  One, `Storekeeper.xls` is the place where the overall layout of the data is handled.  The others are companion files that hold detailed information about a given category of parts.  These have names like `AnsiFasteners.xls`, `IsoStructural.xls`, etc.

While the use of Excel is handy, it's not all roses.  Representing an arbitrary-depth heirarchical tree is awkward, for one thing.  Here is how `Storekeeper.xls` is organized.

<p align="center">
  <img src="media/excel_top_level.png">
</p>

You'll see that the tree structure is represented by indenting.  The top node is `Solid_Edge_Storekeeper` and in this example its first child node is `Ansi_Fasteners_Steel`.  The first two child nodes under that are `BHCS` and `FHCS`.

In addition to child nodes under any given node, you'll notice other entries.  Those are various properties being assigned.  More about that below.

In the image, the `BHCS` and `FHCS` nodes each have an entry, `Nodes` (plural).  That is the mechanism that tells the program to consult a companion spreadsheet tab for further information.  Here is a small portion of the data for Dowel Pins.

<p align="center">
  <img src="media/companion_spreadsheet.png">
</p>

The rows represent different sizes, the columns represent values for a given size.  The first row holds the name for each value, the second holds its *type*.  The types `Variable` and `LeafNodeVariable` refer to variables in the template's variable table.

One other *type* not shown in the image is `ParameterString`.  That denotes a value that is passed to the template, but does not reside in the variable table, meaning there must be separate code to handle it.  Currently only `ThreadDescription` is supported.

### Properties and Variables

Now, let's look at the other entries in `Storekeeper.xls`, starting at the top.  

#### Top Level of the Tree

<p align="center">
  <img src="media/properties_top_level.png">
</p>

Here at the top level of the tree, we are defining spreadsheet variables for property names and their corresponding location in the Solid Edge file.  The location of the definition in the tree defines its scope.  Since these statements are at the top of the tree, they apply everywhere.

#### Next Level Down

<p align="center">
  <img src="media/properties_ansi_fasteners_steel.png">
</p>

In this image, we are looking at a tree node one level below the top.  You'll see we are setting values for the part number, hardware status and material.  

The name of the spreadsheet variable has rules.  `XyzProperty` looks for `XyzFormula` to know how to proceed.  The prefix, `Xyz` in this case, can be anything you want.  The suffix, `Property` and `Formula`, are the only valid choices.  

So, for example, to update the part number in the file, the program will use the information in `PartNumberFormula` to update the property defined in `PartNumberProperty`.  In this example that tells the program to make this assignment.

`%{System.Document Number} = "NA"`.

#### One More Level Down

<p align="center">
  <img src="media/properties_bhcs.png">
</p>

Here we are setting up the processing of button head capscrews.  You'll see we need to know what template to use and how to name the file.  We must also provide the companion spreadsheet name and the tab in that file where the information is stored.  

As mentioned above, formulas can contain entries such as `%{Name}` and `%{Length}`.  Variables not proceeded by `System.` or `Custom.` are assumed to come from the companion spreadsheet.

In this example, we are also updating the description property.  That isn't necessary for the program to function.  It just illustrates how to update Solid Edge file properties.  Any property in the file can be updated in this way.  

