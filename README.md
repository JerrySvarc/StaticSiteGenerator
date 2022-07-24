---
Name: User guide
---
# Static site generator

This program is created as a semestral project for the NPRG035 and NPRG038 courses. 

## Introduction

Static site generator is a program which generates static websites. Users create *Markdown* files which are then converted into *HTML*. 
Because of that, users don't need to know *HTML* to create websites. 

## How to use the static site generator

### Before creating any posts

The generator requires special directories and a configuration file to be able to compile the posts into **HTML**. 
The simplest way to ensure that all the necessary exist you just need to run the _static site generator_ without any arguments.
The generator will the create the **website** directory containg the following directories and a config file:
+ output: All markdown posts will be compiled into this directory. Also all pictures from the pictures directory will be copied here. You can then copy this directory to a web server and the website should work.
+ pictures: You should put all your pictures referenced in the markdown text here. 
+ posts: You should put all of your markdown posts into this directory. They will be then compiled into html and put into the output directory.
+ config.json: This configuration file is used the create the footer for all pages and also the index page. It contains the "Author" and "WebsiteName" fields which you can change before compilation of the website.

These are all the required directories and files. You can also create the directories and files yourselves but leaving the creation up to the generator is by far the easiest choice.

### Supported subset of Markdown

All markdown files(posts) must contain the tag and "Name" right at the top of the page like this: 
```
--- //First line of the file
Name: A website name
---
```
The static site generator will be able to parse and translate into *HTML* the following subset of *Markdown*:
+ plain text
+ headings
+ bold text
+ italic text
+ coded text
+ unordered list items
+ a link to another page
+ an image reference

#### Headings

The generator supports headings up to the level 6. A heading is a single line beginning with a hashtag. To ensure that the generator recognizes the heading:
+ Use plain text only after the hashtag (no emphasised text, etc.).
+ Separate the heading and the following text with an empty line.

#### Bold text

Plain text surrounded by "**" or "__" on both sides will be compiled into bold text. 

#### Italic text

Plain text surrounded by "*" or "_" on both sides will be compiled into italic text. 

#### Coded text

Plain text surrounded by "`" on both sides will be compiled into coded text. 

#### Unordered list

A line beginning with a "+" symbol will be compiled into an unordered list item. To ensure that the generator recognizes the list item use plain text only after the plus symbol (no emphasised text, etc.).

#### Link to another page

A link to another page can be either named or unnamed: 

+ Named: name inside square brackets followed by a link inside normal brackets
+ Unnamed: empty square brackets followed by a link inside normal brackets

#### Reference to an image

A reference to an image can be either named or unnamed: 

+ Named: name inside square brackets followed by a name of the picture inside normal brackets
+ Unnamed: empty square brackets followed by a name of the picture inside normal brackets

### Compilation of the website

After creating all posts inside the posts directory and putting all the necessary images inside the pictures directory, you can run the 
generator outside or inside the website directory. To start the compilation, run the generator with the argument "compile".
This will start the compilation and will display when a certain post has finished compiling or wether there has been an error during 
compilation. It will also inform you wether the index file has been successfully created. 

### After compilation

If there has been no errors, all posts should be compiled inside the ouput directory. The posts should have their original name followed by the extension **.html**. 
The output directory should also contain the index.html file and all pictures from the pictures directory.
You can the style the website by creating a "style.css" file and adding some *css*.
If you know **HTML**, you can change the index.html to your liking. You can add paragraphs, pictures etc. 


