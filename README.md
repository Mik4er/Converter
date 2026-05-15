# Practical Work №2
## Subject: Aspect-Oriented Programming (AOP)

### Project Overview: Converter
This is a desktop application developed in **C# using Windows Forms**. The program provides a simple and efficient way to convert values between various units of measurement across different categories.

**Key Feature:** The application implements **dynamic data loading**. Unit names and their conversion coefficients are stored in external `.txt` files rather than being hardcoded. This allows for easy updates and scalability without recompiling the source code.

### Core Functionality
* **Three Categories:** Supports Length, Mass, and Volume.
* **External Configuration:** Loads data from `length.txt`, `mass.txt`, and `volume.txt`.
* **Dynamic UI:** Automatically populates unit selection lists based on the chosen category.
* **Accuracy:** Performs calculations with precision up to 4 decimal places.
* **Error Handling:** Provides clear English-language alerts for missing files or invalid numeric inputs.

### Configuration File Structure
Data files use a simple semicolon-separated format: `UnitName;Coefficient`

Example from `length.txt`:
```text
Meter;1
Kilometer;1000
Inch;0.0254
````
How to Run
Clone the repository to your local machine.

Open the solution (.sln or .slnx file) in Visual Studio.

Check Data Files: Ensure that length.txt, mass.txt, and volume.txt are included in the Project Explorer (Solution Explorer).

Set File Properties (Crucial Step):

Select the .txt files in the Visual Studio Solution Explorer.

In the Properties window (press F4 if not visible), set "Copy to Output Directory" to "Copy Always".

Build and Run: Press F5 or click the Start button to launch the application.
