# Text Saver

A simple ASP.NET Core Razor Pages application that allows users to type notes and download them as .txt files.

## Features

- Clean, user-friendly interface
- Automatic filename generation with timestamp
- Instant .txt file download
- Responsive design using Bootstrap

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later

### Running the Application

1. Clone the repository:
```bash
git clone https://github.com/undead10/text-saver.git
cd text-saver
```

2. Build the project:
```bash
dotnet build
```

3. Run the application:
```bash
dotnet run
```

4. Open your browser and navigate to `http://localhost:5064`

### Usage

1. Enter a filename (or use the auto-generated one)
2. Type your notes in the text area
3. Click "Save as .txt File" to download your notes

## Project Structure

```
text-saver/
├── Pages/
│   ├── Index.cshtml          # Main page with form
│   ├── Index.cshtml.cs       # Page model with file download logic
│   └── Shared/
│       └── _Layout.cshtml    # Layout template
├── wwwroot/                  # Static files
├── Program.cs                # Application entry point
└── TextSaver.csproj          # Project file
```

## How It Works

The application uses ASP.NET Core Razor Pages with a simple form that posts to the server. When the form is submitted:

1. The server validates the input
2. Generates a filename with .txt extension if not provided
3. Converts the text content to UTF-8 bytes
4. Returns the file as a download with the appropriate MIME type

## Technologies Used

- ASP.NET Core 8.0
- Razor Pages
- Bootstrap 5
