# DKCUI

[![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://dotnet.microsoft.com/en-us/languages/csharp) [![forthebadge windows11](https://raw.githubusercontent.com/RWELabs/DKCUI/main/Resources/badgew11.svg)](https://windows.com)

### What is DKCUI?
DKCUI is a graphical user interface frontend to the [DKC Toolbox](https://www.github.com/H4v0c21/DKC-Toolbox) framework by [H4v0c21](https://www.github.com/H4v0c21/). DKCUI is an application that seeks to parse commands through a graphical user interface to the DKC Toolbox, in an attempt to make using the DKC Toolbox framework more user friendly.

### Unique Features
#### Setup and Install
DKCUI comes with a standard Windows installation wizard, as most users will be familiar with. This will guide the user through installing the application on Windows based machines. Once the application is installed, the application will undergo a 'first-run setup', where it will intialise and run a few checks to ensure that the software is going to work. This includes but is not limited to; the extracting of DKC Toolbox, Initialising Python and ensuring that the Python installation is of a compatible version and downloading any required Python dependencies. This first run setup may be required when updating to a new version of the DKCUI application.

#### Updates and Recovery
DKCUI comes with the ability to check for updates, not only for DKCUI but for the DKC Toolbox as well. This also means the DKC Toolbox can be updated independently of DKCUI.

#### Command Line
DKCUI gives you full access to the Python command line as you interface with the DKC Toolbox. You can provide DKC Toolbox commands from the DKCUI application.

##### Commands
| **#** | **Command**                    | **Usage**              |
|-------|--------------------------------|------------------------|
| x     | exit                           | (exits the application) |
| c/h   | commands/help                  | (lists all commands)   |
| 1     | import_palette_image           | <input_image_path> <rom_path> <palette_address>                     |
| 2     | export_palette_image           | <rom_path> <palette_address> <number_of_colors> <output_image_path>                    |
| 3     | import_palette_pal             | <input_pal_path> <rom_path> <palette_address>                     |
| 4     | export_palette_pal             | <rom_path> <palette_address> <number_of_colors> <output_image_path>                     |
| 5     | import_raw_bin                 | <input_bin_path> <rom_path> <data_address>                     |
| 8     | export_raw_bin                 | <rom_path> <data_address> <number_of_bytes> <output_bin_path>                     |
| 7     | import_rareware_palette_image  | <input_image_path> <rom_path> <palette_address>                     |
| 8     | export_rareware_palette_image  | <rom_path> <palette_address> <output_image_path>                     |
| 9     | import_gangplank_palette_image | <image_a_path> <image_b_path> <rom_path> <palette_address> <sub_table_address>                     |
| 10    | export_gangplank_palette_image | <rom_path> <palette_address> <sub_table_address> <palette_a_output_image_path> <palette_b_output_image_path>                     |

### What is DKC Toolbox?
[![forthebadge made-with-python](http://ForTheBadge.com/images/badges/made-with-python.svg)](https://www.python.org/)
The DKC Toolbox is a tool written in Python designed to provide basic data conversion and IO for the Donkey Kong Country SNES Trilogy. It was designed to be the successor to BMP2SNES. Noteable features include being able to import and export a variety of unique DKC formats like colour palettes.

DKC Toolbox was released by [H4v0c21](https://www.github.com/H4v0c21/DKC-Toolbox) as a console based program that had no GUI. Commands can be fed to the program through the command line. DKCUI was introduced to parse these commands through a graphical user interface, in an attempt to be more user friendly.