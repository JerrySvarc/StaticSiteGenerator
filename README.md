# StaticSiteGenerator

A command-line static site generator written in C# that compiles Markdown files
into a complete HTML website, featuring asynchronous per-file compilation.

Built as a coursework project for NPRG035/NPRG038 at Charles University.

## Requirements
- .NET 6.0 or higher

## Getting Started
```bash
git clone https://github.com/JerrySvarc/StaticSiteGenerator
cd StaticSiteGenerator
dotnet run
```

Running without arguments will create the required directory structure automatically.
To compile your site:
```bash
dotnet run compile
```

## Features
- Markdown to HTML compilation
- Asynchronous per-file compilation using C# async/await
- Auto-generated index page
- Configurable site metadata via config.json

## How to Use

### Directory Structure

Running the generator without arguments creates a **website** directory with the following structure:

- **output/** — Compiled HTML files and copied images are placed here. Copy this directory to a web server to deploy your site.
- **pictures/** — Place all images referenced in your Markdown files here.
- **posts/** — Place your Markdown files here. They will be compiled into HTML and placed in the output directory.
- **config.json** — Configures the footer and index page. Contains `Author` and `WebsiteName` fields.

You can create this structure manually, but letting the generator do it is the easiest approach.

### Writing Posts

Every Markdown file must begin with the following front matter:
```
---
Name: Your Post Title
---
```

### Supported Markdown

| Element | Syntax |
|---|---|
| Headings | `#` through `######` (plain text only, followed by an empty line) |
| Bold | `**text**` or `__text__` |
| Italic | `*text*` or `_text_` |
| Inline code | `` `text` `` |
| Unordered list | Line starting with `+` (plain text only) |
| Named link | `[name](url)` |
| Unnamed link | `[](url)` |
| Named image | `[alt](filename)` |
| Unnamed image | `[](filename)` |

### Compilation

Once your posts are in the **posts/** directory and images are in **pictures/**, run:
```bash
dotnet run compile
```

The generator will report the compilation status of each post and confirm whether the index file was created successfully.

### After Compilation

All compiled posts will appear in the **output/** directory as `.html` files, along with `index.html` and any images from the **pictures/** directory.

To style your site, add a `style.css` file to the output directory. If you know HTML, you can also customize `index.html` directly.
