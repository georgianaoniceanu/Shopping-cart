# Shopping Cart Application

This Windows Forms application, built with C#, helps users manage a shopping cart. It allows adding, deleting, and viewing products, along with data persistence, import/export, and printing functionalities.

## Key Features

* **Product Management**: Easily add, delete, and modify products in your cart.
* **Intuitive Interface**: Products are clearly displayed in a `DataGridView`, complemented by a status bar showing the total product count and value.
* **Data Persistence**: Your cart data is automatically saved to a local database when you close the app and loaded when you open it.
* **Export/Import**: Conveniently save your cart to a text file or load a cart from a file.
* **Graphical Representation**: Get a quick visual overview of your cart with a graphical display showing each product line's total value.
* **Printing**: Print out the contents of your shopping cart with ease.

## Project Structure

The application's core is built around two main classes:

### Produs (Product)
Represents an individual item in the cart, defined by its `code`, `name`, `price`, and `quantity`. It implements `INotifyPropertyChanged` for seamless UI updates and `IComparable<Produs>` for sorting by name.

### CosCumparaturi (ShoppingCart)
Manages the collection of Produs objects. It provides methods for adding and deleting items, an indexer for easy access, and properties for the `NumarProduse` (total items) and `ValoareTotala` (total cart value). It also exposes events for tracking cart modifications.

The application features two primary forms:

### MainForm
This is your main window, displaying the shopping cart, a status bar, and a graphical representation of product values. The window is split into these areas using a `Splitter` or `SplitContainer`.

### AdaugaProdusForm (AddProductForm)
A secondary form that lets you add new products to the cart from a predefined list.

## Usage

* **View Cart**: Upon launch, the main form will display the current items in your shopping cart.
* **Add Product**: Navigate to "Add Product" from the main menu to open the secondary form and select an item from the available list.
* **Delete Product**: Select a row in the `DataGridView` and either press the `DEL` key or right-click to use the context menu's "Delete" option.
* **Export/Import**: Use the "Export Cart" and "Import Cart" options in the main menu to save or load your cart data to/from a text file.
* **Print**: Select "Print" from the main menu to print the cart's contents.
## Installation

*git clone *https://github.com/username/shopping-cart-app.git** 

*cd shopping-cart-app*

open with Visual Studio

run project

## Screenshoots

<img width="772" height="490" alt="image" src="https://github.com/user-attachments/assets/25e30668-2097-4eeb-9ce3-5e51e201571a" />

### Add a new product (Adauga produs)

<img width="796" height="488" alt="image" src="https://github.com/user-attachments/assets/e0192556-7474-40cb-9340-97e1fe595ab3" />

<img width="776" height="487" alt="image" src="https://github.com/user-attachments/assets/deacabd4-4f44-4ce9-af76-989302507126" />

### Delete a selected product (Sterge produs)

<img width="938" height="487" alt="image" src="https://github.com/user-attachments/assets/6bf6960b-31fc-46b7-80a3-b24cd4c0649f" />

### Import data from a .txt file

<img width="880" height="489" alt="image" src="https://github.com/user-attachments/assets/1d8dcaae-3d03-437c-b5e7-9d4a753251eb" />

<img width="773" height="485" alt="image" src="https://github.com/user-attachments/assets/0a3a8871-2ef2-46f1-bd6a-061bb6cdb3a2" />

Source file: import.txt

*101;Lapte;6.50;2

*102;Paine;3.00;1*

*103;Oua;12.75;6*

*104;Unt;15.20;1*

*105;Cafea;25.99;1*

### Print out the document (Tipareste)

<img width="889" height="620" alt="image" src="https://github.com/user-attachments/assets/d9693a76-fb11-4144-b1ad-4f2c92e9f891" />





