using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace TextSaver.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [BindProperty]
    public string? FileName { get; set; }

    [BindProperty]
    public string? NoteContent { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        // Set default filename with timestamp
        FileName = $"notes_{DateTime.Now:yyyyMMdd_HHmmss}";
    }

    public IActionResult OnPost()
    {
        _logger.LogInformation("OnPost called with FileName: {FileName}, NoteContent: {NoteContent}", 
            FileName ?? "(null)", NoteContent ?? "(null)");

        if (string.IsNullOrWhiteSpace(FileName))
        {
            FileName = $"notes_{DateTime.Now:yyyyMMdd_HHmmss}";
        }

        if (string.IsNullOrWhiteSpace(NoteContent))
        {
            NoteContent = "";
        }

        // Ensure the filename ends with .txt
        if (!FileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
        {
            FileName += ".txt";
        }

        _logger.LogInformation("Processing file download: {FileName}", FileName);

        // Convert content to bytes
        var contentBytes = Encoding.UTF8.GetBytes(NoteContent);

        // Return the file for download
        return File(contentBytes, "text/plain", FileName);
    }
}
