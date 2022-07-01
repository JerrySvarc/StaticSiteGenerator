# Static site generator
This program is created as a semestral project for the NPRG035 and NPRG038 courses. 
## 1. Introduction
Static site generator is a program which generates static websites. Users create *Markdown* files which are then converted into *HTML*. Because of that, users don't need to know *HTML* to create websites. 

## 2. Functional description
After running the generator without any arguments a project directory will be created containing all the required directories. Users will then provide the *Markdown* files and images into their respective directories. After that, running the generator with the argument "compile" will compile everything and will create the output directory. 
Static site generator will be able to:
- read and parse the provided *Markdown* files - these are called posts 
- convert them into *HTML* 
- create an Index page in *HTML* 
- add a header and a footer to all *HTML* pages

## 3. Functional requirements
### 3.1 Parsing *Markdown* files
The markdown files must contain the tags "Author" and "Name" right at the top of the page. 
The static site generator will be able to parse and translate into *HTML* the following subset of *Markdown*:

|  Markdown                           |HTML                       |
|-------------------------------------|---------------------------|
|# Heading level 1                    |<h1>Heading level 1</h1>   |
|## Heading level 2                   |<h2>Heading level 2</h2>   |
|### Heading level 3                  |<h3>Heading level 3</h3>   |
|#### Heading level 4                 |<h4>Heading level 4</h4>   |
|##### Heading level 5                |<h5>Heading level 5</h5>   |
|###### Heading level 6               |<h6>Heading level 6</h6>   |
|__bold text__                        |<strong>bold text</strong> |
|**bold text**                        |<strong>bold text</strong> |
|_italic text_                        |<em>italic text</em>       |
|*italic text*                        |<em>italic text</em>       |
|`word`                               |<code>word</code>          |
|Unorderered list with "+", "*"       |                           |
| + First item                        | • First item              |
| + Second item                       | • Second item             |     
| ! [] (image.png)                    |will display the provided image|
|Link [Guide](https://www.google.com) | clickable Guide           |

### 3.2 Creating the Index page
The generated Index page will contain a list of all posts. The generator will use tags located inside of each *Markdown* file. 

### 3.3 Templating
The generator will only create the *HTML* files. Styling needs to be done by the user using CSS. 

## 4 Data inputs
The only data inputs are the *Markdown* files provided by the user along with images inside a special directory. 
